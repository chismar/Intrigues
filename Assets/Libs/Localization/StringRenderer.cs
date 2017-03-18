using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
public class StringRenderer : Root<StringRenderer>
{
    Dictionary<string, string> localisation = new Dictionary<string, string>();
    StringBuilder builder = new StringBuilder();
    ObjectPool<StringBuilder> builders = new ObjectPool<StringBuilder>();
    public string Render(GameObject from, string value, Dictionary<string, object> values)
    {
        //foreach (var v in values)
        //    Debug.Log(v.Key + " " + v.Value);
        string localString = null;
        
        if (!localisation.TryGetValue(value, out localString))
        {
            Debug.Log("Can't find loc string: " + value);
            return value;
        }
        if (!values.ContainsKey("from"))
            values.Add("from", from);
        else
            values["from"] = from;
        builder = builders.Get();
        builder.Length = 0;
        try
        {
            for (int i = 0; i < localString.Length; i++)
            {
                if (localString[i] != '{')
                {
                    builder.Append(localString[i]);
                }
                else
                {
                    Substitute(from, builder, localString, i, out i, values);
                }
            }
        }
        catch(System.Exception e)
        {
            Debug.LogWarning(builder.ToString());
            Debug.LogException(e);
        }
        var renderedString = builder.ToString();
        builders.Return(builder);
        return renderedString;
    }
    void Substitute(GameObject from, StringBuilder builder, string localString, int index, out int outIndex, Dictionary<string, object> values)
    {
        
        StringBuilder subBuilder = builders.Get();
        subBuilder.Length = 0;
        char c = '{';
        bool toUpperFirst = false;
        int firstCharIndex = -1;
        if(localString[index + 1] == '@')
        {
            //first letter to upper
            index++;
            toUpperFirst = true;
            firstCharIndex = builder.Length;
        }
        while (c != '}')
            subBuilder.Append(c = localString[++index]);
        subBuilder.Length -= 1;
        outIndex = index;
        List<string> scope = new List<string>();
        var subScopeBuilder = builders.Get();
        subScopeBuilder.Length = 0;
        for ( int i = 0; i < subBuilder.Length; i++)
        {
            c = subBuilder[i];
            if (c == '.')
            {
                scope.Add(subScopeBuilder.ToString());
                subScopeBuilder.Length = 0;
            }
            else
                subScopeBuilder.Append(c);
        }
        scope.Add(subScopeBuilder.ToString());
        builders.Return(subScopeBuilder);
        builders.Return(subBuilder);
        //Debug.LogWarning("Scope: " + scope[0]);
        if(tagsByType.ContainsKey(scope[0]))
        {
            var tags = tagsByType[scope[0]];
            //Debug.LogWarning(tags.Count);
            //Debug.LogWarning(scope[1]);
            LocalisationTag maxTag = null;
            float maxUt = 0;
                for (int i =0; i < tags.Count;i++)
                {
                    var tag = tags[i];
                    var cachedRoot = tag.Root;
                    var cachedFrom = tag.From;
                    tag.Root = scope.Count == 1 ? from : (values.TryGet(scope[1]) as GameObject);
                    tag.From = from;
                    if(tag.Filter())
                    {
                        var ut = tag.Utility();
                        if(ut > maxUt)
                        {
                            maxUt = ut;
                            maxTag = tag;
                        }
                    }
                    tag.Root = cachedRoot;
                    tag.From = cachedFrom;
                }
                if(maxTag != null)
                {
                    var cachedRoot = maxTag.Root;
                    var cachedFrom = maxTag.From;
                    maxTag.Root = scope.Count == 1 ? from : (values.TryGet(scope[1]) as GameObject);
                    maxTag.From = from;
                    var val = maxTag.Value();
                    Debug.Log("Tag: " + scope[0]);
                    builder.Append(val);
                    maxTag.Root = cachedRoot;
                    maxTag.From = cachedFrom;
                
                }
        }
        else
        {
            object providedValue = null;
            if(values.TryGetValue(scope[0], out providedValue))
            {
                SubstituteValue(builder, 1, scope, providedValue);
            }
            else
            {
                //error
            }
        }
        try
        {
            if (/*no error and*/ toUpperFirst)
            {
                builder[firstCharIndex] = char.ToUpper(builder[firstCharIndex]);
            }
        }
        catch(System.Exception e)
        {
            Debug.LogWarning(e);
        }
        
    }

    void SubstituteValue(StringBuilder builder, int index, List<string> scope, object value)
    {
        var type = value.GetType();
        if(type == typeof(GameObject))
        {
            if(scope.Count > index)
            {
                var go = value as GameObject;
                var component = go.GetComponent(scope[++index]);
                if(component == null)
                {
                    //error
                }
                else
                {
                    SubstituteValue(builder, index, scope, component);
                }
            }
            else
                builder.Append(value);
        }
        else if(type == typeof(float))
        {
            builder.Append(value);
            if(index == scope.Count)
            {
                //issue warning
            }
        }
        else if(type == typeof(int))
        {
            builder.Append(value);
            if (index > scope.Count)
            {
                //issue warning
            }
        }
        else if (type == typeof(bool))
        {
            builder.Append(value);
            if (index > scope.Count)
            {
                //issue warning
            }
        }
        else if(type == typeof(string))
        {
            builder.Append(value);
            if (index > scope.Count)
            {
                //issue warning
            }
        } else
        {
            if(scope.Count > index)
            {
                var propInfo = type.GetProperty(scope[++index]);
                if(propInfo != null)
                {

                    var propValue = propInfo.GetValue(value, null);
                    SubstituteValue(builder, index, scope, propValue);
                }
                else
                {
                    //error
                }
            }
            else
                builder.Append(value);
        }
    }
    private void Awake()
    {
        base.Awake();
        FindObjectOfType<BasicLoader>().Loaded += OnLoad;
        
    }
    Dictionary<string, List<LocalisationTag>> tagsByType = new Dictionary<string, List<LocalisationTag>>();
    void OnLoad()
    {
        var files = Directory.GetFiles((BasicLoader.IsInEditor ? "Assets/" : BasicLoader.ProjectPrefix + "_Data/") + "StreamingAssets/Mods/Localisation", "*.def");
        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                for (int i = 0; i < parts.Length; i++)
                    parts[i] = parts[i].Trim(' ');
                localisation.Add(parts[0], parts[1]);
                Debug.LogFormat("LOC: {0} - {1}", parts[0], parts[1]);
            }

        }
        var engine = FindObjectOfType<BasicLoader>().Engine;
        var types = engine.FindTypesWithAttribute<LocalisationTagAttribute>();
        Debug.Log("Tags count: " + types.Count);
        foreach(var typePair in types)
        {
            
            var tag = System.Activator.CreateInstance(typePair.Type) as LocalisationTag;
            var type = typePair.Attribute.Type;
            var list = tagsByType.Get(type);
            list.Add(tag);
            Debug.LogFormat("Tag loaded: {0} to {1}", typePair.Type.Name, type);
        }
    }

}
