using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cropingZonePrefab : MonoBehaviour, IInteractable
{
    public int cropState = 0;

    public GameObject cropState1;
    public GameObject cropState2;
    public GameObject cropState3;

    public bool instantiatedOnce = false;
    public bool instantiatedTwice = false;
    public bool instantiatedThrice = false;


    GameObject sun;
    dayNightCycle dayNightCycle;
    public void Interact()
    {
        if (cropState == 0)
        {
            GameObject crop = Instantiate(cropState1, transform.position, Quaternion.identity);
            cropState = 1;
            instantiatedOnce = true;
        }

        if (cropState == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("cropState3"));
            cropState = 0;
            instantiatedOnce = false;
            instantiatedTwice = false;
            instantiatedThrice = false;
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
         

        
    }

    public void changeDay()
    {
        // ¿cual es mi cropSytate?
        if (dayNightCycle.CurrentDay >= 1 && instantiatedOnce == true && instantiatedTwice == false)
        { 
            Destroy(GameObject.FindGameObjectWithTag("cropState1"));
            GameObject crop = Instantiate(cropState2, transform.position, Quaternion.identity);
            instantiatedTwice = true;
            if (cropState == 1) cropState = 2;
            else cropState = 1;
        }

        if (dayNightCycle.CurrentDay >= 2 && instantiatedTwice == true && instantiatedThrice == false)
        {
            Destroy(GameObject.FindGameObjectWithTag("cropState2"));
            GameObject crop = Instantiate(cropState3, transform.position, Quaternion.identity);
            instantiatedThrice = true;
            if (cropState == 2) cropState = 3;
            else cropState = 2;
            
        }
    }
}
