using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class choppingTree : MonoBehaviour, IInteractable
{
    int treeHitsLeft = 3;


    Animator animatorController;

    AudioSource woodSound;
    public void Interact()
    {
        if (treeHitsLeft > 0)
        {
            
            woodSound.Play();
            animatorController.SetTrigger("chopping");
            
            treeHitsLeft--;
            if (treeHitsLeft == 0)
            {
                Destroy(gameObject);
                plantsCount.Instance.woodCollected += Random.RandomRange(2, 5);
            }

        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        woodSound = GameObject.Find("woodSound").GetComponent<AudioSource>();
        animatorController = GameObject.Find("camello").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
