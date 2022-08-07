using UnityEngine;

public class Constaint
{

    //path
    public static string tableListPath = Application.dataPath + "/Script/Data/listTable.json";
    //Scene
    public static string Level_1 = "Start";
    public static int Pass_Lv1 = 1;
    public static string Level_2 = "Level_2";
    public static int Pass_Lv2 = 5;
    public static string Level_3 = "Level_3";
    public static int Pass_Lv3 = 121;

    public static float beginTablePos1_x = -1;
    public static float beginTablePos1_y = -1;
    public static float beginTablePos2_x = -4;
    public static float beginTablePos2_y = 1;
    public static float beginTablePos3_x = 2;
    public static float beginTablePos3_y = 1;

    //Content
    public static string Player = "Player";
    public static string Popup = "Popup";
    public static string CookingArea = "CookingArea";
    public static string CookingMenu = "Menu";
    public static string Customer = "Customer";
    public static string Cleaner = "Cleaner";
    public static string FirstPopup = "FirstPopup";
    public static string EndPopup = "EndPopup";
    public static string Food = "Food";
    public static string PlayerFood = "PlayerFood";
    public static string Table = "Table";

    //food
    public static string Food_0 = "Cheese";
    public static int Food_0_Value = 1;
    public static string Food_1 = "Banana";
    public static int Food_1_Value = 2;
    public static string Food_2 = "Sauce";
    public static int Food_2_Value = 3;

    //shop
    public static int Table_value = 1;
    public static int Tree_value = 5;



    public static int Vfx_walking = 0;
    public static int Vfx_bell = 1;
    public static int Vfx_click = 2;
    public static int Vfx_drop = 3;
    public static int Vfx_finish = 4;
    public static int Vfx_clear = 5;

    public static float PlayerSpeed = 5.0f;
    public static float CameraSmoothSpeed = 2.0f;

    public static float MaxHeal = 10f;
    public static float CustomerReduceHealt = 0.05f;
    public static float CustomerIncreaseHealt = 1f;
    public static float UnHappyPoint = 1;
    public static float NormalPoint = 3;
    public static float HappyPoint = 6;


    public static float PlayerGizmosRange = 1.5f;
    public static float GreenObjGizmosRange = 1f;
    public static float HealerValue = 1f;
    public static float RedObjGizmosRange = 1f;
    public static float RedObjDamage = 1f;

    public static float minWaitingTimeCCSpawn = 3f;
    public static float maxWaitingTimeCCSpawn = 6f;


}