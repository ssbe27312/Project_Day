using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGameOrSt : MonoBehaviour
{

    public void GameStartfrombook()
    {
        SceneManager.LoadScene("09_Recording");
    }
    public void studyingstartfrombook()
    {
        SceneManager.LoadScene("07_Studying");
    }

}
