using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    PlayerInput playerInput;

    Animator animatorController;

    public Vector2 read;

    bool rotating;

    bool paused = false;

    public int lifeLeft = 4;
    public GameObject heart1, heart2, heart3, heart4;

    public GameObject lifesPanel, youDiedPanel, pauseMenu;

    public static PlayerMovement Instance
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
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animatorController = GetComponent<Animator>();
    }
    public void toMovePlayer(InputAction.CallbackContext context)
    {
        Vector2 readVector = context.action.ReadValue<Vector2>();

        rb.velocity = readVector;
    }

    
    

    public void smoke(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            animatorController.SetTrigger("smoke");
            lifeLeft--; 
        }        
    }

    public void pauseGame(InputAction.CallbackContext context)
    {
        if (context.started && !paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else if (context.started && paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (lifeLeft == 3)
        {
           heart4.GetComponent<Image>().color = Color.black;
            lifesPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.25f);
        }
        if(lifeLeft == 2)
        {
           heart3.GetComponent<Image>().color = Color.black;
            lifesPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);

        }
        if (lifeLeft == 1)
        {
            heart2.GetComponent<Image>().color = Color.black;
            lifesPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.75f);

        }
        if (lifeLeft == 0)
        {
            heart1.GetComponent<Image>().color = Color.black;
            lifesPanel.SetActive(false);
            youDiedPanel.SetActive(true);
        }


        read = playerInput.actions["move"].ReadValue<Vector2>();

        Vector3 fwd = Camera.main.transform.forward * read.y * 5; /// eje z ajustado a la camara
        Vector3 right = Camera.main.transform.right * read.x * 5; /// eje x ajustado a la camara
        Vector3 final = fwd + right;
        final.y = 0;
        rb.velocity = new Vector3(final.x, rb.velocity.y, final.z);

        if (rb.velocity.magnitude > 0.5f)
        {
            animatorController.SetBool("moving", true);
        }
        else
        {
            animatorController.SetBool("moving", false);
        }

        rotating = playerInput.actions["rotate"].IsPressed();
        if (rotating) transform.Rotate(Vector3.up * playerInput.actions["rotate"].ReadValue<float>(), 24 * Time.deltaTime);
    }

    public void dePause()
    {
        paused = false;
    }
}
