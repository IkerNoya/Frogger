using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float carAngle;

    public List<GameObject> cars = new List<GameObject>();
    public List<Transform> spawnPoints = new List<Transform>();

    float spawnTimer = 2;
    float timer = 2;

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            Spawn();
            timer = 0;
            spawnTimer = Random.Range(1.5f, 3);
        }
    }
    void Spawn()
    {
        int spawnChoice = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[spawnChoice];
        int choice = Random.Range(0, cars.Count);
        StartCoroutine(SelectCar(choice));
        Instantiate(cars[choice], spawnPoint.position, spawnPoint.rotation);
    }
    IEnumerator SelectCar(int choice)
    {
        while (cars[choice].activeSelf)
        {
            choice = Random.Range(0, cars.Count);
            yield return null;
        }
        yield return null;
    }
}
