using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawn : MonoBehaviour
{
    [Header("Элементы массива")]
    public GameObject[] objects;
    public List<Transform> spawnPoints;
    [Header("Настройка случайного спавна")]
    public float Timer;
    private float TimerForUnity = 0;
    private float RandNumber;

    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);

    }

    void Update(){
        if (TimerForUnity <= 0){
            RandNumber = Random.Range(5.0f, Timer);
            Spawn();
            TimerForUnity = RandNumber;
        }
        else{
            TimerForUnity -=Time.deltaTime;
        }
    }
    void Spawn()
    {

        for ( int i = 0; i < objects.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(objects[i], spawnPoints[spawn].transform.position, Quaternion.identity);
        }
    }
    
}