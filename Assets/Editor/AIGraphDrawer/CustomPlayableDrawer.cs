using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.Experimental.Director;

namespace AIVisualizer
{

    // Example of how to implement a custom drawing method for a specific playable type
    // as part of the Graph Visualizer tool.
    [CustomPlayableDrawer(typeof(PrimitiveAgentBehaviour))]
    public class PrimitiveDrawer
    {
        public static void OnGUI(Rect position, AIObject p)
        {
            
            var obj = p as PrimitiveAgentBehaviour;
            if (obj == null)
                return;
            string msg = "Primitive\n{0}\nB: {1}\nT: {2}".Fmt(obj.Task, obj.State, obj.Task.State);
            GUIStyle nodeStyle = null;
            switch (obj.State)
            {
                case BehaviourState.None:
                    nodeStyle = new GUIStyle("flow node 4");
                    break;
                case BehaviourState.Finished:
                    nodeStyle = new GUIStyle("flow node 6");
                    break;
                default:
                    nodeStyle = new GUIStyle("flow node 1");
                    break;
            }


            Vector2 sizeNeeded = nodeStyle.CalcSize(new GUIContent(msg));
            //if (sizeNeeded.x < position.width && sizeNeeded.y < position.height)
                GUI.Label(position, msg, nodeStyle);
            //else
            //    GUI.Label(position, "", nodeStyle);
        }
    }
    [CustomPlayableDrawer(typeof(ComplexAgentBehaviour))]
    public class ComplexDrawer
    {
        public static void OnGUI(Rect position, AIObject p)
        {
            var obj = p as ComplexAgentBehaviour;
            if (obj == null)
                return;
            string msg =  "Complex\n{0}\nB: {1}\nT: {2}".Fmt(obj.Task, obj.State, obj.Task.State);
            GUIStyle nodeStyle = null;
            switch (obj.State)
            {
                case BehaviourState.None:
                    nodeStyle = new GUIStyle("flow node 4");
                    break;
                case BehaviourState.Finished:
                    nodeStyle = new GUIStyle("flow node 6");
                    break;
                default:
                    nodeStyle = new GUIStyle("flow node 1");
                    break;
            }

            Vector2 sizeNeeded = nodeStyle.CalcSize(new GUIContent(msg));
            //if (sizeNeeded.x < position.width && sizeNeeded.y < position.height)
                GUI.Label(position, msg, nodeStyle);
            //else
            //    GUI.Label(position, "", nodeStyle);
        }
    }
    [CustomPlayableDrawer(typeof(TaskWrapper))]
    public class WrapperDrawer
    {
        public static void OnGUI(Rect position, AIObject p)
        {
            var obj = p as TaskWrapper;
            if (obj == null)
                return;

            string msg = null;
            var ser = obj.Serialized;
            if(obj.Root != null)
            if (ser != null)
                msg = ser.Render(obj.Root);
            else
                msg = obj.GetType().Name;
            GUIStyle nodeStyle = null;
            switch (obj.Behaviour.State)
            {
                case BehaviourState.None:
                    nodeStyle = new GUIStyle("flow node 4");
                    break;
                case BehaviourState.Finished:
                    nodeStyle = new GUIStyle("flow node 6");
                    break;
                default:
                    nodeStyle = new GUIStyle("flow node 1");
                    break;
            }

            Vector2 sizeNeeded = nodeStyle.CalcSize(new GUIContent(msg));
            //if (sizeNeeded.x < position.width && sizeNeeded.y < position.height)
            GUI.Label(position, msg, nodeStyle);
            //else
            //    GUI.Label(position, "", nodeStyle);
        }
    }
    // Defines a new type of attribute for identifying custom node visualization nodes
    // Every class marked as a playable drawer must implement the OnGUI(Rect, Playable) method
    public class CustomPlayableDrawer : Attribute
    {
        public Type m_Type;

        public CustomPlayableDrawer(Type type)
        {
            m_Type = type;
        }
    }
}