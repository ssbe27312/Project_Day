using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelMainOrRe : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("18_Recording");
    }
    public void GotoMain()
    {
        SceneManager.LoadScene("02_Room_Main");
    }
}
