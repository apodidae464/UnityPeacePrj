using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingArea : MonoBehaviour
{

    public GameObject CookingAreaPanel;

    Transform Object0;
    Transform Object1;
    Transform Object2;
    Transform Object3;

    public FoodData foodData;
    public GameObject foodObj;

    int numFoodGameObjects = 0;
    static GameObject[] FoodGameObjects = new GameObject[4];
    static bool[] isObjectFull = new bool[] { false, false, false, false };
    static Transform[] FoodTranformsList = new Transform[4];


    void Start()
    {
        /*for (int i = 0; i < 4; i++)
        {
           // FoodGameObjects[i] = new GameObject();
            FoodGameObjects[i].transform.SetParent(this.transform.Find("ListInventory").transform);
        }*/
        Object0 = this.transform.Find("ListInventory").transform.GetChild(0).transform;
        Object1 = this.transform.Find("ListInventory").transform.GetChild(1).transform;
        Object2 = this.transform.Find("ListInventory").transform.GetChild(2).transform;
        Object3 = this.transform.Find("ListInventory").transform.GetChild(3).transform;
        CookingAreaPanel.SetActive(false);

        FoodTranformsList[0] = Object0;
        FoodTranformsList[1] = Object1;
        FoodTranformsList[2] = Object2;
        FoodTranformsList[3] = Object3;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touchCount > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit != null && hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == AllTag.CookingArea)
                    {
                        Debug.Log("I'm hitting first Cooking area");
                        CookingAreaPanel.SetActive(true);
                    }
                    if (hit.collider.gameObject.tag == AllTag.Food)
                    {
                        if(CookingAreaPanel.activeSelf == false && Player.Instance.InventoryPlayerList.Count < 2)
                        {
                            
                            Player.Instance.addFoodInInventory(hit.collider.gameObject);
                            Destroy(hit.collider.gameObject);
                            numFoodGameObjects--;
                            int index = int.Parse(hit.collider.gameObject.name);
                            isObjectFull[index] = false;
                        }
                       
                    }

                }
            }
        }

    }

    public void turnOffCookingArea()
    {
        CookingAreaPanel.SetActive(false);
    }

    public void CookFood1()
    {
        if(numFoodGameObjects < 4)
            StartCoroutine(CookFood1Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood1Coroutine()
    {
        var foodTypeData = foodData.FoodTypeList.Find(data => data == foodData.FoodTypeList[0]);
        yield return new WaitForSeconds(1);
        if(numFoodGameObjects < 4)
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
        if ( numFoodGameObjects < 4)
            StartCoroutine(CookFood2Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood2Coroutine()
    {
        var foodTypeData = foodData.FoodTypeList.Find(data => data == foodData.FoodTypeList[1]);
        yield return new WaitForSeconds(1);
        if (numFoodGameObjects < 4)
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
        if (numFoodGameObjects < 4)
            StartCoroutine(CookFood3Coroutine());
        else
            Debug.Log("CookingAreaInventoryItems is full");
    }
    IEnumerator CookFood3Coroutine()
    {
        var foodTypeData = foodData.FoodTypeList.Find(data => data == foodData.FoodTypeList[2]);
        yield return new WaitForSeconds(1);
        if (numFoodGameObjects < 4)
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
        FoodGameObjects[numFoodGameObjects] = Instantiate(foodObj) as GameObject;
        FoodGameObjects[numFoodGameObjects].name = numFoodGameObjects.ToString();
        FoodGameObjects[numFoodGameObjects].transform.SetParent(this.transform.Find("ListFood").transform);
        FoodGameObjects[numFoodGameObjects].SetActive(true);
        FoodGameObjects[numFoodGameObjects].GetComponent<Food>().SetData(foodTypeData);
        FoodGameObjects[numFoodGameObjects].GetComponent<Transform>().position = FoodTranformsList[index].position;
        isObjectFull[index] = true;
        numFoodGameObjects++;
    }


}
