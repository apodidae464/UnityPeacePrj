using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static bool isStart;
    public static bool isPause;
    public static GameEvents instance;

    // Start is called before the first frame update

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void Start()
    {
        isPause = false;
        isStart = false;
        DontDestroyOnLoad(gameObject);
    }

    public event Action OnIncreaseHealBarByCustomer;
    public void IncreaseHealBarByCumstomer()
    {
        OnIncreaseHealBarByCustomer?.Invoke();
    }


    public event Action OnDecreaseHealBarByCustomer;
    public void DecreaseHealBarByCustomer()
    {
        OnDecreaseHealBarByCustomer?.Invoke();
    }


    public event Action<float> onHealBarIncreasing;
    public void HealBarIncrease(float value)
    {
        onHealBarIncreasing?.Invoke(value);
    }

    public event Action<float> onHealBarDecreasing;
    public void HealBarDecrease(float value)
    {
        onHealBarDecreasing?.Invoke(value);
    }

    public event Action alertOver;
    public void AlertGameOver()
    {
        alertOver?.Invoke();
    }

    public event Action<int> peaceFace;
    public void ChangePeaceFace(int id)
    {
        peaceFace?.Invoke(id);
    }

    //input

    public event Action fistPopup;
    public void TriggerFirstPopup()
    {
        fistPopup?.Invoke();
    }

    public event Action<GameObject> ClickFoodinCookingArea;
    public void OnClickFoodinCookingArea(GameObject hit)
    {
        ClickFoodinCookingArea?.Invoke(hit);
    }

    public event Action<GameObject> addFood;
    public void AddFoodToInventory(GameObject g)
    {
        addFood?.Invoke(g);
    }

    public event Action cookingAreaMenu;
    public void CanTriggerCookingMenu()
    {
        cookingAreaMenu?.Invoke();
    }

    public event Action<RaycastHit2D> givingFood;
    public void OnGivingFoodToCustomer(RaycastHit2D hit)
    {
        givingFood?.Invoke(hit);
    }

    public event Action resetInventory;
    public void OnResetInventory()
    {
        resetInventory?.Invoke();
    }

    public event Action clickOnCCPopup;
    public void onClickOnCCPopup()
    {
        clickOnCCPopup?.Invoke();
    }


    //movement

    public event Action<bool> inObject;
    public void setPlayerInObject(bool value)
    {
        inObject?.Invoke(value);
    }

    //sound

    public event Action playingBgm;
    public void PlayBgm()
    {
        playingBgm?.Invoke();
    }

    public event Action<int> triggerSoundEffect;
    public void OnTriggerSoundEffect(int value)
    {
        triggerSoundEffect?.Invoke(value);
    }

    //guide popup

    
}


