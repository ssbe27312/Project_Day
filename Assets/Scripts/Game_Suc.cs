using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Suc : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("11_Book_ERP_Game");
    }
}
