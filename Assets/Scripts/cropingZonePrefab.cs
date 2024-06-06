using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropingZonePrefab : MonoBehaviour, IInteractable
{
    public int cropState = 0;

    public GameObject cropState1;
    public GameObject cropState2;
    public GameObject cropState3;

    bool instantiatedOnce = false;
    bool instantiatedTwice = false;

    GameObject sun;
    dayNightCycle dayNightCycle;
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
        dayNightCycle = sun.GetComponent<dayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
         

        if (dayNightCycle.CurrentDay == 1 && instantiatedOnce == false)
        { 
            Destroy(GameObject.FindGameObjectWithTag("cropState1"));
            GameObject crop = Instantiate(cropState2, transform.position, Quaternion.identity);
            instantiatedOnce = true;
        }

        if (dayNightCycle.CurrentDay == 2 && instantiatedTwice == false)
        {
            Destroy(GameObject.FindGameObjectWithTag("cropState2"));
            GameObject crop = Instantiate(cropState3, transform.position, Quaternion.identity);
            instantiatedTwice = true;
        }
    }
}
