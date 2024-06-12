using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plantsCount : MonoBehaviour
{
    TMP_Text harvested;
    TMP_Text growing;
    TMP_Text wood;


    public int harvestedPlants = 0;
    public int growingPlants = 0;
    public int woodCollected = 0;
    public static plantsCount Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        harvested = GameObject.Find("harvestedText").GetComponent<TMP_Text>();
        growing = GameObject.Find("growingText").GetComponent<TMP_Text>();
        wood = GameObject.Find("woodText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        harvested.text = "Harvested:" + harvestedPlants.ToString();
        growing.text = "Growing:" + growingPlants.ToString();
        wood.text = "Wood:" + woodCollected.ToString();
    }
}
