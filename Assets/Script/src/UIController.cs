using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController íntance { get; private set; }

    public GameObject CookingAreaPanel;
    public GameObject GameoverAreaPanel;
    public GameObject GamestartAreaPanel;
    public Text point;

    private bool isOver;

    //shop
    public GameObject Shop;
    public GameObject Table;

    private bool keyShop;
    private bool onBuyTableObject;
    private void Awake()
    {
        if (íntance != null && íntance != this)
        {
            Destroy(this);
        }
        else
        {
            íntance = this;
        }
    }


    private void Start()
    {
        keyShop = true;
        isOver = false;
        turnOffCookingArea();
        turnOffGameoverAreaPanel();

        GameEvents.instance.alertOver += setOver;
        GameEvents.instance.cookingAreaMenu += TriggerCookingPopup;
    }

    private void Update()
    {
        point.text = "Money: " + GameCore.Instance.point;
        if (isOver)
        {
            GameoverAreaPanel.SetActive(true);
            //do st
        }
        if (Shop.activeInHierarchy)
            keyShop = true;
        else
            keyShop = false;

        if(onBuyTableObject)
        {
            Shop.SetActive(false);
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0.8f;
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.touchCount > 0)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                    if (hit.collider != null && hit.collider.tag != null)
                    {
                        GameEvents.isPause = false;
                        onBuyTableObject = false;

                        return;
                    } else 
                    {
                        
                        Instantiate(Table, pos, transform.rotation);
                        Player.instance.point -= Constaint.Table_value;
                        onBuyTableObject = false;
                        GameEvents.isPause = false;
                    }
                        
                    
                }
            }
        }
    }

    // Start is called before the first frame update

    public void turnOffGamestartArea()
    {
        GameEvents.isStart = true;
        íntance.GamestartAreaPanel.SetActive(false);
    }

    public void turnOffCookingArea()
    {
        íntance.CookingAreaPanel.SetActive(false);
    }

    public void turnOffGameoverAreaPanel()
    {
        íntance.GameoverAreaPanel.SetActive(false);
    }

    public void TriggerCookingPopup()
    {
        if (!GameEvents.isStart)
            return;
        CookingAreaPanel.SetActive(true);
    }
  
    public void setOver()
    {
        isOver = true;
    }

    public void OpenCloseShop()
    {
        if (!keyShop)
        {
            Shop.SetActive(true);
            GameEvents.isPause = true;
        }
        else
        {
            Shop.SetActive(false);
            GameEvents.isPause = false;
        }
    }

    public void BuyInstanceTable()
    {
        if(GameCore.Instance.point < Constaint.Table_value)
        {
            return;
        } else
        {
            onBuyTableObject = true;
        }
    }

    private void OnDestroy()
    {
        GameEvents.instance.alertOver -= setOver;
        GameEvents.instance.cookingAreaMenu -= TriggerCookingPopup;

    }
}