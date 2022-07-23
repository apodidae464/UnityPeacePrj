using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> InventoryPlayerList = new List<GameObject>();
    public bool[] InventoryFoodTranformFull = new bool[2] { false, false };
    public Transform[] InventoryFoodTranform = new Transform[2]; 
    //public GameObject Inventory2 = new GameObject();
    //Singleton
    public static Player Instance { get; private set; }

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
        InventoryFoodTranform[0] = Instance.transform.Find("Inventory1").transform;
        InventoryFoodTranform[1] = Instance.transform.Find("Inventory2").transform;
    }

    //How to get method in Player
    //Player.Instance.MethodName(Param1,Param2);

    //Attribute of Player

    private bool isInGreenArea = false;
    private bool isInRedArea = false;

    public float range = 1.5f;
    public float MoodIndex = 100.0f;    //Max = 100, Min = 0

    //Method
    public void MoodIndexIncrease()
    {
        MoodIndex += 1f;
    }

    public void MoodIndexDecrease()
    {
        MoodIndex -= 1f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        if (isInGreenArea)
        {
            MoodIndexDecrease();
        }
        if (isInRedArea)
        {
            MoodIndexIncrease();
        }
        if (MoodIndex <= 0)
        {
            //GameOver BLOOM!
            //GameCore.Instance.Restart();
        }
       
    }

    public void addFoodInInventory(GameObject food)
    {
        GameObject g;
        switch (InventoryPlayerList.Count)
        {
            case 0:
                g = Instantiate(food);
                g.tag = AllTag.PlayerFood;
                InventoryPlayerList.Add(g);
                InventoryPlayerList[0].transform.SetParent(this.transform);
                InventoryPlayerList[0].transform.position = InventoryFoodTranform[0].position;
                Destroy(g.transform.GetComponent<BoxCollider2D>());
                break;
            case 1:
                g = Instantiate(food);
                g.tag = AllTag.PlayerFood;
                InventoryPlayerList.Add(g);
                InventoryPlayerList[1].transform.SetParent(this.transform);
                InventoryPlayerList[0].transform.position = InventoryFoodTranform[0].position;
                InventoryPlayerList[1].transform.position = InventoryFoodTranform[1].position;
                Destroy(g.transform.GetComponent<BoxCollider2D>());
                break;
            default:
                break;
        }
    }

    public void ResetInventory()
    {
        if(InventoryPlayerList.Count == 0)
        {
            return;
        }
        if(InventoryPlayerList.Count < 2)
            Destroy(InventoryPlayerList[0]);
        else
        {
            Destroy(InventoryPlayerList[0]);
            Destroy(InventoryPlayerList[1]);
        }
        InventoryPlayerList.Clear();
    }



}

