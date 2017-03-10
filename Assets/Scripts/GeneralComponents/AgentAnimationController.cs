using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentAnimationController : MonoBehaviour
{
    Agent agent;
    AnimationController animations;
    PrimitiveAgentBehaviour beh;
    private void Awake()
    {
        agent = GetComponent<Agent>();
        animations = GetComponent<AnimationController>();
        StartCoroutine(CollectAnimationsOnLoaded());
    }

    IEnumerator CollectAnimationsOnLoaded()
    {
        while (GetComponent<GenerationMarker>() != null)
            yield return null;
        HashSet<string> animationsSet = new HashSet<string>();
        foreach ( var pool in TasksStore.Instance.TaskPoolsByType.Values)
        {
            var task = pool.Get() as Task;
            if(task is ComplexTask)
            {
                pool.Return(task);
                continue;
            }
            if(task is InteractionTask)
            {
                var iTask = task as InteractionTask;
                iTask.Other = gameObject;
                if (iTask.OtherFilter())
                    animationsSet.Add(iTask.OtherAnimation);
            }

            var pTask = task as PrimitiveTask;
            pTask.Root = gameObject;
            if (pTask.Filter())
                animationsSet.Add(pTask.Animation);
            pool.Return(task);
        }
        animations.Init(animationsSet);
    }
    private void Update()
    {
        if(agent.currentTaskBehaviour != null)
        if(beh != agent.currentTaskBehaviour)
        {
            var prevAnim = beh != null ? (beh.Task as PrimitiveTask).Animation : null;
            beh = agent.currentTaskBehaviour;
            if(prevAnim != (beh.Task as PrimitiveTask).Animation)
            animations.Play((beh.Task as PrimitiveTask).Animation);

        }
    }
}
