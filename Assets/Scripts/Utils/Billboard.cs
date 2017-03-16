using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    
    void Update()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        
    }

    

}
