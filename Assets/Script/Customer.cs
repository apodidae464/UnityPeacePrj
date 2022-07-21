using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{


    void Start()
    {
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(false);
        StartCoroutine(ShowFirstPopupCoroutine());
    }
    private void Update()
    {
        
    }

    IEnumerator ShowFirstPopupCoroutine()
    {   
        yield return new WaitForSeconds(3);
        this.transform.Find("FirstPopup").transform.gameObject.SetActive(true);
    }

}
