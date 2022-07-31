using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touchCount > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                /*RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null
                    && !UIController.íntance.CookingAreaPanel.activeSelf
                    && !UIController.íntance.GameoverAreaPanel.activeSelf
                    )
                {
                    if (hit.collider.gameObject.tag == AllTag.Cleaner)
                    {
                        Debug.Log("I'm hitting Cleanner");
                        Player.instance.ResetInventory();
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
                        if (Player.instance.InventoryPlayerList.Count > 0)
                        {
                            if (Player.instance.InventoryPlayerList.Count == 1)
                            {
                                Debug.Log("1 slot in player inventory");
                                if (Player.instance.InventoryPlayerList[0].GetComponent<Food>()._foodType.name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                                {
                                    Destroy(Player.instance.InventoryPlayerList[0]);
                                    Player.instance.InventoryPlayerList.Clear();
                                    GameObject Customer = hit.collider.gameObject.transform.parent.gameObject;
                                    Customer.GetComponent<Customer>().OnClickonPopupInCustomer();
                                }
                            }
                            if (Player.instance.InventoryPlayerList.Count == 2)
                            {
                                Debug.Log("2 slot in player inventory");
                                for (int i = 0; i < Player.instance.InventoryPlayerList.Count; i++)
                                {
                                    if (Player.instance.InventoryPlayerList[i].GetComponent<Food>()._foodType.name == hit.collider.gameObject.transform.GetComponentInParent<Customer>().PlayerOrderFood.name)
                                    {
                                        Destroy(Player.instance.InventoryPlayerList[i]);
                                        Player.instance.InventoryPlayerList.Remove(Player.instance.InventoryPlayerList[i]);
                                        GameObject Customer = hit.collider.gameObject.transform.parent.gameObject;
                                        Customer.GetComponent<Customer>().OnClickonPopupInCustomer();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (hit.collider.gameObject.tag == AllTag.CookingArea)
                    {
                        Debug.Log("I'm hitting first Cooking area");
                        UIController.íntance.CookingAreaPanel.SetActive(true);
                    }
                    if (hit.collider.gameObject.tag == AllTag.Food)
                    {
                        if (Player.instance.InventoryPlayerList.Count < 2)
                        {
                            CookingArea.instance.OnClickFoodinCookingArea(hit.collider.gameObject);
                        }
                    }
                    if (hit.collider.gameObject.tag == AllTag.FirstPopup)
                    {
                        Debug.Log("I'm hitting first popup");
                        GameObject Customer = hit.collider.gameObject.transform.parent.parent.gameObject;
                        Customer.transform.Find("FirstPopup").gameObject.SetActive(false);
                        Customer.GetComponent<Customer>().OrderPopup.SetActive(true);
                    }
                }*/
            }
        }
    }
}