using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;
    private void Start()
    {
        speed = 5;
    }
    private void Update()
    {
        Vector3 movement = new Vector3(speed, 0, 0);
        transform.position += movement * Time.deltaTime;
    }
}
