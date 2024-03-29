﻿using System.Collections;
using System.Threading;
using UnityEngine;

public class RedObj : MonoBehaviour
{
    private bool isInrange = false;

    private void inRange()
    {
        StartCoroutine(WaitSomeSecond(1));
        GameEvents.instance.HealBarDecrease(Consts.RedObjDamage * 0.01f);
    }

    private void Update()
    {
        if (Vector2.Distance(Player.instance.GetPosition(), gameObject.transform.position) <= Consts.RedObjGizmosRange)
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Consts.RedObjGizmosRange);
    }
    private IEnumerator WaitSomeSecond(int value)
    {
        yield return new WaitForSeconds(value);
    }
}