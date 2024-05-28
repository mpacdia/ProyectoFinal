using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerForOutline : MonoBehaviour
{
    public BoxCollider areaCropZone;
    public Outline outlineScript;

    // Start is called before the first frame update
    void Start()
    {
        areaCropZone = GetComponent<BoxCollider>();
        outlineScript = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "camel")
        {
            Debug.Log(gameObject.name + "enter");
            outlineScript.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "camel")
        {
            Debug.Log(gameObject.name + "exit");
            outlineScript.enabled = false;
        }
    }
}
