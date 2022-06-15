using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stm_ssvep : MonoBehaviour
{
    public GameObject SSVEP;
    public int Hz;
    float term;

    void Start()
    {
        StartCoroutine(EMarkerGrid());

        if (Hz == 13)
            term = 1.0f / 26.0f;
        else if (Hz == 17)
            term = 1.0f / 34.0f;
        else if (Hz == 30)
            term = 1.0f / 60.0f;
    }
    IEnumerator EMarkerGrid()
    {
        while (true)
        {
            this.SSVEP.SetActive(false);
            yield return new WaitForSeconds(term);
            this.SSVEP.SetActive(true);
            yield return new WaitForSeconds(term);
        }

    }

    void Update()
    {

    }
}
