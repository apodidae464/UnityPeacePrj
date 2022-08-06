using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance { get; private set; }

    public GameObject uiFade;

    public int numOfCustommer = 0;
    public int point;

    public float waitToLoad = 1;
    private bool shouldLoadAfterFade;
    private string nextScene;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        uiFade.SetActive(false);
    }

    private void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                UIFade.instance.FadeFromBlack();
                LoadNextScene(nextScene);
            }
        }
    }

    public void ActiveFade()
    {
        uiFade.SetActive(true);
    }

    public void PrepareLoadNextScene(string scene)
    {
        ActiveFade();
        UIFade.instance.FadeToBlack();
        shouldLoadAfterFade = true;
        nextScene = scene;
    }

    public void LoadNextScene(string scene)
    {
        GameEvents.instance.AlertNextLevel();
        SceneManager.LoadScene(scene);
    }

    public void Restart()
    {
        point = 0;
        GameEvents.instance.AlertResetGame();
        GameEvents.isPause = false;
        GameEvents.isStart = false;
        Player.instance.point = 0;
        Player.instance.ResetInventory();
        SceneManager.LoadScene("Start");
    }

    public void ExitProgram()
    {
        Application.Quit();
    }

   
}