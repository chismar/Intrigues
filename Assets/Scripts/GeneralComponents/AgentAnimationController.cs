using UnityEngine;
using System.Collections;

public class AgentAnimationController : MonoBehaviour
{
    Agent agent;
    AnimationController animations;
    PrimitiveAgentBehaviour beh;
    private void Awake()
    {
        agent = GetComponent<Agent>();
        animations = GetComponent<AnimationController>();
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
