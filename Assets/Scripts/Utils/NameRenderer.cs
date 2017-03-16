using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]
public class NameRenderer : MonoBehaviour
{

    public Text Text;
    public GameObject Named;

    string name = null;
    [ExecuteInEditMode]
    private void Update()
    {
        if (Named == null)
        {
            Text.name = null;
            return;
        }
        if(name != Named.name)
        {
            name = Named.name;
            Text.text = name;
        }
    }
}
