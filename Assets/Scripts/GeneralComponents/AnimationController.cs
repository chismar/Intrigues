using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Director;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour
{
    
    PlayableGraph graph;
    PlayableHandle mixer;
    Dictionary<string, int> animationToIndex = new Dictionary<string, int>();
    int curAnimationIndex = -1;

    public void Init(HashSet<string> animations)
    {
        var animator = GetComponent<Animator>();
        mixer = AnimationPlayableUtilities.PlayMixer(animator, animations.Count, out graph);

        int i = 0;
        foreach(var animationName in animations)
        {
            
            var clip = AnimationStore.Instance.GetAnimation(animationName);
            PlayableHandle handle;

            if (clip == null)
            {
                var controller = AnimationStore.Instance.GetController(animationName);
                handle = graph.CreateAnimatorControllerPlayable(controller);
            }
            else
            {
                handle = graph.CreateAnimationClipPlayable(clip);
            }
            graph.Connect(handle, 0, mixer, i);
            animationToIndex.Add(animationName, i);
            i++;
        }

    }

    private void OnDestroy()
    {
        if(graph.IsValid())
            graph.Destroy();
    }
    public void Play(string animationName)
    {
        //Debug.Log("Play " + animationName);
        if (animationToIndex.ContainsKey(animationName))
        {
            if(curAnimationIndex != -1)
                nonZeroInputs.Add(curAnimationIndex);
            curAnimationIndex = animationToIndex[animationName];
        }
        

    }
    List<int> nonZeroInputs = new List<int>();
    float fadeTime = 0.3f;
    private void Update()
    {
        float fadeSpeed = Time.deltaTime / fadeTime;
        if (curAnimationIndex == -1)
            return;
        else
        {
            var w = mixer.GetInputWeight(curAnimationIndex) + fadeSpeed;
            if (w >= 1f)
            {

                w = 1f;
                for (int i = 0; i < nonZeroInputs.Count; i++)
                {
                    var inputIndex = nonZeroInputs[i];
                    mixer.SetInputWeight(inputIndex, 0f);
                }
                nonZeroInputs.Clear();
            }
            mixer.SetInputWeight(curAnimationIndex, w);
            
        }
        float totalWeight = 0f;
        for (int i = 0; i < nonZeroInputs.Count; i++)
        {
            totalWeight += mixer.GetInputWeight(nonZeroInputs[i]);
        }
       for ( int i = 0; i < nonZeroInputs.Count; i++)
        {
            var inputIndex = nonZeroInputs[i];
            float iw = mixer.GetInputWeight(inputIndex);
            var w = iw - fadeSpeed * iw / totalWeight;
            if (w < fadeSpeed * 2)
            {
                w = 0f;
                nonZeroInputs.RemoveAt(i);
                i--;
            }
            mixer.SetInputWeight(inputIndex, w);
        }
        
        
    }
#if UNITY_EDITOR
    bool wasSelected = false;
    private void OnGUI()
    {
        if(UnityEditor.Selection.Contains(gameObject))
        {
            wasSelected = true;
            if (mixer.IsValid())
                GraphVisualizerClient.Show(mixer.GetObject(), gameObject.name);
        }
        else if (wasSelected)
        {
            wasSelected = false;
            Debug.Log("hide " + gameObject.name);
            GraphVisualizerClient.Remove(mixer.GetObject());
        }
    }
#endif
}

