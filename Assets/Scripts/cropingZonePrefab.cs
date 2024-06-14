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

    plantsCount plantsCount;

    GameObject sun;
    dayNightCycle dayNightCycle;

    AudioSource plantingSound;

    public void Interact()
    {
        if (cropState == 0)
        {
            GameObject crop = Instantiate(cropState1, transform.position, Quaternion.identity);
            cropState = 1;
            instantiatedOnce = true;
            plantsCount.Instance.growingPlants++;

        }

        if (cropState == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("cropState3"));
            cropState = 0;
            instantiatedOnce = false;
            instantiatedTwice = false;
            instantiatedThrice = false;

            plantsCount.Instance.harvestedPlants++;
            plantsCount.Instance.growingPlants--;
            plantingSound.Play();

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("sun");
        dayNightCycle = sun.GetComponent<dayNightCycle>();

        plantingSound = GameObject.Find("plantsSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         

        
    }

    public void changeDay()
    {
        // �cual es mi cropSytate?
        if (cropState == 1 && instantiatedOnce == true && instantiatedTwice == false)
        { 
            Destroy(GameObject.FindGameObjectWithTag("cropState1"));
            GameObject crop = Instantiate(cropState2, transform.position, Quaternion.identity);
            instantiatedTwice = true;
            cropState = 2;
            
        }

        else if (cropState == 2 && instantiatedTwice == true && instantiatedThrice == false)
        {
            Destroy(GameObject.FindGameObjectWithTag("cropState2"));
            GameObject crop = Instantiate(cropState3, transform.position, Quaternion.identity);
            instantiatedThrice = true;
            cropState = 3;
            
            
        }
    }
}
