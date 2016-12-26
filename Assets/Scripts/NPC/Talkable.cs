using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talkable : MonoBehaviour
{

    public bool CanTalk { get; set; }
    public GameObject TalksTo { get; set; }
    private void Awake()
    {
        CanTalk = true;
    }

    
    public Dialog Dialog()
    {
        var dialog = new Dialog();
        allDialogs.Clear();
        allDialogs.Add(dialog);
        return dialog;
    }
    public List<Dialog> allDialogs = new List<Dialog>();
    public Dictionary<string, List<Dialog>> hooksToDialogs = new Dictionary<string, List<Dialog>>();
    public void TalkTo(GameObject other)
    {
        if (TalksTo != null)
            return;
        Talkable t = other.GetComponent<Talkable>();
        if (t == null)
            return;
        StartCoroutine(TalkCoroutine(other, t));
    }
    DialogEvent e;
    IEnumerator TalkCoroutine(GameObject other, Talkable otherTalk)
    {
        TalksTo = other;
        otherTalk.TalksTo = gameObject;
        otherTalk.hooksToDialogs.Clear();
        yield return StartCoroutine(Actions.Instance.GenerateCoroutine(other, 0.1f, 2f, gameObject));
        otherTalk.hooksToDialogs.Clear();
        foreach(var dialog in otherTalk.allDialogs)
        {
            var list = otherTalk.hooksToDialogs.Get(dialog.Hook);
            list.Add(dialog);
        }
        //...
        e = EventsManager.Instance.GetEvent<DialogEvent>();
        e.Root = gameObject;
        e.Target = other;
        EventsManager.Instance.UpdateEvent(e);

        TalksTo = null;
        otherTalk.TalksTo = null;
    }


    public void HookChosen(string hook)
    {

    }


    private void OnDestroy()
    {
        if (e != null)
            EventsManager.Instance.FinishEvent(e);
    }

}


public class DialogEvent : Event
{
    public GameObject Target { get; set; }
}


public class Dialog
{
    public string Id { get; set; }
    public string Hook { get; set; }
    public delegate float FloatDelegate();
    public FloatDelegate Utility { get; set; }
    public delegate bool BoolDelegate();
    public BoolDelegate Allowed { get; set; }
    public DialogLine Line { get; internal set; }
    public DialogLine Say()
    {
        Line = new DialogLine();

        return Line;
    }
}

public class DialogLine
{
    public LocalizedString String { get; set; }

    public VoidDelegate Reaction { get; set; }
}


public interface DialogOption
{
    GameObject Other { get; set; }
}