using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
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

    public event Action<GameObject> addFood;
    public void AddFoodToInventory(GameObject g)
    {
        addFood?.Invoke(g);
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
}


