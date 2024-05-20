using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropingZonePrefab : MonoBehaviour, IInteractable
{
    int cropState = 0;

    GameObject cropState1;
    GameObject cropState2;
    GameObject cropState3;

    public void Interact()
    {
        if (cropState == 0)
        {
            GameObject crop = Instantiate(cropState1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cropState1 = GameObject.Find("cultivoEtapa1");
        cropState2 = GameObject.Find("cultivoEtapa2");
        cropState3 = GameObject.Find("cultivoEtapa3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
