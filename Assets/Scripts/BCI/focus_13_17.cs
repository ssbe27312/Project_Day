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

    public int ssvep_state = 0; //���� �Ǵ� ����. 0 -> �߸�, 1 -> 13�� ����, 2 -> 17�� ����


    public float p_13 = 0.0f; //�� �� ���� �ҷ����� 13hz ��
    public float p_17 = 0.0f; //�� �� ���� �ҷ����� 17hz ��
    //float p_30 = 0.0f; //�� �� ���� �ҷ����� 30hz ��

    float sum_13 = 0.0f; //10�� ������ 13hz �� ���� ��
    float sum_17 = 0.0f; //10�� ������ 17hz �� ���� ��
    //float sum_30 = 0.0f; //10�� ������ 30hz �� ���� ��

    public float r_avg_13 = 0.0f; //�߸� ���¿����� 13hz ��� ��
    public float r_avg_17 = 0.0f; //�߸� ���¿����� 17hz ��� ��
    //float r_avg_30 = 0.0f; //�߸� ���¿����� 30hz ��� ��

    public float p_avg_13 = 0.0f; //���� ���¿����� 13hz ��� ��
    public float p_avg_17 = 0.0f; //���� ���¿����� 17hz ��� ��
    //float p_avg_30 = 0.0f; //���� ���¿����� 30hz ��� ��


    bool hz13_b; //13hz�� �ҷ����� ���� boolean
    bool hz17_b; //17hz�� �ҷ����� ���� boolean
    //bool hz30_b; //30hz�� �ҷ����� ���� boolean





    void Start()
    {
        

        StartCoroutine(ReadFile()); //�ش� scene���� ��ȯ�Ǿ��� �� ����

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

            sum_13 += p_13; //�ش� ���� 13hz ���� ���� �ջ�
            sum_17 += p_17; //�ش� ���� 17hz ���� ���� �ջ�

            

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
