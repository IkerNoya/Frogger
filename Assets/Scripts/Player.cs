using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform point;
    float Ypos;
    float minDistance = 0.01f;

    void Start()
    {
        Ypos = transform.position.y;
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, point.position);
        //testeo de movimiento
        if (Input.GetKeyDown(KeyCode.D) && distance < minDistance)
        {
            point.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.W) && distance < minDistance)
        {
            point.position += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.A) && distance < minDistance)
        {
            point.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S) && distance < minDistance)
        {
            point.position += Vector3.back;
        }
        if (transform.position != point.position)
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * speed);
    }
}
