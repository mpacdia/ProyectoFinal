using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject credits;
    public GameObject pauseMenu;

    GameObject player;
    GameObject sun;

    // Start is called before the first frame update
    void Start()
    {
        if (buttons)
        {
            buttons.SetActive(true);
        }
        if (credits)
        {
            credits.SetActive(false);
        }
        player = GameObject.FindGameObjectWithTag("camel");
        sun = GameObject.Find("sun");

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        
        loadGame();
    }

    public void loadGame()
    {
        SceneManager.LoadScene("mainGame");
        sun.transform.rotation = Quaternion.identity;
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
        Time.timeScale = 1;
        
    }
    
    public void saveAndExit()
    {
        player = GameObject.FindGameObjectWithTag("camel");
        PlayerPrefs.SetInt("harvested", plantsCount.Instance.harvestedPlants);
        PlayerPrefs.SetInt("growing", plantsCount.Instance.growingPlants);
        PlayerPrefs.SetInt("wood", plantsCount.Instance.woodCollected);
        PlayerPrefs.SetFloat("positionX", player.transform.position.x);
        PlayerPrefs.SetFloat("positionY", player.transform.position.y);
        PlayerPrefs.SetFloat("positionZ", player.transform.position.z);
        PlayerPrefs.Save();
        SceneManager.LoadScene("titleScreen");
        Time.timeScale = 1;
        
    }

    public void letsContinue()
    {
        pauseMenu.SetActive(false);
        PlayerMovement.Instance.dePause();
        Time.timeScale = 1;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (scene.name == "mainGame")
        {
            player = GameObject.FindGameObjectWithTag("camel");
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), PlayerPrefs.GetFloat("positionZ"));
            Debug.Log(player.name);
            plantsCount.Instance.harvestedPlants = PlayerPrefs.GetInt("harvested", 0);
            plantsCount.Instance.growingPlants = PlayerPrefs.GetInt("growing", 0);
            plantsCount.Instance.woodCollected = PlayerPrefs.GetInt("wood");
        }
    }
}
