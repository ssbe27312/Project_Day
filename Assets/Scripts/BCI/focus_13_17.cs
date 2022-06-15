using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class focus_13_17 : MonoBehaviour
{


    string str1;
    string[] str_element;

    public int call_cnt = 0;
    public int suc_cnt = 0;

    public int ssvep_state = 0; //상태 판단 변수. 0 -> 중립, 1 -> 13에 집중, 2 -> 17에 집중


    public float p_13 = 0.0f; //각 초 마다 불러오는 13hz 값
    public float p_17 = 0.0f; //각 초 마다 불러오는 17hz 값
    //float p_30 = 0.0f; //각 초 마다 불러오는 30hz 값

    float sum_13 = 0.0f; //10초 동안의 13hz 값 누적 합
    float sum_17 = 0.0f; //10초 동안의 17hz 값 누적 합
    //float sum_30 = 0.0f; //10초 동안의 30hz 값 누적 합

    public float r_avg_13 = 0.0f; //중립 상태에서의 13hz 평균 값
    public float r_avg_17 = 0.0f; //중립 상태에서의 17hz 평균 값
    //float r_avg_30 = 0.0f; //중립 상태에서의 30hz 평균 값

    public float p_avg_13 = 0.0f; //집중 상태에서의 13hz 평균 값
    public float p_avg_17 = 0.0f; //집중 상태에서의 17hz 평균 값
    //float p_avg_30 = 0.0f; //집중 상태에서의 30hz 평균 값


    bool hz13_b; //13hz를 불러오기 위한 boolean
    bool hz17_b; //17hz를 불러오기 위한 boolean
    //bool hz30_b; //30hz를 불러오기 위한 boolean





    void Start()
    {
        

        StartCoroutine(ReadFile()); //해당 scene으로 전환되었을 때 실행

    }



    IEnumerator ReadFile()
    {
        FileStream fs_cnt1 = new FileStream("C:/Users/ssbe2/Game_cnt.txt", FileMode.Create);
        StreamWriter sw_cnt1 = new StreamWriter(fs_cnt1);
        sw_cnt1.WriteLine("0 \t 0");

        sw_cnt1.Close();
        fs_cnt1.Close();


        for (int i = 0; i < 10; i++)
        {
            FileStream fs1 = new FileStream("C:/Users/ssbe2/Desktop/13_17_30_data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);

            str1 = sr1.ReadLine();
            str_element = str1.Split(new char[] { '\t' });
            hz13_b = Single.TryParse(str_element[0], out p_13);
            hz17_b = Single.TryParse(str_element[1], out p_17);
            //hz30_b = Single.TryParse(str_element[2], out p_30);

            sum_13 += p_13; //해당 초의 13hz 값을 누적 합산
            sum_17 += p_17; //해당 초의 17hz 값을 누적 합산

            

            sr1.Close();
            fs1.Close();

            yield return new WaitForSeconds(1.0f);
        }

        p_avg_13 = sum_13 / 10.0f;
        p_avg_17 = sum_17 / 10.0f;

        sum_13 = 0.0f;
        sum_17 = 0.0f;

        FileStream fs2 = new FileStream("C:/Users/ssbe2/13_17_r.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr2 = new StreamReader(fs2);
        str1 = sr2.ReadLine();
        str_element = str1.Split(new char[] { '\t' });
        hz13_b = Single.TryParse(str_element[0], out r_avg_13);
        hz17_b = Single.TryParse(str_element[1], out r_avg_17);

        if (r_avg_17 < p_avg_17)
        {
            ssvep_state = 2;
        }
        if (r_avg_13 < p_avg_13)
        {
            if (ssvep_state == 0)
                ssvep_state = 1;
            else
                ssvep_state = 2;
        }
        else
            ssvep_state = 1;


        sr2.Close();
        fs2.Close();

        if (ssvep_state == 1)
        {
            FileStream fs_cnt2 = new FileStream("C:/Users/ssbe2/Game_cnt.txt", FileMode.Create);
            StreamWriter sw_cnt2 = new StreamWriter(fs_cnt2);
            call_cnt++;
            suc_cnt++;
            sw_cnt2.WriteLine("{0} \t {1}", call_cnt, suc_cnt);

            sw_cnt2.Close();
            fs_cnt2.Close();
            SceneManager.LoadScene("10_Wise_Saying");
        }

        else if (ssvep_state == 2)
        {
            FileStream fs_cnt2 = new FileStream("C:/Users/ssbe2/Game_cnt.txt", FileMode.Create);
            StreamWriter sw_cnt2 = new StreamWriter(fs_cnt2);
            call_cnt++;
            sw_cnt2.WriteLine("{0} \t {1}", call_cnt, suc_cnt);

            sw_cnt2.Close();
            fs_cnt2.Close();
            SceneManager.LoadScene("13_Go_Back");
        }
        yield return null;
    }
}
