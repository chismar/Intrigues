using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class InteractableButton : MonoBehaviour
{
    public Text GUIInteractionDescription;
    public Button GUIButton;
    public HoverTooltip GUITooltip;
    public InteractionTask Interaction;
    LocalizedString description;
    Agent agent;
    private void Start()
    {
        description = new LocalizedString(Interaction.GetType().Name, new Dictionary<string, object>() { {"other", Interaction.Other} });
        GUIInteractionDescription.text = description.Render(Interaction.Root);
        agent = Interaction.Root.GetComponent<Agent>();
        GUIButton.onClick.AddListener(OnButtonClicked);
    }
    public void DemandUpdate()
    {
        if (CanBeEnacted())
        {
            EnableButton();
        }
        else
            DisableButton();
    }
    void DisableButton()
    {
        GUIButton.interactable = false;
    }
    void EnableButton()
    {
        GUIButton.interactable = true;
    }
    static HashSet<TaskWrapper> satConditions = new HashSet<TaskWrapper>();
    static HashSet<TaskWrapper> unsatConditions = new HashSet<TaskWrapper>();
    bool CanBeEnacted()
    {
        satConditions.Clear();
        unsatConditions.Clear();
        bool shouldRebuildTooltip = false;
        bool canBeEnacted = true;
        var cons = Interaction.Constraints;
        if(cons != null)
        {
            for (int i = 0; i < cons.Count; i++)
            {
                var con = cons[i];
                if (con.Met)
                    satConditions.Add(con);
                else
                    unsatConditions.Add(con);
            }
            cons.Update();
            for ( int i = 0; i < cons.Count; i++)
            {
                var con = cons[i];
                if (!con.Met)
                {
                    canBeEnacted = false;
                    if (!shouldRebuildTooltip)
                        if (satConditions.Contains(con))
                            shouldRebuildTooltip = true;
                }
                else
                {
                    if (!shouldRebuildTooltip)
                        if (unsatConditions.Contains(con))
                            shouldRebuildTooltip = true;
                }
                
            }
        }
        var deps = Interaction.Dependencies;
        if(deps != null)
        {
            for (int i = 0; i < deps.Count; i++)
            {
                var dep = deps[i];
                if (dep.Met)
                    satConditions.Add(dep);
                else
                    unsatConditions.Add(dep);
            }
            deps.Update();
            for (int i = 0; i < deps.Count; i++)
            {
                var dep = deps[i];
                if (!dep.Met)
                { 
                    canBeEnacted = false;
                }
                else
                {
                    if (!shouldRebuildTooltip)
                    if (unsatConditions.Contains(dep))
                        shouldRebuildTooltip = true;
                }
            }
        }
        var otherAgent = Interaction.Other.GetComponent<Agent>();
        if (otherAgent != null)
        {
            if (otherAgent.CurrentUtility() > Interaction.Utility())
                canBeEnacted = false;
        }
        if (shouldRebuildTooltip)
            RebuildTooltip();
        return canBeEnacted;
    }

    void OnButtonClicked()
    {
        if (CanBeEnacted())
        {

            agent.Do(Interaction);

        }
        else
            DisableButton();
    }
    static StringBuilder depsTooltipBuilder = new StringBuilder();
    void RebuildTooltip()
    {
        depsTooltipBuilder.Length = 0;
        depsTooltipBuilder.Append("<color=green>");
        if (Interaction.Dependencies != null)
            foreach (var satDep in Interaction.Dependencies)
            if(satDep.Met)
            depsTooltipBuilder.Append(satDep.Serialized.Render(agent.gameObject)).AppendLine();
        if (Interaction.Constraints != null)
            foreach (var satDep in Interaction.Constraints)
            if (satDep.Met)
                depsTooltipBuilder.Append(satDep.Serialized.Render(agent.gameObject)).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();

        depsTooltipBuilder.Append("<color=red>");
        if(Interaction.Dependencies != null)
        foreach (var satDep in Interaction.Dependencies)
            if(!satDep.Met)
            depsTooltipBuilder.Append(satDep.Serialized.Render(agent.gameObject)).AppendLine();
        if (Interaction.Constraints != null)
            foreach (var satDep in Interaction.Constraints)
            if (!satDep.Met)
                depsTooltipBuilder.Append(satDep.Serialized.Render(agent.gameObject)).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();
        GUITooltip.Text = depsTooltipBuilder.ToString();
        depsTooltipBuilder.Length = 0;
    }
}
