using UnityEngine;
using System.Collections;
using System;


public abstract class BehaviourTask : PrimitiveTask
{
    public override bool IsBehaviour
    {
        get
        {
            return false;
        }
    }
    

    public override bool Filter()
    {
        return true;
    }
    public float ProvidedUtility { get; set; }
    public override float Utility()
    {
        return ProvidedUtility;
    }
    VoidDelegate FinishNotifier;
    public string TaskName;
    public static T New<T>(GameObject obj, VoidDelegate onFinish, string taskName) where T : BehaviourTask, new()
    {
        var bt =  new T();
        bt.Root = obj;
        bt.FinishNotifier = onFinish;
        bt.TaskName = taskName;
        return bt;
    }

    public override void OnFinish()
    {
        FinishNotifier();
    }

    public override void OnInterrupt()
    {

        FinishNotifier();

    }

    public override void OnTerminate()
    {

        FinishNotifier();
    }
}


