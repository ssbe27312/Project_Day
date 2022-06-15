using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt_Effect : MonoBehaviour
{
    public float time;

    public Text text;

    int num;

    void Update()
    {
        time += Time.deltaTime;

        num = (int)time;

        switch (num)
        {
            case 1:
                {
                    text.text = "측정 중.";
                    break;
                }
            case 2:
                {
                    text.text = "측정 중..";
                    break;
                }
            case 3:
                {
                    text.text = "측정 중...";
                    time = 0.0f;
                    break;
                }

        }

    }
}
