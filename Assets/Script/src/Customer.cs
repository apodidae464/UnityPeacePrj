﻿using System.Collections;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public FoodData.FoodType PlayerOrderFood = new FoodData.FoodType();
    public GameObject OrderPopup;
    private bool isTakenOrder = false;

    private bool canTrigger;
    private void Awake()
    {
    }

    private void Start()
    {
        this.transform.Find("FirstPopup").gameObject.SetActive(false);
        this.transform.Find("EndPopup").gameObject.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());
        StartCoroutine(ReduceHealthCoroutine());

        int randomOrderPopup = Random.Range(0, GameCore.Instance._FoodPopUpList.Count);
        OrderPopup = Instantiate(GameCore.Instance._FoodPopUpList[randomOrderPopup]) as GameObject;
        //OrderPopup.name = GameCore.Instance._FoodPopUpList[randomOrderPopup].GetComponent<Popup>()._foodType.name;
        OrderPopup.transform.SetParent(this.transform);
        OrderPopup.transform.position = this.transform.Find("FirstPopup").transform.position;
        OrderPopup.SetActive(false);

        PlayerOrderFood.name = GameCore.Instance._FoodPopUpList[randomOrderPopup].GetComponent<Popup>()._foodType.name;
        GameEvents.instance.fistPopup += TriggerFirstPopup;
    }

    public void OnClickonPopupInCustomer()
    {
        if (!canTrigger)
            return;
        OrderPopup.SetActive(false);
        isTakenOrder = true;
        GameEvents.instance.IncreaseHealBarByCumstomer();
    }

    private void Update()
    {
        if (isTakenOrder)
        {
            StartCoroutine(ShowEndPopupCoroutine());
        }

    }

    private IEnumerator ShowFirstPopupCoroutine()
    {
        yield return new WaitForSeconds(3);
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(true);
    }

    private IEnumerator ShowEndPopupCoroutine()
    {
        this.transform.Find("EndPopup").transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);

        GameCore.Instance.RemoveCustomerinArr(gameObject);
        Destroy(gameObject);
        yield return new WaitForSeconds(3);
    }

    private IEnumerator ReduceHealthCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameEvents.instance.DecreaseHealBarByCustomer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Constaint.Player)
        {
            canTrigger = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constaint.Player)
        {
            canTrigger = false;
        }
    }

    private void TriggerFirstPopup()
    {
        if (!canTrigger)
            return;
        Debug.Log("I'm hitting first popup");
        gameObject.transform.Find("FirstPopup").gameObject.SetActive(false);
        gameObject.GetComponent<Customer>().OrderPopup.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.instance.fistPopup -= TriggerFirstPopup;

    }
}