using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycle : MonoBehaviour
{
    private int currentDay;

    public int CurrentDay
    {
        get { return currentDay; }
        set { currentDay = value; }
    }


    bool daytime;
    public float timeSpeed = 1f;

    float rotationSun = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentDay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * timeSpeed * Time.deltaTime);

        rotationSun = transform.rotation.x;

        if (rotationSun > 0 && rotationSun < 180)
        {
            daytime = true;
        }
        else if (rotationSun >= -180 && rotationSun <= 0)
        {
            daytime = false;
        }
        if (rotationSun > -0.00003 & rotationSun < 0.00003f)
        {
            Debug.Log("oof");
            currentDay++;
        }
        Debug.Log("rotation:" + rotationSun + "," + "currentDay:" + currentDay + "daytime:" + daytime);
    }
}
