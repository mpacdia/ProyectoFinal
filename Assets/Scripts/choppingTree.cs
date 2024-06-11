using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class choppingTree : MonoBehaviour, IInteractable
{
    int treeHitsLeft = 3;


    Animator animatorController;

   
    public void Interact()
    {
        if (treeHitsLeft > 0)
        {
            

            animatorController.SetTrigger("chopping");
            
            treeHitsLeft--;
            if (treeHitsLeft == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
        animatorController = GameObject.Find("camello").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
