using UnityEngine;

public class CustomerPopup : MonoBehaviour
{
    public FoodData.FoodType _foodType;

    public void SetData(FoodData.FoodType foodType)
    {
        _foodType = foodType;
        GetComponent<SpriteRenderer>().sprite = _foodType.image;
        this.transform.GetChild(0).gameObject.GetComponent <TextMesh>().text = _foodType.name;

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
                    if (hit.collider.gameObject.tag == AllTag.Popup)
                    {
                        Debug.Log("I'm hitting Custommer Popup");
                        if(Player.Instance.InventoryPlayerList.Count > 0)
                        {
                            if (Player.Instance.InventoryPlayerList.Count == 1)
                            {
                                Debug.Log("1 slot in player inventory");
                                if (Player.Instance.InventoryPlayerList[0].GetComponent<Food>()._foodType.name == _foodType.name)
                                {
                                    Destroy(Player.Instance.InventoryPlayerList[0]);
                                    Player.Instance.InventoryPlayerList.Clear();
                                    GameCore.Instance._CustomerList.Remove(transform.parent.gameObject);
                                    Destroy(transform.parent.gameObject);

                                }

                            }

                            if (Player.Instance.InventoryPlayerList.Count <= 2)
                            {
                                Debug.Log("2 slot in player inventory");
                                for (int i = 0; i < Player.Instance.InventoryPlayerList.Count; i++)
                                {
                                    if(Player.Instance.InventoryPlayerList[i].GetComponent<Food>()._foodType.name == _foodType.name)
                                    {
                                        Destroy(Player.Instance.InventoryPlayerList[i]);
                                        Player.Instance.InventoryPlayerList.Remove(Player.Instance.InventoryPlayerList[i]);
                                        GameCore.Instance._CustomerList.Remove(transform.parent.gameObject);
                                        Destroy(transform.parent.gameObject);
                                        break;
                                    }
                                }  
                            }

                        }
                        
                        
                    }

                }
            }
        }
    }
}