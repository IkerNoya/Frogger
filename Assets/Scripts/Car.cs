using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    GameManager manager;

    float speed;
    bool destination = false;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        Vector3 movement = transform.forward * speed;
        transform.position += movement * Time.deltaTime;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }
    public bool GetDestination()
    {
        return destination;
    }
    public void SetDestination(bool value)
    {
        destination = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndRoad"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Car"))
        {
            speed = other.gameObject.GetComponent<Car>().GetSpeed();
        }
    }
}
