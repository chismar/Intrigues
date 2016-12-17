using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class InteractableButton : MonoBehaviour
{
    public Text InteractionName;
    public Button Button;
    public EventAction Interaction;

    List<Dependency> deps;
    HoverTooltip tooltip;
    private void Start()
    {
        InteractionName.text = Interaction.GetType().Name;
        deps = Interaction.GetDependencies();
        tooltip = GetComponent<HoverTooltip>();
        if(tooltip == null)
            tooltip = gameObject.AddComponent<HoverTooltip>();
        Button.onClick.AddListener(OnButtonClicked);
        InterAvailable();
        RebuildTooltip();
    }

    void OnButtonClicked()
    {
        if(InterAvailable() && Interaction.Filter())
        {
            Interaction.Action();
        }
    }
    List<string> satisfiedDeps = new List<string>();
    List<string> unsatisfiedDeps = new List<string>();
    StringBuilder depsTooltipBuilder = new StringBuilder();
    string depsData;
    private void Update()
    {
       
        

        if(InterAvailable())
        {
            Button.interactable = true;
        }
        else
        {
            Button.interactable = false;
        }

    }

    bool InterAvailable()
    {
        bool available = true;
        if (deps != null)
        {
            int satCount = satisfiedDeps.Count;
            int unSatCount = satisfiedDeps.Count;
            satisfiedDeps.Clear();
            unsatisfiedDeps.Clear();
            foreach (var dep in deps)
            {
                if (!dep.Satisfied())
                {
                    available = false;
                    unsatisfiedDeps.Add(dep.GetType().Name);
                }
                else
                {
                    satisfiedDeps.Add(dep.GetType().Name);
                }
            }

            if (satCount != satisfiedDeps.Count || unSatCount != unsatisfiedDeps.Count)
            {
                RebuildTooltip();
            }
        }
        return available;
    }

    void RebuildTooltip()
    {
        depsTooltipBuilder.Append("<color=green>");
        foreach (var satDep in satisfiedDeps)
            depsTooltipBuilder.Append(satDep).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();

        depsTooltipBuilder.Append("<color=red>");
        foreach (var satDep in unsatisfiedDeps)
            depsTooltipBuilder.Append(satDep).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();
        depsData = depsTooltipBuilder.ToString();
        tooltip.Text = depsData;
        depsTooltipBuilder.Length = 0;
    }
}
