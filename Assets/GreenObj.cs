using System.Collections;
using UnityEngine;

public class GreenObj : MonoBehaviour
{
    private bool isInrange = false;

    private void Start()
    {
    }

    private void inRange()
    {
        StartCoroutine(WaitSomeSecond(1));
        GameEvents.instance.HealBarIncrease(AllTag.HealerValue * 0.01f);
    }

    private void Update()
    {
        if (Vector2.Distance(Player.instance.GetPosition(), gameObject.transform.position) <= AllTag.GreenObjGizmosRange)
        {
            isInrange = true;
        }
        else
        {
            isInrange = false;
        }

        if (isInrange)
        {
            StartCoroutine(WaitSomeSecond(1));
            inRange();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AllTag.GreenObjGizmosRange);
    }

    private IEnumerator WaitSomeSecond(int value)
    {
        yield return new WaitForSeconds(value);
    }

  
}