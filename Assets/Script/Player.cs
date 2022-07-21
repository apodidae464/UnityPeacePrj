using UnityEngine;

public class Player : MonoBehaviour
{
    //Singleton
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //How to get method in Player
    //Player.Instance.MethodName(Param1,Param2);

    //Attribute of Player

    private bool isInGreenArea = false;
    private bool isInRedArea = false;

    public float range = 1.5f;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
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