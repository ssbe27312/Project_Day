using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foo_07_Event : MonoBehaviour
{
    public float studytime = 10.0f;

    void Start()
    {
        StartCoroutine("finstudy"); //�ش� scene���� ��ȯ�Ǿ��� �� ����
    }

    IEnumerator finstudy()
    {
        yield return new WaitForSeconds(studytime);
        SceneManager.LoadScene("18_Recording");
    }
}
