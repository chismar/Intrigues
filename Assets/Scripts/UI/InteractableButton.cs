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
    public InteractionsView View;
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
        wasAvailable = !InterAvailable();
    }

    void OnButtonClicked()
    {
        if (InterAvailable() && Interaction.Filter())
        {
            Interaction.Action();
            if (Interaction.Coroutine != null)
                Interaction.Coroutine.MoveNext();
        }
        View.UpdateView();
    }
    static ObjectPool<List<Dependency>> lists = new ObjectPool<List<Dependency>>();
    List<Dependency> satisfiedDeps = new List<Dependency>();
    List<Dependency> unsatisfiedDeps = new List<Dependency>();
    StringBuilder depsTooltipBuilder = new StringBuilder();
    string depsData;
    bool wasAvailable = false;
    private void Update()
    {


        var nowAvailable = InterAvailable();
        if (nowAvailable == wasAvailable)
            return;
        else
        {
            if (nowAvailable)
            {
                Button.interactable = true;
            }
            else
            {
                Button.interactable = false;
            }
            wasAvailable = nowAvailable;
        }
        

    }

    bool InterAvailable()
    {
        bool available = true;
        bool changed = false;
        if (deps != null)
        {
            var unSatList = lists.Get();
            unSatList.Clear();
            var satList = lists.Get();
            satList.Clear();
            for (int i = 0; i < deps.Count;i++)
            {
                var dep = deps[i];
                if (!dep.Satisfied())
                {
                    available = false;
                    unSatList.Add(dep);
                    if (satisfiedDeps.Contains(dep))
                        changed = true;
                }
                else
                {
                    satList.Add(dep);
                    if (unsatisfiedDeps.Contains(dep))
                        changed = true;
                }
            }

            lists.Return(satisfiedDeps);
            lists.Return(unsatisfiedDeps);
            satisfiedDeps = satList;
            unsatisfiedDeps = unSatList;
            if(changed)
                RebuildTooltip();
        }
        return available;
    }

    void RebuildTooltip()
    {
        depsTooltipBuilder.Append("<color=green>");
        foreach (var satDep in satisfiedDeps)
            depsTooltipBuilder.Append(satDep.ToString()).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();

        depsTooltipBuilder.Append("<color=red>");
        foreach (var satDep in unsatisfiedDeps)
            depsTooltipBuilder.Append(satDep.ToString()).AppendLine();
        depsTooltipBuilder.Append("</color>").AppendLine();
        depsData = depsTooltipBuilder.ToString();
        tooltip.Text = depsData;
        depsTooltipBuilder.Length = 0;
    }
}
