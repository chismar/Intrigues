using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogUI : MonoBehaviour
{
    public GameObject HookButtonsPrefab;
    public Text Text;
    public Text TalksToName;
    public Transform HooksPanel;
    public GameObject DialogPanel;
    Listener listener;

    private void Awake()
    {
        FindObjectOfType<BasicLoader>().EFunctions.Add(new BasicLoader.ExternalFunctions(this, "InitDialogUi", "CloseDialogUi"));
        CloseDialogUi();
    }
    public void InitDialogUi(GameObject speakerGO)
    {
        DialogPanel.SetActive(true);
        Clear();
        listener = speakerGO.GetComponent<Speaker>().TalksTo.GetComponent<Listener>();
        TalksToName.text = listener.gameObject.name;
        listener.OnHookedSpeaker();
        StartCoroutine(UpdateCoroutine(listener));
    }

    public void CloseDialogUi(object scriptVoidHack = null)
    {
        Clear();
        DialogPanel.SetActive(false);
    }
    IEnumerator UpdateCoroutine(Listener listener)
    {
        yield return listener.UpdateDialogs(listener.TalksTo);
        Debug.Log("Finished updating dialogs");
        var hooks = listener.GetHooks();
        foreach (var hook in hooks)
        {
            Debug.Log(hook);
            var hookGO = GameObject.Instantiate(HookButtonsPrefab);
            hookGO.transform.SetParent(HooksPanel);
            var hookButton = hookGO.GetComponent<HookButton>();
            hookButton.Listener = listener;
            hookButton.Hook = hook;
            hookButton.UI = this;
        }
    }

    public void ReceiveLine(string line)
    {
        InitDialogUi(listener.TalksTo);
        Text.text = line;

    }

    void Clear()
    {
        Text.text = "";
        for (int i = 0; i < HooksPanel.childCount; i++)
            Destroy(HooksPanel.GetChild(i).gameObject);
    }

    public void CancelTalk()
    {
        listener.FinishTalk();
        CloseDialogUi();
    }
}
