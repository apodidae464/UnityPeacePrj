﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform taget;
    [SerializeField] private float smoothSpeed = 2.0f;
    private Vector2 screenBounds;
    private void Start()
    {
        taget = GameObject.FindGameObjectWithTag(AllTag.Player).GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void Update()
    {
        //Tranform.position for camera
        transform.position = Vector3.Lerp(transform.position, new Vector3(taget.position.x, taget.position.y, transform.position.z), smoothSpeed * Time.deltaTime);
    }

    
}