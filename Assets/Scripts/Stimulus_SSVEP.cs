using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stimulus_SSVEP : MonoBehaviour
{
    public GameObject SSVEP;
    float Hz;

    void Start()
    {
        StartCoroutine(EMarkerGrid());
        //17Hz½Ã
        Hz = 0.06f;

        //14Hz½Ã
        //Hz = 0.08f;

        //33HZ½Ã
        //Hz = 0.03f;
    }
    IEnumerator EMarkerGrid()
    {
        while (true)
        {
            this.SSVEP.SetActive(false);
            yield return new WaitForSeconds(Hz);
            this.SSVEP.SetActive(true);
            yield return new WaitForSeconds(0.01f);
        }

    }

    void Update()
    {

    }
}
