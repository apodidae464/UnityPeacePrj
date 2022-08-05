using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector2 position;
    public GameObject customer;
    GameObject cc;

    bool shouldActiveCustomer;

    float spawnDuration;
    bool canSpawn;

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

    }

    private void Prapre()
    {

    }

    private void Update()
    {
        if (!GameEvents.isStart)
            return;
        position = this.transform.position;
        if (shouldActiveCustomer)
        {
            spawnDuration -= Time.deltaTime;
        }

        if (spawnDuration < 0)
        {
            spawnDuration = Random.Range(Constaint.minWaitingTimeCCSpawn, Constaint.maxWaitingTimeCCSpawn);
            shouldActiveCustomer = false;
            canSpawn = true;
        }

        if(!cc.activeInHierarchy)
        {
            shouldActiveCustomer = true;
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