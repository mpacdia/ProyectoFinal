using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerForOutline : MonoBehaviour
{
    public BoxCollider camelArea;

    // Start is called before the first frame update
    void Start()
    {
        camelArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cropZone")
    }
}
