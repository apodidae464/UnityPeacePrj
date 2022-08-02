﻿using UnityEngine;

public class UIController : MonoBehaviour
{

    public static UIController íntance { get; private set; }

    public GameObject CookingAreaPanel;
    public GameObject GameoverAreaPanel;
    public GameObject GamestartAreaPanel;

    private bool isOver;

    private void Awake()
    {
        if (íntance != null && íntance != this)
        {
            Destroy(this);
        }
        else
        {
            íntance = this;
        }
    }


    private void Start()
    {
        GameEvents.isStart = true;
        isOver = false;
        turnOffCookingArea();
        turnOffGameoverAreaPanel();

        GameEvents.instance.alertOver += setOver;
        GameEvents.instance.cookingAreaMenu += TriggerCookingPopup;
    }

    private void Update()
    {
        if(isOver)
        {
            GameoverAreaPanel.SetActive(true);
            //do st
        }
    }

    // Start is called before the first frame update

    public void turnOffGamestartArea()
    {
        íntance.GamestartAreaPanel.SetActive(false);
    }

    public void turnOffCookingArea()
    {
        íntance.CookingAreaPanel.SetActive(false);
    }

    public void turnOffGameoverAreaPanel()
    {
        íntance.GameoverAreaPanel.SetActive(false);
    }

    public void TriggerCookingPopup()
    {
        CookingAreaPanel.SetActive(true);
    }
  
    public void setOver()
    {
        isOver = true;
    }

    private void OnDestroy()
    {
        GameEvents.instance.alertOver -= setOver;
        GameEvents.instance.cookingAreaMenu -= TriggerCookingPopup;

    }
}