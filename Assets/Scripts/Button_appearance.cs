using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_appearance : MonoBehaviour
{
    public GameObject Button;

    void Start()
    {
        this.Button.SetActive(false);
        StartCoroutine(Buttonview());

    }



    IEnumerator Buttonview()
    {
        yield return new WaitForSeconds(10);
        this.Button.SetActive(true);
    }

}
