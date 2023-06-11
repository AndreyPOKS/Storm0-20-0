using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] objects;
    public List<Transform> spawnPoints;
    private float Timer = 1;
    private float TimerForUnity = 0;

    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);

    }

    void Update(){
        if (TimerForUnity <= 0){
            Spawn();
            TimerForUnity = Timer;
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