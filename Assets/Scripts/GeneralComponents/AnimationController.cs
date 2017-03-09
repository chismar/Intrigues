using UnityEngine;
using System.Collections;

using UnityEngine.Experimental.Director;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour
{

    Animator animator;
    PlayableGraph graph;
    PlayableHandle mixer;
    //Playable currentPlayable;
    //Playable nextPlayable;
    //int nextPlayableID;
    //TODO: fix this shit, as the assumption under RemoveInput was that it actually removes it, but in reality it just sets it as null
    //Stack<int> freePorts = new Stack<int>(3);
    //Dictionary<string, Playable> controllerPlayables = new Dictionary<string, Playable>();
    //HashSet<Playable> controllersSet = new HashSet<Playable>();
    //Dictionary<string, int> controllersPorts = new Dictionary<string, int>();
    int curInputIndex = -1;
    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        mixer = AnimationPlayableUtilities.PlayMixer(animator, 3, out graph);
    }

    private void OnDestroy()
    {
        graph.Destroy();
    }
    bool hadInit = false;
    public void Play(string animationName)
    {
        Debug.Log("Play " + animationName);
        var clip = AnimationStore.Instance.GetAnimation(animationName);
        PlayableHandle handle;
        if(clip == null)
        {
            var controller = AnimationStore.Instance.GetController(animationName);
            handle = graph.CreateAnimatorControllerPlayable(controller);
        }
        else
        {
            handle = graph.CreateAnimationClipPlayable(clip);
        }
        curInputIndex++;
        if (curInputIndex == mixer.inputCount)
            curInputIndex = 0;
        if(mixer.GetInput(curInputIndex) != PlayableHandle.Null)
        {
            var input = mixer.GetInput(curInputIndex);
            graph.Disconnect(mixer, curInputIndex);
            input.Destroy();
        }
        graph.Connect(handle, 0, mixer, curInputIndex);
        if(hadInit)
            mixer.SetInputWeight(curInputIndex, 0f);
        else
        {
            mixer.SetInputWeight(curInputIndex, 1f);
            hadInit = true;
        }
        
    }
    //static List<int> inputsToRemove = new List<int>();
    //static Stack<float> newWeights = new Stack<float>();
    float fadeSpeed = 0.001f;
    //float prevLeftWeight;
    private void Update()
    {
        for (int i = 0; i < mixer.inputCount; i++)
        {
            if (i == curInputIndex)
            {
                var w = mixer.GetInputWeight(i) + fadeSpeed;
                if (w >= 1f)
                    w = 1f;
                mixer.SetInputWeight(i, w);
            }
            else
            {
                var w = mixer.GetInputWeight(i) - fadeSpeed;
                if (w < fadeSpeed * 2)
                    w = 0f;
                mixer.SetInputWeight(i, w);
            }
        }





        /*if (mixer.inputCount == 0)
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
        */
        
        
        

    }

    private void OnGUI()
    {
        if(gameObject.name == "NPC")
        {
            GUI.Label(Rect.MinMaxRect(100, 100, 400, 200), mixer.GetInputWeight(0).ToString());
            GUI.Label(Rect.MinMaxRect(100, 200, 400, 300), mixer.GetInputWeight(1).ToString());
            GUI.Label(Rect.MinMaxRect(100, 300, 400, 400), mixer.GetInputWeight(2).ToString());
        }
    }

}

