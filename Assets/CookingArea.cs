using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingArea : MonoBehaviour
{

    public GameObject CookingAreaPanel;

    void Start()
    {
        CookingAreaPanel.SetActive(false);
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
                    if (hit.collider.gameObject.tag == AllTag.CookingArea)
                    {
                        Debug.Log("I'm hitting first Cooking area");
                        CookingAreaPanel.SetActive(true);
                    }

                }
            }
        }
    }

    public void turnOffCookingArea()
    {
        CookingAreaPanel.SetActive(false);
    }


}
