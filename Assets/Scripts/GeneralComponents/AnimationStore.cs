using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;
using System.Collections.Generic;
using System;

public class AnimationStore : Root<AnimationStore>
{
    [SerializeField]
    ClipsDictionary clipsByName;
    [SerializeField]
    ControllersDictionary controllersByName;
    public Playable GetAnimation(string name)
    {
        if (clipsByName != null)
            if (clipsByName.ContainsKey(name))
            {
                var clip = clipsByName[name];
                return AnimationClipPlayable.Create(clip);
            }
        if(controllersByName != null)
            if(controllersByName.ContainsKey(name))
            {
                var controller = controllersByName[name];
                return AnimatorControllerPlayable.Create(controller);
            }
        return Playable.Null;
    }
    
}

[Serializable]
public class ControllersDictionary : SerializableDictionary<string, RuntimeAnimatorController>
{ }

[Serializable]
public class ClipsDictionary : SerializableDictionary<string, AnimationClip>
{ }
