using UnityEngine;

public class Popup : MonoBehaviour
{
    public FoodData.FoodType _foodType;
    public int valueDollas;

    public void SetData(FoodData.FoodType foodType)
    {
        _foodType = foodType;
        GetComponent<SpriteRenderer>().sprite = _foodType.image;
        this.transform.GetChild(0).gameObject.GetComponent <TextMesh>().text = _foodType.name;
        if (_foodType.name == Constaint.Food_0)
        {
            valueDollas = Constaint.Food_0_Value;
        }
        else if (_foodType.name == Constaint.Food_1)
        {
            valueDollas = Constaint.Food_1_Value;
        }
        else
            valueDollas = Constaint.Food_2_Value;

    }
}