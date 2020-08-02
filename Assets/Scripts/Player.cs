
using System.Collections;
using UnityEngine;

public class Player : FrogController
{
    [SerializeField] float speed;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject Blood;
    Rigidbody rb;

    public Transform point;
    float minDistance = 0.01f;
    int lives = 3;
    int maxLives = 3;
    bool isPaused = false;
    bool isDead = false;
    float maxX = 8;
    float minX = -6;
    float minZ = 1;

    public delegate void Pause();
    public static event Pause pause;
    public delegate void Victory();
    public static event Victory victory;
    public delegate void GameOver();
    public static event GameOver gameOver;
    float distance;

    Vector3 InitialPos;
    Vector3 ClampMovement;
    void Start()
    {
        InitialPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Time.timeScale == 0 || isDead)
            return;

        distance = Vector3.Distance(transform.position, point.position);
        Idle();
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && point.position.x < maxX && distance < minDistance)
        {
            point.position += Vector3.right;
            Jump();
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && distance < minDistance)
        {
            point.position += Vector3.forward;
            Jump();
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && point.position.x > minX && distance < minDistance)
        {
            point.position += Vector3.left;
            Jump();
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && point.position.z > minZ && distance < minDistance)
        {
            point.position += Vector3.back;
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
            Time.timeScale = 0;
        }
        if (transform.position != point.position)
        {
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * speed);
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
        lives--;
        if (lives <= 0)
        {
            Restart();
            gameOver();
        }
        else
        {
            transform.position = InitialPos;
            point.position = InitialPos;
        }
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
        rb.isKinematic = true;
        yield return new WaitForSeconds(3.0f);
        rb.isKinematic = false;
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

    public int GetLives()
    {
        return lives;
    }
    public void SetLives(int value)
    {
        lives = value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Victory"))
        {
            victory();
            lives = maxLives;
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Car"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }
}
