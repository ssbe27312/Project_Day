using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class test2 : MonoBehaviour
{
    DateTime StartDate;

    string path_name = "";

    string str1;
    string[] str_element;
    float hz30 = 0; // 14hz
    float hz17 = 0;

    bool hz17_b;
    bool hz30_b;

    bool check = true;

    void Start()
    {
        StartDate = DateTime.Now;

        int timeDay = StartDate.Day;
        int timeHour = StartDate.Hour;
        int timeMinute = StartDate.Minute;

        int refined_hour = StartDate.Hour;

        if (timeHour > 12)
        {
            refined_hour = (timeHour - 12) % 12;
            path_name = StartDate.ToString("yyyy-MM-dd_" + "오후 " + refined_hour.ToString() + "_mm");
        }
        else if(timeHour == 12)
        {
            path_name = StartDate.ToString("yyyy-MM-dd_오후 HH_mm");
        }
        else
        {
            refined_hour = (timeHour + 12) % 12;
            path_name = StartDate.ToString("yyyy-MM-dd_" + "오전 " + refined_hour.ToString() + "_mm");
        }

        /*
        if (check)
        {
            check = false;
            StartCoroutine(ReadFile(path_name));
        }
        */
    }

    void Update()
    {
        if (check)
        {
            check = false;
            StartCoroutine(ReadFile(path_name));
        }
    }

    IEnumerator ReadFile(string pn) // After 30s, read and write
    {
        pn = path_name;

        yield return new WaitForSeconds(35.0f);

        FileStream fs1 = new FileStream("C:/MAVE_RawData/" + path_name + "/Fp1_FFT.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr1 = new StreamReader(fs1);

        FileStream fs2 = new FileStream("C:/MAVE_RawData/" + path_name + "/res_test.txt", FileMode.Create);
        StreamWriter sw1 = new StreamWriter(fs2);

        sw1.WriteLine("17Hz \t 30Hz");

        while ((str1 = sr1.ReadLine()) != null)
        {
            str_element = str1.Split(new char[] { '\t' });

            hz17_b = Single.TryParse(str_element[5 * 17 - 1], out hz17);
            hz30_b = Single.TryParse(str_element[5 * 30 + 1], out hz30);

            sw1.WriteLine("{0} \t {1}", hz17, hz30);

            /*
            try
            {
                str_element = str1.Split(new char[] { '\t' });

                hz17_b = Single.TryParse(str_element[5 * 17 - 1], out hz17);
                hz30_b = Single.TryParse(str_element[5 * 30 + 1], out hz30);

                sw1.WriteLine("{0} \t {1} ", hz17, hz30);
            }

            catch (FormatException e)
            {
                Debug.Log(e.Message);
            }
            */

        }

        sr1.Close();
        sw1.Close();

        check = true;
    }
}
