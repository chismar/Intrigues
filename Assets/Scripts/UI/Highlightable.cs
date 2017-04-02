using UnityEngine;
using System.Collections;

public class Highlightable : MonoBehaviour
{
    Renderer renderer;
    public bool isLitUp = false;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        if (renderer == null)
            renderer = GetComponentInChildren<MeshRenderer>();
    }

    Color previousColor;
    public void LitUp()
    {
        if (isLitUp)
            return;
        previousColor = renderer.material.color;
        renderer.material.color = new Color(0.9f, 0.3f, 0.3f);
        isLitUp = true;
    }

    public void LitDown()
    {
        if (!isLitUp)
            return;
        renderer.material.color = previousColor;
        isLitUp = false;
    }
}
