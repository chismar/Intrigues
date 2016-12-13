using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

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

    StringBuilder builder = new StringBuilder();
    public void InitMetrics(GameObject go)
    {
        builder.Length = 0;
        builder.Append("METRICS FOR: ");
        builder.AppendLine(go.name);
        Metrics metricsCmp = go.GetComponent<Metrics>();
        if (metricsCmp == null)
            return;
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
            {
                metricsCmp.Dictionary.Add(cat.Key, list);
                builder.AppendLine(cat.Key);
                foreach (var metric in list)
                {
                    builder.Append("  ").AppendLine(metric.GetType().Name);
                }
            }
        }
        Debug.Log(builder.ToString());
    }
}
