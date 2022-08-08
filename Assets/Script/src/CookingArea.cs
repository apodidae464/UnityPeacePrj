using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingArea : MonoBehaviour
{
    public static CookingArea instance { get; private set; }


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

    bool canClickFood;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        instance.Transform0 = instance.transform.Find("ListInventory").transform.GetChild(0).transform;
        instance.Transform1 = instance.transform.Find("ListInventory").transform.GetChild(1).transform;
        instance.Transform2 = instance.transform.Find("ListInventory").transform.GetChild(2).transform;
        instance.Transform3 = instance.transform.Find("ListInventory").transform.GetChild(3).transform;

        FoodTranformsList[0] = instance.Transform0;
        FoodTranformsList[1] = instance.Transform1;
        FoodTranformsList[2] = instance.Transform2;
        FoodTranformsList[3] = instance.Transform3;

        GameEvents.instance.ClickFoodinCookingArea += OnClickFoodinCookingArea;
    }

    public void OnClickFoodinCookingArea(GameObject hit)
    {

        if (!canClickFood)
            return;
        int index = int.Parse(hit.name);
        isObjectFull[index] = false;
        instance.numFoodGameObjects--;
        Destroy(hit);
    }

    void Update()
    {  

    }


    public void CookFood1()
    {
        if(instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood1Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood1Coroutine()
    {
        var foodTypeData = instance.foodData.FoodTypeList.Find(data => data == instance.foodData.FoodTypeList[0]);
        yield return new WaitForSeconds(1);
        if(instance.numFoodGameObjects < 4)
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
        if (instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood2Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood2Coroutine()
    {
        var foodTypeData = instance.foodData.FoodTypeList.Find(data => data == instance.foodData.FoodTypeList[1]);
        yield return new WaitForSeconds(1);
        if (instance.numFoodGameObjects < 4)
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
        if (instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood3Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood3Coroutine()
    {
        var foodTypeData = instance.foodData.FoodTypeList.Find(data => data == instance.foodData.FoodTypeList[2]);
        yield return new WaitForSeconds(1);
        if (instance.numFoodGameObjects < 4)
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

    public void CookFood4()
    {
        if (instance.numFoodGameObjects < 4)
            StartCoroutine(CookFood4Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood4Coroutine()
    {
        var foodTypeData = instance.foodData.FoodTypeList.Find(data => data == instance.foodData.FoodTypeList[3]);
        yield return new WaitForSeconds(1);
        if (instance.numFoodGameObjects < 4)
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
        FoodGameObjects[instance.numFoodGameObjects] = Instantiate(instance.foodObj) as GameObject;
        FoodGameObjects[instance.numFoodGameObjects].name = index.ToString();
        FoodGameObjects[instance.numFoodGameObjects].transform.SetParent(instance.transform.Find("ListFood").transform);
        FoodGameObjects[instance.numFoodGameObjects].SetActive(true);
        FoodGameObjects[instance.numFoodGameObjects].GetComponent<Food>().SetData(foodTypeData);
        FoodGameObjects[instance.numFoodGameObjects].GetComponent<Transform>().position = FoodTranformsList[index].position;
        isObjectFull[index] = true;
        instance.numFoodGameObjects++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Consts.Player)
        {
            canClickFood = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Consts.Player)
        {
            canClickFood = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.instance.ClickFoodinCookingArea -= OnClickFoodinCookingArea;

    }

}
