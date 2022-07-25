using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject CookingAreaPanel;
    public GameObject GameoverAreaPanel;
    public GameObject GamestartAreaPanel;
    // Start is called before the first frame update
    public static UIController Instance { get; private set; }

    public void turnOffGamestartArea()
    {
        Instance.GamestartAreaPanel.SetActive(false);
    }
    public void turnOffCookingArea()
    {
        Instance.CookingAreaPanel.SetActive(false);
    }
    public void turnOffGameoverAreaPanel()
    {
        Instance.GameoverAreaPanel.SetActive(false);
    }
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
        turnOffCookingArea();
        turnOffGameoverAreaPanel();
    }
}
