using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Metrics : MonoBehaviour
{
    public Dictionary<string, List<Metric>> Dictionary = new Dictionary<string, List<Metric>>();
    StringBuilder builder = new StringBuilder();
    public float Value(string metricCategory, GameObject other)
    {
        builder.Length = 0;
        builder.Append(gameObject.name).Append("metric=").Append(metricCategory).AppendLine();
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
                var metricValue = metric.OtherFilterFull() ? metric.Value() : 0f;
                builder.Append(metric.GetType().Name).Append("=").Append(metricValue).Append(" ; ");
                result += metricValue;
                metric.Other = cachedOther;
                metric.Root = cachedRoot;
            }
            Debug.Log(builder.ToString());
            return result;
        }
        Debug.Log(builder.ToString());
        return 0f;
    }

    public float Weight(string metricCategory, GameObject other)
    {
        builder.Length = 0;
        builder.Append(gameObject.name).Append("weighted metric=").Append(metricCategory).AppendLine();
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
                var metricValue = metric.OtherFilterFull() ? metric.Value()  *metric.Meta.Weight : 0f;
                builder.Append(metric.GetType().Name).Append("=").Append(metricValue).Append(" ; ");
                result += metricValue;
                metric.Other = cachedOther;
                metric.Root = cachedRoot;
            }
            Debug.Log(builder.ToString());
            return result;
        }
        Debug.Log(builder.ToString());
        return 0f;
    }
}