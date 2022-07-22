using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance { get; private set; }
    public List<GameObject> _FoodPopUpList;
    public List<GameObject> _CustomerList;
    public List<Table> _tableList = new List<Table>();
    public GameObject _CustomerPopup;
    public GameObject _Customer;
    public FoodData foodData;
    public bool isListTableFull = false;
    public float respawnTime = 2.0f;


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

        _FoodPopUpList = new List<GameObject>();
        _CustomerList = new List<GameObject>();
        isListTableFull = false;
        LoadFoodDatatoList();
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        if (Player.Instance.MoodIndex <= 100.0f)
            respawnTime = 4.0f;
        if (Player.Instance.MoodIndex <= 90.0f)
            respawnTime = 3.0f;
        if (Player.Instance.MoodIndex <= 80.0f)
            respawnTime = 2.0f;
        if (Player.Instance.MoodIndex <= 70.0f)
            respawnTime = 2.5f;
        if (Player.Instance.MoodIndex <= 60.0f)
            respawnTime = 2.3f;
        if (Player.Instance.MoodIndex <= 50.0f)
            respawnTime = 1.5f;
        if (Player.Instance.MoodIndex <= 40.0f)
            respawnTime = 1.5f;
        if (Player.Instance.MoodIndex <= 30.0f)
            respawnTime = 1.0f;
    
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
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<CustomerPopup>().SetData(foodTypeData);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Transform>().position = new Vector3(Screen.width, Screen.height, 0f);
        }
    }

}