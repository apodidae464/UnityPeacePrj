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
        if (_foodType.name == Consts.Food_0)
        {
            valueDollas = Consts.Food_0_Value;
        }
        else if (_foodType.name == Consts.Food_1)
        {
            valueDollas = Consts.Food_1_Value;
        }
        else if(_foodType.name == Consts.Food_2)
            valueDollas = Consts.Food_2_Value;
        else
            valueDollas = Consts.Food_3_Value;

    }
}