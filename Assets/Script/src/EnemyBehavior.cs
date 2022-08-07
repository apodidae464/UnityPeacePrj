using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(decreaseHealOfPlayer());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    public void DecreaseHeal()
    {
        Debug.Log("DECREASE HEALL");

        GameEvents.instance.HealBarDecrease(Consts.CustomerReduceHealt * 3);

    }
    IEnumerator decreaseHealOfPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            DecreaseHeal();
        }

    }
}
