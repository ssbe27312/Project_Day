using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Load_Data_30 : MonoBehaviour
{
    string str1;
    string[] str_element;


    public float p_30 = 0.0f; //각 초 마다 불러오는 30hz 값

    public float p_beta = 0.0f; //각 초 마다 불러오는 Beta 값

    public float sum_30 = 0.0f; //10초 동안의 30hz 값 누적 합

    public float sum_beta = 0.0f; //10초 동안 의 Beta 값 누적 합

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

        for (int i = 0; i < 10; i++)
        {
            FileStream fs1 = new FileStream("C:/Users/ssbe2/Desktop/13_17_30_data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);

            str1 = sr1.ReadLine();
            str_element = str1.Split(new char[] { '\t' });
            hz30_b = Single.TryParse(str_element[2], out p_30);
            beta_b = Single.TryParse(str_element[3], out p_beta);

            sum_30 += p_30; //해당 초의 30hz 값을 누적 합산
            sum_beta += p_beta;

            

            sr1.Close();
            fs1.Close();

            yield return new WaitForSeconds(1.0f);
        }

        r_avg_30 = sum_30 / 10.0f;
        r_avg_beta = sum_beta / 10.0f;

        sum_30 = 0.0f;
        sum_beta = 0.0f;

        FileStream fs2 = new FileStream("C:/Users/ssbe2/30_r.txt", FileMode.Create);
        StreamWriter sw1 = new StreamWriter(fs2);
        sw1.WriteLine("{0} \t {1}", r_avg_30, r_avg_beta);


        sw1.Close();
        fs2.Close();

        yield return null;
    }
}
