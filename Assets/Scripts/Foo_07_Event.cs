using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foo_07_Event : MonoBehaviour
{
    public float studytime = 10.0f;

    void Start()
    {
        StartCoroutine("finstudy"); //해당 scene으로 전환되었을 때 실행
    }

    IEnumerator finstudy()
    {
        yield return new WaitForSeconds(studytime);
        SceneManager.LoadScene("18_Recording");
    }
}
