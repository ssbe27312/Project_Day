using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _30Focus_suc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gotoMain()); //해당 scene으로 전환되었을 때 실행
    }

    IEnumerator gotoMain()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("02_Room_Main");
    }
}
