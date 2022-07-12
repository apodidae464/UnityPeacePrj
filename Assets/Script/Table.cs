using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector2 position;
    public bool isFull;

    void Start()
    {
        //Initialise the vector
        position = new Vector2(0.0f, 0.0f);
    }

}
