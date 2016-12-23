using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HookButton : MonoBehaviour
{
    string hook;
    public string Hook { get { return hook; } set { hook = value;  GetComponentInChildren<Text>().text = hook; } }
    public Listener Listener;
    public DialogUI UI;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        UI.ReceiveLine(Listener.ChooseHook(Hook));
    }
}
