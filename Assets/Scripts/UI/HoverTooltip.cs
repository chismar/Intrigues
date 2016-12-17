using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	static Transform HoverPanel;
	static Text HoverText;

	[SerializeField]
	string text;
    bool isInControl = false;
	public string Text { get { return text; } set { text = value; if(isInControl)HoverText.text = text; } }

	void Awake ()
	{
		
		if (HoverPanel == null)
		{
			HoverPanel = (GameObject.Instantiate (Resources.Load ("Prefabs/UI/TooltipPanel")) as GameObject).transform;
			HoverPanel.SetParent (GameObject.Find ("Canvas").transform);
			HoverText = HoverPanel.GetComponentInChildren<Text> ();
			HoverPanel.gameObject.SetActive (false);
		}
	}

	WaitForSeconds sec = new WaitForSeconds (0.3f);
	Vector3 lastPos;
	static float treshold = 0.1f * 0.1f;

	IEnumerator HoverCoroutine ()
	{
		HoverPanel.SetAsLastSibling ();
		HoverText.text = Text;
		lastPos = Input.mousePosition;
		while (true)
		{

			lastPos = Input.mousePosition;
			yield return sec;
			var delta = (lastPos - Input.mousePosition).sqrMagnitude;
			if (delta < treshold)
			{
                isInControl = true;

                HoverPanel.gameObject.SetActive (text != null && text.Length > 0);
				HoverPanel.position = Input.mousePosition + new Vector3 (3, -3, 0);
			} else
			{
                isInControl = false;

                HoverPanel.gameObject.SetActive (false);
			}
		}


	}

	IEnumerator hoverCoroutine;
	bool wasOutside = true;

	public void OnPointerEnter (PointerEventData eventData)
	{
		
		if (wasOutside)
		{
			Debug.Log ("On pointer enter");
			hoverCoroutine = HoverCoroutine ();
			StartCoroutine (hoverCoroutine);
			wasOutside = false;
		}

	}

	static List<RaycastResult> hits = new List<RaycastResult> ();

	public void OnPointerExit (PointerEventData eventData)
	{
		hits.Clear ();
		EventSystem.current.RaycastAll (eventData, hits);
		if (hits.FindIndex (x => x.gameObject == gameObject) == -1)
		{
			Debug.Log ("On pointer exit");
			StopCoroutine (hoverCoroutine);

			HoverPanel.gameObject.SetActive (false);
			wasOutside = true;

            isInControl = false;
        }

	}

    void OnDestroy()
    {
        if(hoverCoroutine != null)
        StopCoroutine(hoverCoroutine);
        if(HoverPanel != null)
        HoverPanel.gameObject.SetActive(false);
        wasOutside = true;
        isInControl = false;
    }
}

