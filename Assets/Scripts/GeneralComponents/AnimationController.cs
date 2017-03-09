using UnityEngine;
using System.Collections;

using UnityEngine.Experimental.Director;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour
{

    Animator animator;
    AnimationMixerPlayable mixer;
    Playable currentPlayable;
    Playable nextPlayable;
    int nextPlayableID;
    //TODO: fix this shit, as the assumption under RemoveInput was that it actually removes it, but in reality it just sets it as null
    Stack<int> freePorts = new Stack<int>(3);
    Dictionary<string, Playable> controllerPlayables = new Dictionary<string, Playable>();
    HashSet<Playable> controllersSet = new HashSet<Playable>();
    Dictionary<string, int> controllersPorts = new Dictionary<string, int>();
    private void Awake()
    {
        currentPlayable = Playable.Null;
        nextPlayable = Playable.Null;
        mixer = AnimationMixerPlayable.Create();

        animator = GetComponent<Animator>();
        animator.Play(mixer);
    }

    private void OnDestroy()
    {
        animator.Stop();
        for ( int i = 0; i < mixer.inputCount; i++)
        {
            var p = mixer.GetInput(i);
            if (p.IsValid())
                p.Destroy();
        }
        mixer.Destroy();
    }
    public void Play(string animationName)
    {
        Playable newPlayable;
        int portId = -1;
        if (controllerPlayables.ContainsKey(animationName))
        {
            newPlayable = controllerPlayables[animationName];
            portId = controllersPorts[animationName];
        }
        else
        {

            newPlayable = AnimationStore.Instance.GetAnimation(animationName);

            if (freePorts.Count > 0)
            {
                portId = freePorts.Pop();
                mixer.SetInput(newPlayable, portId);
            }
            else
            {

                portId = mixer.AddInput(newPlayable);
            }

            if (Playable.GetTypeOf(newPlayable) == typeof(AnimatorControllerPlayable))
            {
                controllerPlayables.Add(animationName, newPlayable);
                controllersSet.Add(newPlayable);
                controllersPorts.Add(animationName, portId);
            }
            
        }
        if (newPlayable == Playable.Null)
            Debug.LogWarning(animationName + " is null");
        
        
        if (currentPlayable == Playable.Null)
        {
            currentPlayable = newPlayable;
            nextPlayable = newPlayable;
            mixer.SetInputWeight(portId, 1f);
            prevLeftWeight = 0f;
            //StartCoroutine(Slowdown(portId));

        }
        else
        {
            nextPlayable = newPlayable;
            mixer.SetInputWeight(portId, 0f);
            prevLeftWeight = 1f;

        }
        nextPlayableID = portId;
        //animator.Play(mixer);
    }
    static List<int> inputsToRemove = new List<int>();
    static Stack<float> newWeights = new Stack<float>();
    float fadeSpeed = 0.05f;
    float prevLeftWeight;
    private void Update()
    {
        if (mixer.inputCount == 0)
            return;
        inputsToRemove.Clear();
        newWeights.Clear();
        var nextPlayableWeight = mixer.GetInputWeight(nextPlayableID);
        if (nextPlayableWeight < 1f)
        {
            nextPlayableWeight += fadeSpeed;
            if (nextPlayableWeight > 1f)
                nextPlayableWeight = 1f;
            mixer.SetInputWeight(nextPlayableID, nextPlayableWeight);


            float weightLeft = 1f - nextPlayableWeight;
            float difX = weightLeft / prevLeftWeight;
            for (int i = 0; i < mixer.inputCount; i++)
            {
                if (i == nextPlayableID)
                    continue;
                float weight = mixer.GetInputWeight(i);
                var playable = mixer.GetInput(i);
                if (playable.IsValid())
                { 
                    weight *= difX;
                    if (weight <= 0.05f)
                    {
                        if(!controllersSet.Contains(playable))
                            inputsToRemove.Add(i);
                        weight = 0f;
                    }
                    else
                    {
                        weightLeft -= weight;
                    }
                    newWeights.Push(weight);
                }
            }

            nextPlayableWeight += weightLeft + 0.000001f;
            mixer.SetInputWeight(nextPlayableID, nextPlayableWeight);
            prevLeftWeight = 0f;
            float weightSum = 0f;
            for ( int i = 0; i < mixer.inputCount; i++)

            {   
                if(mixer.GetInput(i).IsValid())
                weightSum += mixer.GetInputWeight(i);
            }
            if (weightSum < 1f)
                Debug.LogError("Weight sum is " + weightSum);
            for (int i = 0; i < mixer.inputCount; i++)
            {
                if (i == nextPlayableID)
                    continue;
                var playable = mixer.GetInput(i);
                if (playable.IsValid())
                {
                    var w = newWeights.Pop();
                    prevLeftWeight += w;
                    mixer.SetInputWeight(i, w);
                }
            }
            for (int i = inputsToRemove.Count - 1; i >= 0; i--)
            {
                var pi = inputsToRemove[i];
                var p = mixer.GetInput(pi);
                mixer.RemoveInput(pi);
                mixer.SetInput(Playable.Null, pi);
                freePorts.Push(pi);
                if (p.IsValid()) p.Destroy();
            }
            //if (inputsToRemove.Count > 0)
            //    animator.Play(mixer);
        }

        
        
        

    }

    private void OnGUI()
    {
        if(mixer.IsValid())
        GraphVisualizerClient.Show(mixer, gameObject.name);
    }
}

