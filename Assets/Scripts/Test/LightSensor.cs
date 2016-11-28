using UnityEngine;
using System.Collections;

public class LightSensor : MonoBehaviour
{
    public float Light {
        get {
            float val = 0;
            foreach (var obj in FindObjectOfType<Room>().AllObjects)
            {
                var light = obj.GetComponent<LightSource>();
                if (light != null && light.LitUp)
                {
                    float sqrDistance = (transform.position - light.transform.position).sqrMagnitude;
                    float lightResult = light.Brightness / (1+sqrDistance);
                    val += lightResult;
                }
            }
            return val;
        }
    }
}
