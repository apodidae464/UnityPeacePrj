﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance { get; private set; }
    public List<GameObject> _FoodPopUpList;
    public int numOfCustommer = 0;
    public GameObject[] _CustomerArr;
    public List<Table> _tableList;
    public bool[] istableFull;
    public Transform[] _tableTranformArr;
    public GameObject _CustomerPopup;
    public GameObject _Customer;
    public FoodData foodData;
    public bool isListTableFull = false;
    public float respawnTime = 2.0f;
    public HealthBar HealthBar;
    public GameObject Spamcustomer;

    public float CustomerReduceHealt = 0.05f;
    public float CustomerIncreaseHealt = 1f;

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
        _tableList = new List<Table>();
        _FoodPopUpList = new List<GameObject>();
        Spamcustomer.SetActive(false);
    }

    private void Start()
    {
        isListTableFull = false;
        LoadFoodDatatoList();
        StartCoroutine(LaterStart());
    }

    private void Update()
    {
    }

    public void startSpamCustomer()
    {
        Spamcustomer.SetActive(true);
    }

    public void stopSpamCustomer()
    {
        Spamcustomer.SetActive(false);
    }

    public void RemoveCustomerinArr(GameObject gameObject)
    {
        for (int i = 0; i < numOfCustommer; i++)
        {
            if (gameObject.name == _CustomerArr[i].name)
            {
                Destroy(_CustomerArr[i]);
                istableFull[i] = false;
                break;
            }
        }
        numOfCustommer--;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }

    public void ExitProgram()
    {
        Application.Quit();
    }

    private void LoadFoodDatatoList()
    {
        foreach (var foodType in foodData.FoodTypeList)
        {
            var foodTypeData = foodData.FoodTypeList.Find(data => data == foodType);
            _FoodPopUpList.Add(Instantiate(_CustomerPopup));
            _FoodPopUpList[_FoodPopUpList.Count - 1].name = _FoodPopUpList[_FoodPopUpList.Count - 1].name /*+ (_FoodPopUpList.Count).ToString()*/;
            _FoodPopUpList[_FoodPopUpList.Count - 1].SetActive(false);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Popup>().SetData(foodTypeData);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Transform>().position = new Vector3(Screen.width, Screen.height, 0f);
        }
    }

    private IEnumerator LaterStart()
    {
        yield return new WaitForSeconds(0.5f);
        _CustomerArr = new GameObject[_tableList.Count];
        _tableTranformArr = new Transform[_tableList.Count];
        for (int i = 0; i < _tableList.Count; i++)
        {
            _tableTranformArr[i] = _tableList[i].transform;
        }
        istableFull = new bool[_tableList.Count];
        for (int i = 0; i < _tableList.Count; i++)
        {
            istableFull[i] = false;
        }
    }
}