using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    public Transform point;
    float minDistance = 0.01f;
    float lives = 3;
    float maxLives = 3;

    public delegate void Pause();
    public static event Pause pause;
    public delegate void Victory();
    public static event Victory victory;
    bool isPaused = false;
    float distance;

    Vector3 InitialPos;
    void Start()
    {
        InitialPos = transform.position;
    }
    void Update()
    {
        if (isPaused)
            return;
        distance = Vector3.Distance(transform.position, point.position);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
        if (transform.position != point.position)
        {
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * speed);
        }
    }
    public void Respawn()
    {
        transform.position = InitialPos;
        point.position = InitialPos;
        lives = maxLives;
    }
    public void SetIsPaused(bool choice)
    {
        isPaused = choice;
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Victory"))
        {
            victory();
        }
    }
}
