using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float speed;
    Vector3 newPosition;
    void Update()
    {
        newPosition = new Vector3(player.position.x, transform.position.y, player.position.z + offset);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
