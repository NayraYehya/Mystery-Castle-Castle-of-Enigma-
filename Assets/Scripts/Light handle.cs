using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthandle : MonoBehaviour
{
    public new GameObject light;
    private Light mylight;

    // Start is called before the first frame update
    private void Start()
    {
        mylight = light.GetComponent<Light>();
        mylight.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           mylight.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        mylight.enabled = false;
    }


    
}
