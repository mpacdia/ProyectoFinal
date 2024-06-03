using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropingZonePrefab : MonoBehaviour, IInteractable
{
    int cropState = 0;

    public GameObject cropState1;
    public GameObject cropState2;
    public GameObject cropState3;

    GameObject sun;

    public void Interact()
    {
        if (cropState == 0)
        {
            GameObject crop = Instantiate(cropState1, transform.position, Quaternion.identity);
            cropState++;
        }

        if (cropState == 3)
        {
            Destroy(cropState3);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("sun");
    }

    // Update is called once per frame
    void Update()
    {
        cropState = sun.GetComponent<dayNightCycle>().CurrentDay;

        if (cropState == 1)
        { 
            Destroy(GameObject.FindGameObjectWithTag("cropState1"));
            GameObject crop = Instantiate(cropState2, transform.position, Quaternion.identity);
        }
        
        if (cropState == 2)
        { 
            Destroy(GameObject.FindGameObjectWithTag("cropState2"));
            GameObject crop = Instantiate(cropState3, transform.position, Quaternion.identity);
        }
    }
}
