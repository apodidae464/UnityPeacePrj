using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    public FoodData.FoodType PlayerOrderFood = new FoodData.FoodType();

    private void Awake()
    {
        
    }

    void Start()
    {
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());

        int randomOrderPopup = Random.Range(0, GameCore.Instance._FoodPopUpList.Count);
        GameObject OrderPopup = Instantiate(GameCore.Instance._FoodPopUpList[randomOrderPopup]) as GameObject;
        OrderPopup.transform.SetParent(this.transform);
        OrderPopup.transform.position = this.transform.Find("FirstPopup").transform.position;
        OrderPopup.SetActive(false);

        PlayerOrderFood.name = GameCore.Instance._FoodPopUpList[randomOrderPopup].GetComponent<Popup>()._foodType.name;
    }
    public void OnClickonPopupInCustomer()
    {
        
    }
    void Update()
    {
       
    }

    IEnumerator ShowFirstPopupCoroutine()
    {   
        yield return new WaitForSeconds(3);
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(true);
    }

}
