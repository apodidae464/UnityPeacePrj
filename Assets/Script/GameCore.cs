using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance { get; private set; }
    public int numOfCustommer = 0;


   

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

    }

    private void Update()
    {
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }

    public void ExitProgram()
    {
        Application.Quit();
    }

    public void OnClickPopuOnClickonPopupInCustomer(GameObject Customer)
    {
        Customer.GetComponent<Customer>().OnClickonPopupInCustomer();
    }

}