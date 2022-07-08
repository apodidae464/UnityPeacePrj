using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Singleton
    public static Player Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    //How to get method in Player 
    //Player.Instance.MethodName(Param1,Param2);

    //Attribute of Player
    private bool isTakeOrder = false;
    private bool isInGreenArea = false;
    private bool isInRedArea = false;

    public float MoodIndex = 5.0f;    //Max = 10, Min = 0

    //Method
    public void MoodIndexIncrease()
    {
        MoodIndex += 0.2f;
    }
    public void MoodIndexDecrease()
    {
        MoodIndex -= 0.2f;
    }


    private void Update()
    {
        if (isInGreenArea)
        {
            MoodIndexDecrease();
        }
        if (isInRedArea)
        {
            MoodIndexIncrease();
        }
        if (MoodIndex >= 10)
        {
            //GameOver BLOOM!
        }
    }
}
