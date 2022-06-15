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


    public float p_30 = 0.0f; //�� �� ���� �ҷ����� 30hz ��

    public float p_beta = 0.0f; //�� �� ���� �ҷ����� Beta ��

    public float sum_30 = 0.0f; //10�� ������ 30hz �� ���� ��

    public float sum_beta = 0.0f; //10�� ���� �� Beta �� ���� ��

    public float r_avg_30 = 0.0f; //�߸� ���¿����� 30hz ��� ��

    public float r_avg_beta = 0.0f; //�߸� ���¿����� beta ��� ��


    bool hz30_b; //30hz�� �ҷ����� ���� boolean

    bool beta_b; //Beta�� �ҷ����� ���� boolean





    void Start()
    {
        StartCoroutine(ReadFile()); //�ش� scene���� ��ȯ�Ǿ��� �� ����
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

            sum_30 += p_30; //�ش� ���� 30hz ���� ���� �ջ�
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
