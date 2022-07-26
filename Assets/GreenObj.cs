using System.Collections;
using UnityEngine;

public class GreenObj : MonoBehaviour
{
    public float range = 1.0f;
    public float Healer = 1f;
    private bool isInrange = false;

    private void Start()
    {
    }

    private void inRange()
    {
        StartCoroutine(WaitSomeSecond(1));
        Player.Instance.MoodIndexIncrease(Healer * 0.01f);
    }

    private void Update()
    {
        if (Vector2.Distance(Player.Instance.gameObject.transform.position, gameObject.transform.position) <= range)
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
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private IEnumerator WaitSomeSecond(int value)
    {
        yield return new WaitForSeconds(value);
    }
}