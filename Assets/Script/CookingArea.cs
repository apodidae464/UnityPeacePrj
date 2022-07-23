using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingArea : MonoBehaviour
{
    public static CookingArea Instance { get; private set; }

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

    public GameObject CookingAreaPanel;

    Transform Transform0;
    Transform Transform1;
    Transform Transform2;
    Transform Transform3;

    public FoodData foodData;
    public GameObject foodObj;

    int numFoodGameObjects = 0;
    static GameObject[] FoodGameObjects = new GameObject[4];
    static bool[] isObjectFull = new bool[] { false, false, false, false };
    static Transform[] FoodTranformsList = new Transform[4];


    void Start()
    {
        turnOffCookingArea();

        Instance.Transform0 = Instance.transform.Find("ListInventory").transform.GetChild(0).transform;
        Instance.Transform1 = Instance.transform.Find("ListInventory").transform.GetChild(1).transform;
        Instance.Transform2 = Instance.transform.Find("ListInventory").transform.GetChild(2).transform;
        Instance.Transform3 = Instance.transform.Find("ListInventory").transform.GetChild(3).transform;

        FoodTranformsList[0] = Instance.Transform0;
        FoodTranformsList[1] = Instance.Transform1;
        FoodTranformsList[2] = Instance.Transform2;
        FoodTranformsList[3] = Instance.Transform3;
    }

    public void OnClickFoodinCookingArea(GameObject hit)
    {
        Player.Instance.addFoodInInventory(hit);
        int index = int.Parse(hit.name);
        isObjectFull[index] = false;
        Instance.numFoodGameObjects--;
        Destroy(hit);
    }

    void Update()
    {  

    }

    public void turnOffCookingArea()
    {
        Instance.CookingAreaPanel.SetActive(false);
    }

    public void CookFood1()
    {
        if(Instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood1Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood1Coroutine()
    {
        var foodTypeData = Instance.foodData.FoodTypeList.Find(data => data == Instance.foodData.FoodTypeList[0]);
        yield return new WaitForSeconds(1);
        if(Instance.numFoodGameObjects < 4)
        { 
            for (int i = 0; i < 4; i++)
            {
                if (!isObjectFull[i])
                {
                    creatFood(i, foodTypeData);
                    break;
                }

            }

        }


    }

    public void CookFood2()
    {
        if (Instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood2Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood2Coroutine()
    {
        var foodTypeData = Instance.foodData.FoodTypeList.Find(data => data == Instance.foodData.FoodTypeList[1]);
        yield return new WaitForSeconds(1);
        if (Instance.numFoodGameObjects < 4)
        {
            
            for (int i = 0; i < 4; i++)
            {
                if (!isObjectFull[i])
                {
                    creatFood(i, foodTypeData);
                    break;
                }

            }
        }

    }

    public void CookFood3()
    {
        if (Instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood3Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood3Coroutine()
    {
        var foodTypeData = Instance.foodData.FoodTypeList.Find(data => data == Instance.foodData.FoodTypeList[2]);
        yield return new WaitForSeconds(1);
        if (Instance.numFoodGameObjects < 4)
        {
            
            for (int i = 0; i < 4; i++)
            {
                if (!isObjectFull[i])
                {
                    creatFood(i, foodTypeData);
                    break;
                }

            }
        }
    }

    private void creatFood(int index, FoodData.FoodType foodTypeData)
    {
        FoodGameObjects[Instance.numFoodGameObjects] = Instantiate(Instance.foodObj) as GameObject;
        FoodGameObjects[Instance.numFoodGameObjects].name = index.ToString();
        FoodGameObjects[Instance.numFoodGameObjects].transform.SetParent(Instance.transform.Find("ListFood").transform);
        FoodGameObjects[Instance.numFoodGameObjects].SetActive(true);
        FoodGameObjects[Instance.numFoodGameObjects].GetComponent<Food>().SetData(foodTypeData);
        FoodGameObjects[Instance.numFoodGameObjects].GetComponent<Transform>().position = FoodTranformsList[index].position;
        isObjectFull[index] = true;
        Instance.numFoodGameObjects++;
    }


}
