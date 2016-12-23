using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Listener : MonoBehaviour
{
    Metrics metrics;
    Actor actor;
    private void Awake()
    {
        actor = GetComponent<Actor>();
        metrics = GetComponent<Metrics>();
        CanTalk = true;
        
    }

    public List<string> GetHooks()
    {
        List<string> hooksList = new List<string>();
        foreach (var hook in hooksToDialogs)
            hooksList.Add(hook.Key);
        return hooksList;
    }
    public Dialog Dialog()
    {
        var dialog = new Dialog();
        allDialogs.Clear();
        allDialogs.Add(dialog);
        return dialog;
    }
    public bool CanTalk { get; set; }

    public GameObject TalksTo { get; set; }

    List<Dialog> allDialogs = new List<Dialog>();
    Dictionary<string, List<Dialog>> hooksToDialogs = new Dictionary<string, List<Dialog>>();


    public IEnumerator UpdateDialogs(GameObject forWho)
    {
        allDialogs.Clear();
        hooksToDialogs.Clear();
        yield return StartCoroutine(Actions.Instance.GenerateCoroutine(gameObject, 0.1f, 2f, forWho));
        foreach (var dialog in allDialogs)
        {
            if(dialog.Allowed())
            {
                var list = hooksToDialogs.Get(dialog.Hook);
                list.Add(dialog);
            }
        }
    }

    public bool AskToListenTo(GameObject who)
    {

        var desireToTalk = metrics.Value("desire_to_talk", who);
        var willTalk = actor.curAction == null ? true : actor.curAction.Action.Utility() < desireToTalk;
        if(willTalk)
        {
            var idle = new IdleAction() { WaitDelegate = WaitFunction };
            idle.Stopped += HadToStopTalking; 
            actor.Act(idle);
            TalksTo = who;
            hookedSpeaker = false;
            StartCoroutine(CheckHookedSpeaker());
        }
        else
        {
            var e = EventsManager.Instance.GetEvent<DialogRejected>();
            e.Root = gameObject;
            e.Initiator = who;
            EventsManager.Instance.FireEvent(e);
        }
        

        return willTalk;
    }
    private void HadToStopTalking()
    {
        var e = EventsManager.Instance.GetEvent<DialogRejected>();
        e.Root = gameObject;
        e.Initiator = TalksTo;
        EventsManager.Instance.FireEvent(e);
        FinishTalk();
    }
    public void FinishTalk()
    {
        if (TalksTo == null)
            return;
        var talkedTo = TalksTo;
        TalksTo = null;
        talkedTo.GetComponent<Speaker>().FinishTalk();

    }

    bool WaitFunction()
    {
        return TalksTo != null;
    }


    public string ChooseHook(string hook)
    {
        var hookedDialogs = hooksToDialogs[hook];
        Dialog maxDialog = null;
        float maxUtility = float.MinValue;
        foreach(var hookedDialog in hookedDialogs)
        {
            var ut = hookedDialog.Utility();
            if (ut > maxUtility)
            {
                maxUtility = ut;
                maxDialog = hookedDialog;
            }
        }
        if(maxDialog != null)
        {
            var line = maxDialog.Line;
            line.Reaction();
            return line.String;
        }
        return null;
    }
    bool hookedSpeaker;
    public void OnHookedSpeaker()
    {
        hookedSpeaker = true;
    }

    IEnumerator CheckHookedSpeaker()
    {
        yield return null;
        if(!hookedSpeaker)
        {
            TalksTo.GetComponent<Speaker>().FinishTalk();
            TalksTo = null;

        }
    }
}

[EventAction(IsAIAction = true)]
public class IdleAction : EventAction
{
    public Func<bool> WaitDelegate;
    public override bool Filter()
    {
        return true;
    }

    public override void Action()
    {
        state = ActionState.Started;
        Coroutine = WaitCoroutine();
    }

    IEnumerator WaitCoroutine()
    {
        state = ActionState.Started;
        while (WaitDelegate())
            yield return null;
        state = ActionState.Finished;
    }
}


public class DialogRejected : Event
{
    public GameObject Initiator { get; set; }
}