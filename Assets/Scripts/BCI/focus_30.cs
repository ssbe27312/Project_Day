using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class focus_30 : MonoBehaviour
{

    string str1;
    string[] str_element;

    int ssvep_state = 0; //상태 판단 변수. 0 -> 중립, 1 -> 30에 집중


    public float p_30 = 0.0f; //각 초 마다 불러오는 30hz 값

    public float p_beta = 0.0f; //각 초 마다 불러오는 Beta 값

    public float r_avg_30 = 0.0f; //중립 상태에서의 30hz 평균 값

    public float r_avg_beta = 0.0f; //중립 상태에서의 beta 평균 값

    bool hz30_b; //30hz를 불러오기 위한 boolean

    bool beta_b; //Beta를 불러오기 위한 boolean



    void Start()
    {
        StartCoroutine(ReadFile()); //해당 scene으로 전환되었을 때 실행
    }

    void Update()
    {

    }

    IEnumerator ReadFile()
    {

        yield return new WaitForSeconds(5.0f);

        FileStream fs2 = new FileStream("C:/Users/ssbe2/30_r.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr2 = new StreamReader(fs2);
        str1 = sr2.ReadLine();
        str_element = str1.Split(new char[] { '\t' });
        hz30_b = Single.TryParse(str_element[0], out r_avg_30);
        beta_b = Single.TryParse(str_element[0], out r_avg_beta);

        for (int i = 0; i < 20; i++)
        {
            FileStream fs1 = new FileStream("C:/Users/ssbe2/Desktop/13_17_30_data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);

            str1 = sr1.ReadLine();
            str_element = str1.Split(new char[] { '\t' });
            hz30_b = Single.TryParse(str_element[2], out p_30);
            beta_b = Single.TryParse(str_element[3], out p_beta);

            if (p_30 > r_avg_30)
            {
                ssvep_state = 1;
                break;
            }
            else if (p_beta > r_avg_beta)
            {
                ssvep_state = 1;
                break;
            }


            

            sr1.Close();
            fs1.Close();

            yield return new WaitForSeconds(1.0f);
        }

        if (ssvep_state == 1)
            SceneManager.LoadScene("19_Success_beta");
        else
            SceneManager.LoadScene("21_If_failed");


        sr2.Close();
        fs2.Close();

        yield return null;
    }
}
