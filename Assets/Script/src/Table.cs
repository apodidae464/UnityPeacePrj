using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector2 position;
    public GameObject customer;
    public GameObject enemy;

    GameObject cc;

    bool shouldActiveCustomer, shouldSpawnEnemy;

    float spawnDuration;
    float EnemySpawnDuration;
    bool canSpawn;
    bool inActive;


    public void Awake()
    {

    }
    private void Start()
    {
        canSpawn = false;
        spawnDuration = Random.Range(Consts.minWaitingTimeCCSpawn, Consts.maxWaitingTimeCCSpawn);
        shouldActiveCustomer = true;
        shouldSpawnEnemy = false;
        cc = Instantiate(customer, transform.GetChild(0).gameObject.transform.position, transform.rotation);
        cc.SetActive(false);
        position = transform.position;
        EnemySpawnDuration = Random.Range(3, 5);
        
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
            spawnDuration = Random.Range(Consts.minWaitingTimeCCSpawn, Consts.maxWaitingTimeCCSpawn);
            shouldActiveCustomer = true;
            inActive = false;
        }

        if(Player.instance.levelPlus > 2 && shouldSpawnEnemy)
        {
            enemy.SetActive(true);
            shouldSpawnEnemy = false;
        }

        if(!enemy.activeInHierarchy)
        {
            EnemySpawnDuration -= Time.deltaTime;
            if(EnemySpawnDuration < 0)
            {
                shouldSpawnEnemy = true;
                EnemySpawnDuration = Random.Range(3, 5);
            }
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

    private void OnDestroy()
    {

    }
}