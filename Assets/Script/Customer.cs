using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

     GameObject OrderPopup;

    private void Awake()
    {
        int randomOrderPopup = Random.Range(0, GameCore._FoodPopUpList.Count);
        OrderPopup = Instantiate(GameCore._FoodPopUpList[randomOrderPopup]) as GameObject;
        OrderPopup.transform.SetParent(this.transform);
        OrderPopup.transform.position = this.transform.Find("FirstPopup").transform.position;
        OrderPopup.SetActive(false);
    }

    void Start()
    {
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());
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
                    if (hit.collider.gameObject.tag == AllTag.FirstPopup) {
                        Debug.Log("I'm hitting first popup");
                        hit.collider.gameObject.transform.parent.transform.gameObject.SetActive(false);
                        OrderPopup.SetActive(true);
                    }
                        
                }
            }
        }

    }

    IEnumerator ShowFirstPopupCoroutine()
    {   
        yield return new WaitForSeconds(3);
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(true);
    }

}
