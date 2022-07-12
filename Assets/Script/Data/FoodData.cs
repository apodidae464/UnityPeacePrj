using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]

public class FoodData : ScriptableObject
{
    [System.Serializable]

    public class FoodType
    {
        public string name;
        public Sprite image;
    }

    public List<FoodType> FoodTypeList = new List<FoodType>();

}
