using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touchCount > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit != null && hit.collider != null
                    && !CookingArea.Instance.CookingAreaPanel.activeSelf
                    )
                {
                    if (hit.collider.gameObject.tag == AllTag.Cleaner)
                    {
                        Debug.Log("I'm hitting Cleanner");
                        Player.Instance.ResetInventory();
                    }
                    if (hit.collider.gameObject.tag == AllTag.Player)
                    {
                        Debug.Log("I'm hitting Player");
                        PlayerMovement.isInObject = true;
                    }
                    if (hit.collider.gameObject.tag == AllTag.Customer)
                    {
                        Debug.Log("I'm hitting Custommer");
                        PlayerMovement.isInObject = true;
                    }
                    if (hit.collider.gameObject.tag == AllTag.Popup)
                    {
                        Debug.Log("I'm hitting popup");
                        PlayerMovement.isInObject = true;
                        if (Player.Instance.InventoryPlayerList.Count > 0)
                        {
                            if (Player.Instance.InventoryPlayerList.Count == 1)
                            {
                                Debug.Log("1 slot in player inventory");
                                if (Player.Instance.InventoryPlayerList[0].GetComponent<Food>()._foodType.name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                                {
                                    Destroy(Player.Instance.InventoryPlayerList[0]);
                                    Player.Instance.InventoryPlayerList.Clear();
                                    //GameCore.Instance._CustomerList.Remove(transform.parent.gameObject);
                                    Destroy(hit.collider.gameObject);
                                }

                            }
                            if (Player.Instance.InventoryPlayerList.Count == 2)
                            {
                                Debug.Log("2 slot in player inventory");
                                for (int i = 0; i < Player.Instance.InventoryPlayerList.Count; i++)
                                {
                                    if (Player.Instance.InventoryPlayerList[i].GetComponent<Food>()._foodType.name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                                    {
                                        Destroy(Player.Instance.InventoryPlayerList[i]);
                                        Player.Instance.InventoryPlayerList.Remove(Player.Instance.InventoryPlayerList[i]);
                                        //GameCore.Instance._CustomerList.Remove(transform.parent.gameObject);
                                        Destroy(hit.collider.gameObject);
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    if (hit.collider.gameObject.tag == AllTag.CookingArea)
                    {
                        Debug.Log("I'm hitting first Cooking area");
                        CookingArea.Instance.CookingAreaPanel.SetActive(true);
                    }
                    if (hit.collider.gameObject.tag == AllTag.Food)
                    {
                        if (Player.Instance.InventoryPlayerList.Count < 2)
                        {
                            CookingArea.Instance.OnClickFoodinCookingArea(hit.collider.gameObject);
                        }

                    }
                    if (hit.collider.gameObject.tag == AllTag.FirstPopup)
                    {
                        Debug.Log("I'm hitting first popup");
                        hit.collider.gameObject.transform.parent.transform.gameObject.SetActive(false);
                        hit.collider.gameObject.transform.parent.transform.gameObject.transform.transform.parent.Find("Popup(Clone)(Clone)").transform.gameObject.SetActive(true);
                    }


                }
            }
        }
    }
}
