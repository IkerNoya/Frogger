using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform point;
    float Ypos;
    float minDistance = 0.01f;
    public delegate void Pause();
    public static event Pause pause;
    public delegate void Victory();
    public static event Victory victory;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Victory")
        {
            victory();
        }
    }
}
