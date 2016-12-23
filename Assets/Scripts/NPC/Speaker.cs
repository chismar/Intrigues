using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour
{

    public bool CanTalk { get; set; }

    public GameObject TalksTo { get; set; }

    private void Awake()
    {
        CanTalk = true;
    }
    public bool TalkTo(GameObject who)
    {
        Debug.Log("Trying to talk to " + who);
        var listener = who.GetComponent<Listener>();
        if (listener == null)
            return false;
        var willTalk = listener.AskToListenTo(gameObject);
        if (!willTalk)
            return false;
        TalksTo = who;
        var e = EventsManager.Instance.GetEvent<DialogAccepted>();
        e.Root = who;
        e.Initiator = gameObject;
        EventsManager.Instance.FireEvent(e);
        return true;
    }

    public void FinishTalk()
    {
        if (TalksTo == null)
            return;

        var e = EventsManager.Instance.GetEvent<DialogFinished>();
        e.Root = TalksTo;
        e.Initiator = gameObject;
        var talkedTo = TalksTo;
        TalksTo = null;
        talkedTo.GetComponent<Speaker>().FinishTalk();
        EventsManager.Instance.FireEvent(e);
    }
}


public class DialogAccepted : Event
{
    public GameObject Initiator { get; set; }
}

public class DialogFinished : Event
{
    public GameObject Initiator { get; set; }
}