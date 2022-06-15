using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Event : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("03_Book_ERP_Game");
    }
}
