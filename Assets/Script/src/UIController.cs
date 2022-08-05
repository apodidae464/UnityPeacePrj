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

    private void OnDestroy()
    {
        GameEvents.instance.alertOver -= setOver;
        GameEvents.instance.cookingAreaMenu -= TriggerCookingPopup;

    }
}