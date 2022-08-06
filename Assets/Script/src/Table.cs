using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector2 position;
    public GameObject customer;
    GameObject cc;

    bool shouldActiveCustomer;

    float spawnDuration;
    bool canSpawn;
    bool inActive;

    public void Awake()
    {

    }
    private void Start()
    {
        canSpawn = false;
        spawnDuration = Random.Range(Constaint.minWaitingTimeCCSpawn, Constaint.maxWaitingTimeCCSpawn);
        shouldActiveCustomer = true;
        cc = Instantiate(customer, transform.GetChild(0).gameObject.transform.position, transform.rotation);
        cc.SetActive(false);
        position = transform.position;

    }

    private void Prapre()
    {

    }

    private void Update()
    {
        if (!GameEvents.isStart)
            return;
       
        if (shouldActiveCustomer)
        {
            spawnDuration -= Time.deltaTime;
            if (spawnDuration < 0)
            {
                shouldActiveCustomer = false;
                canSpawn = true;
            }

        }


        if (inActive && !cc.activeInHierarchy)
        {
            spawnDuration = Random.Range(Constaint.minWaitingTimeCCSpawn, Constaint.maxWaitingTimeCCSpawn);
            shouldActiveCustomer = true;
            inActive = false;
        }
    }

    private void FixedUpdate()
    {
        if(canSpawn)
        {
            cc.SetActive(true);
            cc.GetComponent<Customer>().OnCustomerActive();
            GameCore.Instance.numOfCustommer++;
            canSpawn = false;
            inActive = true;
        }
    }

    private void OnActiveCustomer(bool value)
    {
        shouldActiveCustomer = value;
    }

    

    private void OnDestroy()
    {

    }
}