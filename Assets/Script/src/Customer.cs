using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public FoodData.FoodType PlayerOrderFood = new FoodData.FoodType();
    public GameObject[] OrderPopup;
    public GameObject firstPopup;
    public GameObject endPopup;

    private bool isTakenOrder = false;
    public List<GameObject> _FoodPopUpList;
    public FoodData foodData;
    public FoodData customerSprites;
    public GameObject _CustomerPopup;

    private int temp;
    private bool canTrigger;
    bool fistActive = false;
    private void Awake()
    {
        LoadFoodDatatoList();
    }

    private void Start()
    {
        int random = Random.Range(0, customerSprites.FoodTypeList.Count);
        this.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sprite = customerSprites.FoodTypeList[random].image;
    }

    public void OnCustomerActive()
    {
        if (!fistActive)
        {

            for (int i = 0; i < OrderPopup.Length; i++)
            {
                int random = Random.Range(0, foodData.FoodTypeList.Count);
                OrderPopup[i] = Instantiate(_FoodPopUpList[random]) as GameObject;
                OrderPopup[i].transform.SetParent(this.transform);
                OrderPopup[i].transform.position = firstPopup.transform.position;
                OrderPopup[i].SetActive(false);
            }
            fistActive = true;
        }
        GameEvents.instance.fistPopup += TriggerFirstPopup;
        GameEvents.instance.clickOnCCPopup += OnClickonPopupInCustomer;
        firstPopup.SetActive(false);
        endPopup.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());
        StartCoroutine(ReduceHealthCoroutine());
        temp = Random.Range(0, foodData.FoodTypeList.Count);
        isTakenOrder = false;
        PlayerOrderFood.name = _FoodPopUpList[temp].GetComponent<Popup>()._foodType.name;

    }

    public void OnClickonPopupInCustomer()
    {
        if (!canTrigger)
            return;
        OrderPopup[temp].SetActive(false);
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
        GameEvents.instance.OnTriggerSoundEffect(Consts.Vfx_finish);
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
        if(collision.tag == Consts.Player)
        {
            canTrigger = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Consts.Player)
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
        OrderPopup[temp].SetActive(true);
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
        GameEvents.instance.clickOnCCPopup -= OnClickonPopupInCustomer;

    }
}