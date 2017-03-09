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
    public AnimationClip GetAnimation(string name)
    {
        if (clipsByName != null)
            if (clipsByName.ContainsKey(name))
            {
                var clip = clipsByName[name];
                return clip;
            }
        return null;
    }

    public RuntimeAnimatorController GetController(string name)
    {
        if (controllersByName != null)
            if (controllersByName.ContainsKey(name))
            {
                var controller = controllersByName[name];
                return controller;
            }
        return null;
    }
    
}

[Serializable]
public class ControllersDictionary : SerializableDictionary<string, RuntimeAnimatorController>
{ }

[Serializable]
public class ClipsDictionary : SerializableDictionary<string, AnimationClip>
{ }
