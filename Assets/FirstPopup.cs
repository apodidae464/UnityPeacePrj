using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPopup : MonoBehaviour
{
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
                    Debug.Log("I'm hitting " + hit.collider.name);
                    if (hit.collider.gameObject.name == "FirstPopup")
                        Destroy(gameObject);
                }
            }
        }
    }
}
