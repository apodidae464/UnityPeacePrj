using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodData.FoodType _foodType;

    public void SetData(FoodData.FoodType foodType)
    {
        _foodType = foodType;
        GetComponent<SpriteRenderer>().sprite = _foodType.image;
        this.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = _foodType.name;
    }
}