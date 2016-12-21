using UnityEngine;
using System.Collections;

public class Talkable : MonoBehaviour
{

    public bool CanTalk { get; set; }

    private void Awake()
    {
        CanTalk = true;
    }

    
    public Dialog Dialog()
    {
        var dialog = new Dialog();
        return dialog;
    }

}


public class Dialog
{
    public string Id { get; set; }
    public string Hook { get; set; }
    public delegate float FloatDelegate();
    public FloatDelegate Utility { get; set; }
    public delegate bool BoolDelegate();
    public BoolDelegate Allowed { get; set; }
    public DialogLine Say()
    {
        var line = new DialogLine();

        return line;
    }
}

public class DialogLine
{
    public string String { get; set; }

    public VoidDelegate Reaction { get; set; }
}


public interface DialogOption
{
    GameObject Other { get; set; }
}