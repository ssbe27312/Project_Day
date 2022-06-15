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

    int ssvep_state = 0; //���� �Ǵ� ����. 0 -> �߸�, 1 -> 30�� ����


    public float p_30 = 0.0f; //�� �� ���� �ҷ����� 30hz ��

    public float p_beta = 0.0f; //�� �� ���� �ҷ����� Beta ��

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
