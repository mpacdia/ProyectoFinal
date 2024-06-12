using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject credits;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNewGame()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void openCredits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }
    
    public void closeCredits()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }

    public void exit()
    {
        SceneManager.LoadScene("titleScreen");
    }

    public void letsContinue()
    {
        pauseMenu.SetActive(false);
        PlayerMovement.Instance.dePause();
        Time.timeScale = 1;
    }
}
