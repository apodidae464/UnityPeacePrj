using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public FoodData.FoodType PlayerOrderFood = new FoodData.FoodType();
    public GameObject OrderPopup;
    public GameObject firstPopup;
    public GameObject endPopup;

    private bool isTakenOrder = false;
    public List<GameObject> _FoodPopUpList;
    public FoodData foodData;
    public GameObject _CustomerPopup;

    

    private bool canTrigger;
    private void Awake()
    {
    }

    private void Start()
    {
        GameEvents.instance.fistPopup += TriggerFirstPopup;
        LoadFoodDatatoList();
        firstPopup.SetActive(false);
        endPopup.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());
        StartCoroutine(ReduceHealthCoroutine());

        int randomOrderPopup = Random.Range(0, _FoodPopUpList.Count);
        OrderPopup = Instantiate(_FoodPopUpList[randomOrderPopup]) as GameObject;
        //OrderPopup.name = GameCore.Instance._FoodPopUpList[randomOrderPopup].GetComponent<Popup>()._foodType.name;
        OrderPopup.transform.SetParent(this.transform);
        OrderPopup.transform.position = firstPopup.transform.position;
        OrderPopup.SetActive(false);

        PlayerOrderFood.name = _FoodPopUpList[randomOrderPopup].GetComponent<Popup>()._foodType.name;
    }

    public void OnCustomerActive()
    {
        firstPopup.SetActive(true);
        OrderPopup.SetActive(false);
        endPopup.SetActive(false);
        isTakenOrder = false;
    }

    public void OnClickonPopupInCustomer()
    {
        if (!canTrigger)
            return;
        OrderPopup.SetActive(false);
        isTakenOrder = true;
        GameEvents.instance.IncreaseHealBarByCumstomer();
    }

    private void Update()
    {
        if (isTakenOrder)
        {
            StartCoroutine(ShowEndPopupCoroutine());
        }

    }

    private IEnumerator ShowFirstPopupCoroutine()
    {
        yield return new WaitForSeconds(3);
        firstPopup.SetActive(true);
    }

    private IEnumerator ShowEndPopupCoroutine()
    {
        GameEvents.instance.OnTriggerSoundEffect(Constaint.Vfx_finish);
        endPopup.SetActive(true);
        yield return new WaitForSeconds(3);

        DisableCustomer();
        yield return new WaitForSeconds(3);
    }

    private IEnumerator ReduceHealthCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameEvents.instance.DecreaseHealBarByCustomer();
        }
    }

    private void DisableCustomer()
    {

        this.gameObject.SetActive(false);
        GameCore.Instance.numOfCustommer--;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Constaint.Player)
        {
            canTrigger = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constaint.Player)
        {
            canTrigger = false;
        }
    }

    private void TriggerFirstPopup()
    {
        if (!canTrigger)
            return;
        Debug.Log("I'm hitting first popup");
        firstPopup.SetActive(false);
        OrderPopup.SetActive(true);
    }

    private void LoadFoodDatatoList()
    {
        foreach (var foodType in foodData.FoodTypeList)
        {
            var foodTypeData = foodData.FoodTypeList.Find(data => data == foodType);
            _FoodPopUpList.Add(Instantiate(_CustomerPopup));
            _FoodPopUpList[_FoodPopUpList.Count - 1].name = _FoodPopUpList[_FoodPopUpList.Count - 1].name /*+ (_FoodPopUpList.Count).ToString()*/;
            _FoodPopUpList[_FoodPopUpList.Count - 1].SetActive(false);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Popup>().SetData(foodTypeData);
            _FoodPopUpList[_FoodPopUpList.Count - 1].GetComponent<Transform>().position = new Vector3(Screen.width, Screen.height, 0f);
        }
    }

    private void OnDestroy()
    {
        GameEvents.instance.fistPopup -= TriggerFirstPopup;
    }
}