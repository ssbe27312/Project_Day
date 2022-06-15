using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Image : MonoBehaviour
{

    public float speed = 1.0f;

    private float t = 0.0f;

    public float d_t = 6.5f;


    void Update()
    {
        t += Time.deltaTime;

        if (t < d_t)
        {
            transform.Translate(Vector3.right * speed);
        }

    }

    





    
}

// 속력 : 10.0f;
// 시간 : 11.5f;