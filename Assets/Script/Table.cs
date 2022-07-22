using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector2 position;
    public bool isFull;


    public void Awake()
    {
        //GameCore.Instance._tableList.Add(this);
    }

    void Start()
    {
        position = new Vector2(0.0f, 0.0f);
        GameCore.Instance._tableList.Add(this);
    }

    private void Update()
    {
        position = this.transform.position;
       
    }



}
