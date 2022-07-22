using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
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
                    if (hit.collider.gameObject.tag == AllTag.Cleaner)
                    {
                        Debug.Log("I'm hitting Cleanner");
                        Player.Instance.ResetInventory();
                    }

                }
            }
        }
    }
}
