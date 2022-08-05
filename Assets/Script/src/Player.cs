using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    public List<GameObject> InventoryPlayerList = new List<GameObject>();
    public bool[] InventoryFoodTranformFull = new bool[2] { false, false };
    public Transform[] InventoryFoodTranform = new Transform[2];

    bool canPickFood;
    bool canGiveFood;

    public string level;
    public int point;

    public int currentLevel;
    Transform begin;
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

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameEvents.instance.addFood += addFoodInInventory;
        GameEvents.instance.givingFood += OnGivingFood;
        GameEvents.instance.resetInventory += ResetInventory;
        level = PlayerPrefs.GetString("Level");
        if(level == "")
        {
            level = Constaint.Level_1;
        }
        point = PlayerPrefs.GetInt("Point");
        if(point <= 0)
        {
            point = 0;
        }
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
        Gizmos.DrawWireSphere(transform.position, Constaint.PlayerGizmosRange);
    }

    private void Update()
    {
        GameCore.Instance.point = point;
        if (level == Constaint.Level_1 && point > 0)
        {
            level = Constaint.Level_2;
            SceneManager.LoadScene(Constaint.Level_2);
        }
    }

    public void addFoodInInventory(GameObject food)
    {
        
        if (!canPickFood)
            return;
        GameObject g;
        switch (InventoryPlayerList.Count)
        {
            case 0:
                g = Instantiate(food);
                g.tag = Constaint.PlayerFood;
                InventoryPlayerList.Add(g);
                InventoryPlayerList[0].transform.SetParent(this.transform);
                InventoryPlayerList[0].transform.position = InventoryFoodTranform[0].position;
                Destroy(g.transform.GetComponent<BoxCollider2D>());
                break;

            case 1:
                g = Instantiate(food);
                g.tag = Constaint.PlayerFood;
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

    public void OnGivingFood(RaycastHit2D hit)
    {
        if (!canGiveFood)
            return;
        if (InventoryPlayerList.Count > 0)
        {
            if (InventoryPlayerList.Count == 1)
            {
                string name = InventoryPlayerList[0].GetComponent<Food>()._foodType.name;

                if (name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                {
                    addPoint(name);
                    Destroy(InventoryPlayerList[0]);
                    InventoryPlayerList.Clear();
                   // GameObject Customer = hit.collider.gameObject.transform.parent.gameObject;
                    GameEvents.instance.onClickOnCCPopup();
                }
            }
            if (Player.instance.InventoryPlayerList.Count == 2)
            {
                for (int i = 0; i < InventoryPlayerList.Count; i++)
                {
                    string name = InventoryPlayerList[i].GetComponent<Food>()._foodType.name;
                    if (InventoryPlayerList[i].GetComponent<Food>()._foodType.name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                    {
                        addPoint(name);
                        Destroy(InventoryPlayerList[i]);
                        InventoryPlayerList.Remove(InventoryPlayerList[i]);
                      //  GameObject Customer = hit.collider.gameObject.transform.parent.gameObject;
                        GameEvents.instance.onClickOnCCPopup();

                        break;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Constaint.CookingArea)
        {
            canPickFood = true;
        }
        
        if(collision.tag == Constaint.Customer)
        {
            canGiveFood = true;
        }    

        if(collision.tag == "NextLevel")
        {
           
        }
    }

    private void addPoint(string name)
    {
        if (name == Constaint.Food_0)
        {
            point += Constaint.Food_0_Value;
        }
        else if (name == Constaint.Food_1)
        {
            point += Constaint.Food_1_Value;
        }
        else
            point += Constaint.Food_2_Value;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constaint.CookingArea)
        {
            canPickFood = false;
        }
        if (collision.tag == Constaint.Customer)
        {
            canGiveFood = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.instance.addFood -= addFoodInInventory;
        GameEvents.instance.givingFood -= OnGivingFood;
        GameEvents.instance.resetInventory -= ResetInventory;


    }
}