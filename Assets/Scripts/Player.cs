using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform point;
    float Ypos;

    void Start()
    {
        Ypos = transform.position.y;
    }


    void Update()
    {
        //testeo de movimiento
        if (Input.GetKeyDown(KeyCode.D))
        {
            point.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            point.position += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            point.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            point.position += Vector3.back;
        }
        if (transform.position != point.position)
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * speed);
    }
}
