﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CustommerSpammer : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CustomerSpam());
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void spawnCustomer()
    {

        bool isCreate = true;


        if (GameCore.Instance._CustomerList.Count >= GameCore.Instance._tableList.Count) GameCore.Instance.isListTableFull = true;
        if (GameCore.Instance._CustomerList.Count < GameCore.Instance._tableList.Count)
            GameCore.Instance.isListTableFull = false;

        if (GameCore.Instance.isListTableFull == false)
        {
            do
            {
                int randomTable = Random.Range(0, GameCore.Instance._tableList.Count);
                if (GameCore.Instance._tableList[randomTable].isFull != true)
                {
                    GameObject a = Instantiate(GameCore.Instance._Customer) as GameObject;
                    a.name = "customer" + randomTable.ToString() /*+ (GameCore.Instance._CustomerList.Count + 1).ToString()*/;
                    a.transform.position = GameCore.Instance._tableList[randomTable].transform.GetChild(0).gameObject.transform.position;
                    GameCore.Instance._CustomerList.Add(a);
                    GameCore.Instance._tableList[randomTable].isFull = true;
                    isCreate = true;
                }
                else
                {
                    isCreate = false;
                }
            }
            while (!isCreate);
        }

    }

    private IEnumerator CustomerSpam()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameCore.Instance.respawnTime);
            spawnCustomer();
        }
    }
}


