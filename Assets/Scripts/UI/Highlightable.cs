using UnityEngine;
using System.Collections;

public class Highlightable : MonoBehaviour
{
    SpriteRenderer renderer;
    public bool isLitUp = false;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    Color previousColor;
    public void LitUp()
    {
        if (isLitUp)
            return;
        previousColor = renderer.color;
        renderer.color = new Color(0.9f, 0.3f, 0.3f);
        isLitUp = true;
    }

    public void LitDown()
    {
        if (!isLitUp)
            return;
        renderer.color = previousColor;
        isLitUp = false;
    }
}
