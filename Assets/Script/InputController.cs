using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public bool canMove;

    private void Start()
    {
        if (!instance)
            instance = GetComponent<InputController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touchCount > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null
                    && !UIController.íntance.CookingAreaPanel.activeSelf
                    && !UIController.íntance.GameoverAreaPanel.activeSelf
                    )
                {
                    if (hit.collider.gameObject.tag == ConstaintValue.Cleaner)
                    {
                        GameEvents.instance.OnResetInventory();
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.Player)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.Customer)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.Popup)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                        GameEvents.instance.OnGivingFoodToCustomer(hit);
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.CookingMenu)
                    {
                        GameEvents.instance.CanTriggerCookingMenu();
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.Food)
                    {
                        if (Player.instance.InventoryPlayerList.Count < 2)
                        {
                            GameEvents.instance.AddFoodToInventory(hit.collider.gameObject);
                            GameEvents.instance.OnClickFoodinCookingArea(hit.collider.gameObject);
                        }
                    }
                    if (hit.collider.gameObject.tag == ConstaintValue.FirstPopup)
                    {
                        GameEvents.instance.TriggerFirstPopup();
                    }
                }
            }
        }
    }

   
}