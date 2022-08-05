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

        if (GameEvents.isPause)
            return;
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
                    if (hit.collider.gameObject.tag == Constaint.Cleaner)
                    {
                        GameEvents.instance.OnTriggerSoundEffect(Constaint.Vfx_clear);
                        GameEvents.instance.OnResetInventory();
                    }
                    if (hit.collider.gameObject.tag == Constaint.Player)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                    }
                    if (hit.collider.gameObject.tag == Constaint.Customer)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                    }
                    if (hit.collider.gameObject.tag == Constaint.Popup)
                    {
                        GameEvents.instance.setPlayerInObject(true);
                        GameEvents.instance.OnGivingFoodToCustomer(hit);
                    }
                    if (hit.collider.gameObject.tag == Constaint.CookingMenu)
                    {
                        GameEvents.instance.OnTriggerSoundEffect(Constaint.Vfx_click);
                        GameEvents.instance.CanTriggerCookingMenu();
                    }
                    if (hit.collider.gameObject.tag == Constaint.Food)
                    {
                        if (Player.instance.InventoryPlayerList.Count < 2)
                        {
                            GameEvents.instance.OnTriggerSoundEffect(Constaint.Vfx_drop);
                            GameEvents.instance.AddFoodToInventory(hit.collider.gameObject);
                            GameEvents.instance.OnClickFoodinCookingArea(hit.collider.gameObject);
                        }
                    }
                    if (hit.collider.gameObject.tag == Constaint.FirstPopup)
                    {
                        GameEvents.instance.OnTriggerSoundEffect(Constaint.Vfx_click);
                        GameEvents.instance.TriggerFirstPopup();
                    }

                }
            }
        }
    }

   
}