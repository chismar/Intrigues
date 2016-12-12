using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MetricsManager : Root<MetricsManager>
{
    private void Awake()
    {
        base.Awake();

        FindObjectOfType<BasicLoader>().Loaded += OnLoad;
    }
    Dictionary<string, List<Metric>> metrics = new Dictionary<string, List<Metric>>();
    void OnLoad()
    {
        var engine = FindObjectOfType<BasicLoader>().Engine;
        var metricsTypes = engine.FindTypesCastableTo<Metric>();
        foreach ( var type in metricsTypes)
        {
            var metric = Activator.CreateInstance(type) as Metric;

            var metricMeta = type.GetCustomAttributes(typeof(MetricAttribute), false)[0] as MetricAttribute;
            metric.Meta = metricMeta;
            
            var categories = type.GetInterfaces();
            if (categories.Length == 1)
            {
                metric.Meta.Category = categories[0].Name;
                List<Metric> metricsList = null;
                if(!metrics.TryGetValue(metric.Meta.Category, out metricsList))
                {
                    metricsList = new List<Metric>();
                    metrics.Add(metric.Meta.Category, metricsList);
                }
                metricsList.Add(metric);
            }

        }
    }


    public void InitMetrics(Metrics metricsCmp)
    {
        
        foreach (var cat in metrics)
        {
            List<Metric> list = new List<Metric>();
            foreach ( var metric in cat.Value)
            {
                metric.Root = metricsCmp.gameObject;
                if (metric.RootFilter())
                    list.Add(metric);
            }
            if (list.Count > 0)
                metricsCmp.Dictionary.Add(cat.Key, list);
        }
    }
}

public class Metrics : MonoBehaviour
{
    public Dictionary<string, List<Metric>> Dictionary = new Dictionary<string, List<Metric>>();

    public float Value(string metricCategory, GameObject other)
    {
        List<Metric> catMetrics = null;
        if(Dictionary.TryGetValue(metricCategory, out catMetrics))
        {
            float result = 0f;
            foreach ( var metric in catMetrics)
            {
                var cachedOther = metric.Other;
                var cachedRoot = metric.Root;
                metric.Other = other;
                metric.Root = gameObject;
                result += metric.OtherFilterFull()?metric.Value():0f;
                metric.Other = cachedOther;
                metric.Root = cachedRoot;
            }
        }
        return 0f;
    }

    public float Weight(string metricCategory, GameObject other)
    {
        List<Metric> catMetrics = null;
        if (Dictionary.TryGetValue(metricCategory, out catMetrics))
        {
            float result = 0f;
            foreach (var metric in catMetrics)
            {
                var cachedOther = metric.Other;
                var cachedRoot = metric.Root;
                metric.Other = other;
                metric.Root = gameObject;
                result += metric.OtherFilterFull() ? metric.Value() * metric.Meta.Weight: 0f;
                metric.Other = cachedOther;
                metric.Root = cachedRoot;
            }
        }
        return 0f;
    }
}