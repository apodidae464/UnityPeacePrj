using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCore : MonoBehaviour
{

    public static GameCore Instance { get; private set; }

    private Transform taget;

    [SerializeField] private float smoothSpeed;

    public List<GameObject> _FoodPopUpList;
    public List<GameObject> _FoodPopUpUsedList;

    public List<GameObject> _CustomerList;
    public List<Table> _tableList = new List<Table>();

    public GameObject _CustomerPopup;
    public GameObject _Customer;

    public FoodData foodData;

    public bool isListTableFull = false;

    public float respawnTime = 2.0f;
    private Vector2 screenBounds;


    //private GameCore pool;

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
        _FoodPopUpUsedList = new List<GameObject>();
        _CustomerList = new List<GameObject>();
        isListTableFull = false;
        LoadFoodDatatoList();
    }

    private void Start()
    {
        taget = GameObject.FindGameObjectWithTag(AllTag.Player).GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CustomerWave());

        //pool = transform.parent.GetComponent<GameCore>();
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

        if(_CustomerList.Count > 0)
        {
            Player.Instance.MoodIndex -= (float)_CustomerList.Count * 0.5f;
        }



        //Tranform.position for camera
        transform.position = Vector3.Lerp(transform.position, new Vector3(taget.position.x, taget.position.y, transform.position.z), smoothSpeed * Time.deltaTime);


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

    public GameObject GetFoodPopup(int toltalFree)
    {
        GameObject g = _FoodPopUpList[toltalFree];
        g.SetActive(true);
        _FoodPopUpUsedList.Add(g);
        return g;
    }

    public void ReturnFoodPopup(GameObject obj)
    {
        obj.SetActive(false);
        _FoodPopUpUsedList.Remove(obj);
        _FoodPopUpList.Add(obj);
    }

    IEnumerator ReturnFoodPopupAfterTime()
    {
        yield return new WaitForSeconds(3f);
        //pool.ReturnFoodPopup(gameObject);

    }

    public void ReturnObject(GameObject obj)
    {
        Debug.Assert(_FoodPopUpUsedList.Contains(obj));
        obj.SetActive(false);
        _FoodPopUpUsedList.Remove(obj);
        _FoodPopUpList.Add(obj);
    }

    

    private void spawnCustomer()
    {

        bool isCreate = true;


        if (_CustomerList.Count >= _tableList.Count) isListTableFull = true;
        if(_CustomerList.Count < _tableList.Count)
            isListTableFull = false;

        if (isListTableFull == false)
        {
            do
            {
                int randomTable = Random.Range(0, _tableList.Count);
                if (_tableList[randomTable].isFull != true)
                {
                    GameObject a = Instantiate(_Customer) as GameObject;
                    a.name = a.name /*+ (_CustomerList.Count + 1).ToString()*/;
                    a.transform.position = _tableList[randomTable].transform.GetChild(0).gameObject.transform.position;
                    _CustomerList.Add(a);
                    _tableList[randomTable].isFull = true;
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

    private IEnumerator CustomerWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCustomer();
        }
    }
}