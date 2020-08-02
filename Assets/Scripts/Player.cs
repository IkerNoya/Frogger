using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEditor.UI;
using UnityEngine;

public class Player : FrogController
{
    [SerializeField] float speed;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject Blood;

    public Transform point;
    float minDistance = 0.01f;
    float lives = 3;
    float maxLives = 3;
    bool isPaused = false;
    bool isDead = false;

    public delegate void Pause();
    public static event Pause pause;
    public delegate void Victory();
    public static event Victory victory;
    float distance;

    Vector3 InitialPos;
    void Start()
    {
        InitialPos = transform.position;
    }
    void Update()
    {
        if (isPaused || isDead)
            return;
        distance = Vector3.Distance(transform.position, point.position);
        Idle();
        //testeo de movimiento
        if (Input.GetKeyDown(KeyCode.D) && distance < minDistance)
        {
            point.position += Vector3.right;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.W) && distance < minDistance)
        {
            point.position += Vector3.forward;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.A) && distance < minDistance)
        {
            point.position += Vector3.left;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S) && distance < minDistance)
        {
            point.position += Vector3.back;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
        if (transform.position != point.position)
        {
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }
    public void Restart()
    {
        transform.position = InitialPos;
        point.position = InitialPos;
        lives = maxLives;
    }
    void Respawn()
    {
        transform.position = InitialPos;
        point.position = InitialPos;
        lives--;
    }
    public void SetIsPaused(bool choice)
    {
        isPaused = choice;
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }
    IEnumerator DeadCoroutine()
    {
        Body.SetActive(false);
        Blood.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Body.SetActive(true);
        Blood.SetActive(false);
        isDead = false;
        Respawn();
        yield return null;
    }
    void Die()
    {
        isDead = true;
        StartCoroutine(DeadCoroutine());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Victory"))
        {
            victory();
        }
    }
}
