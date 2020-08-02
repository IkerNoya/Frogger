using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float speed;
    Vector3 newPosition;
    float leftScreenLimit = -2.5f;
    float rightScreenLimit = 4.5f;
    void Update()
    {
        Vector3 xOffset = player.position;
        xOffset.x = Mathf.Clamp(xOffset.x, leftScreenLimit, rightScreenLimit);
        newPosition = new Vector3(xOffset.x, transform.position.y, player.position.z + offset);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
