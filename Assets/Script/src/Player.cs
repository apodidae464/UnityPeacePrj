using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    public List<GameObject> InventoryPlayerList = new List<GameObject>();
    public bool[] InventoryFoodTranformFull = new bool[2] { false, false };
    public Transform[] InventoryFoodTranform = new Transform[2];

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
        InventoryFoodTranform[0] = instance.transform.Find("Inventory1").transform;
        InventoryFoodTranform[1] = instance.transform.Find("Inventory2").transform;
    }

    private void Start()
    {
        GameEvents.instance.addFood += addFoodInInventory;
    }

    //How to get method in Player
    //Player.Instance.MethodName(Param1,Param2);

    //Attribute of Player

    //Max = 100, Min = 0

    //Method
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AllTag.PlayerGizmosRange);
    }

    private void Update()
    {
       
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
        if (InventoryPlayerList.Count == 0)
        {
            return;
        }
        if (InventoryPlayerList.Count < 2)
            Destroy(InventoryPlayerList[0]);
        else
        {
            Destroy(InventoryPlayerList[0]);
            Destroy(InventoryPlayerList[1]);
        }
        InventoryPlayerList.Clear();
    }

    private void OnDestroy()
    {
        GameEvents.instance.addFood -= addFoodInInventory;

    }
}