using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Fail : MonoBehaviour
{
    string str1;
    string[] str_element;

    public int call_cnt = 0;
    bool call_cnt_b;


    void Start()
    {
        FileStream fs_cnt1 = new FileStream("C:/Users/ssbe2/Game_cnt.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr_cnt1 = new StreamReader(fs_cnt1);

        str1 = sr_cnt1.ReadLine();
        str_element = str1.Split(new char[] { '\t' });
        call_cnt_b = Int32.TryParse(str_element[0], out call_cnt);
    }




    public void ScenChange()
    {
        if (call_cnt == 1)
            SceneManager.LoadScene("11_Book_ERP_Game");
        else if (call_cnt == 2)
            SceneManager.LoadScene("12_Book_ERP_Game");
        else if (call_cnt == 3)
            SceneManager.LoadScene("16_Book_ERP_Game");//³× ¹øÂ° °ÔÀÓ ¾À
        else if (call_cnt == 4)
            SceneManager.LoadScene("17_Book_ERP_Game");//´Ù¼¸¹øÂ° °ÔÀÓ ¾À
    }
}
