using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour, IInteractable
{
    GameObject sun;

    dayNightCycle dayNightCycle;
    public GameObject loadingpanel;
    public void Interact()
    {
        sun.transform.rotation = Quaternion.identity;
        dayNightCycle.changeDay();
        loadingpanel.SetActive(true);
        waiter();
        loadingpanel.SetActive(false);
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

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(2);

    }
    
}
