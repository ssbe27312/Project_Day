using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_Spawner : MonoBehaviour
{
    public GameObject ImagePrefab;

    int rnd;

    public float spawnRate;
    private float timeAfterSpawn;

    private Transform target;

    void Start()
    {
        timeAfterSpawn = 0.0f;
        spawnRate = 5.0f;
        rnd = Random.Range(0, 4);
        target = GameObject.FindGameObjectWithTag("trash1").transform;
        
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0.0f;
            GameObject Image = Instantiate(ImagePrefab, transform.position, Quaternion.identity);
            Image.transform.LookAt(target);
        }
    }
}
