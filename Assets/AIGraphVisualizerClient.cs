using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;
using System.Collections.Generic;

// Bridge between runtime and editor code: the graph created in runtime code can call GraphVisualizerClient.Show(...)
// and the EditorWindow will register itself with the client to display any available graph.
public class AIGraphVisualizerClient
{
    public delegate void UpdateGraphDelegate(AIObject p, string title);
    public UpdateGraphDelegate updateGraph;

    public delegate void RemoveGraphDelegate(AIObject p);
    public RemoveGraphDelegate removeGraph;

    private static AIGraphVisualizerClient s_Instance;

    public static AIGraphVisualizerClient instance
    {
        get
        {
            if (s_Instance == null)
                s_Instance = new AIGraphVisualizerClient();
            return s_Instance;
        }
    }
    public static void Remove(AIObject p)
    {
        if (instance.removeGraph != null)
            instance.removeGraph(p);
    }

    public static void RemoveAll(List<AgentBehaviour> list)
    {
        if (instance.removeGraph != null)
        {
            foreach (var b in list)
                instance.removeGraph(b);
        }
    }

    public static void RemoveAllExcept(AIObject p, List<AgentBehaviour> list)
    {
        if (instance.removeGraph != null)
        {
            foreach (var b in list)
                if(b != p)
                instance.removeGraph(b);
        }
    }
    public static void Show(AIObject p, string title)
    {
        if (instance.updateGraph != null)
            instance.updateGraph(p, title);
    }
}
