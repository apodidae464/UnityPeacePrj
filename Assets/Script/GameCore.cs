using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{

    private Transform taget;

    [SerializeField] private float smoothSpeed;
    public List<GameObject> _FoodPopUpList = new List<GameObject>();
    public List<GameObject> _CustomerList = new List<GameObject>();
    public List<Table> _tableList = new List<Table>();
    

    public GameObject _CustomerPopup;
    public GameObject _Customer;

    public FoodData foodData;

    public float respawnTime = 2.0f;
    private Vector2 screenBounds;


    private void Awake()
    {
        LoadFoodDatatoList();
        LoadTabletoList();
    }
    void Start()
    {
        taget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CustomerWave());
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(taget.position.x, taget.position.y, transform.position.z),smoothSpeed * Time.deltaTime);
    }
    public void ExitProgram()
    {
        Application.Quit();
    }
    void LoadFoodDatatoList()
    {
        foreach(var foodType in foodData.FoodTypeList)
        {
            var foodTypeData = foodData.FoodTypeList.Find(data => data == foodType);
            _FoodPopUpList.Add(Instantiate(_CustomerPopup));
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<CustomerPopup>().SetData(foodTypeData);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Transform>().position = new Vector3(Screen.width, Screen.height, 0f);
        }
    }

    void LoadTabletoList()
    {
        Table[] tables = new Table[7];
        for(int i = 0; i < 7; i++)
        {
            tables[i] = new Table();
        }
        tables[0].position.Set(4.44f, 0.05f);
        tables[0].isFull = false;

        tables[1].position.Set(-1.8f, -0.025f);
        tables[1].isFull = false;

        tables[2].position.Set(0.06f, -0.17f);
        tables[2].isFull = false;

        tables[3].position.Set(0.93f, -0.07f);
        tables[3].isFull = false;

        tables[4].position.Set(1.99f, -0.15f);
        tables[4].isFull = false;

        tables[5].position.Set(3.67f, 0.36f);
        tables[5].isFull = false;

        tables[6].position.Set(5.0f, 0.36f);
        tables[6].isFull = false;

        foreach (var table in tables)
        {
            _tableList.Add(table);
        }
    }


    private void spawnCustomer()
    {
        if (Player.Instance.MoodIndex >= 7.5f)
            respawnTime = 1.5f;

        if (Player.Instance.MoodIndex <= 3.5f)
            respawnTime = 2.5f;

        if (_CustomerList.Count >= 7)
        {
            return;
        }
        int randomTable = Random.Range(0, 6);
        if(_tableList[randomTable].isFull == true)
        {

        }
        else
        {
            GameObject a = Instantiate(_Customer) as GameObject;
            a.transform.position = _tableList[randomTable].position;
            _CustomerList.Add(a);
            _tableList[randomTable].isFull = true;
        }
    }
    IEnumerator CustomerWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCustomer();
        }
    }
}