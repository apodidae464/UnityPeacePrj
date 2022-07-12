using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public List<GameObject> _FoodList = new List<GameObject>();
    public List<GameObject> _Customer = new List<GameObject>();



    public FoodData foodData;



    public void ExitProgram()
    {
        Application.Quit();
    }
}