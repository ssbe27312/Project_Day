using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ServiceManager : MonoBehaviour
{

    /*
    public void GoToMain()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.name == "GoToMain" && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("02_Room_Main");
        }
    }
    */

    public void SceneChanger()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject != null)
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {

                case 1:
                    if (clickObject.name == "ERP_Game_Book" && Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("20_Select_Game_Or_Studying");
                    }

                    if (clickObject.name == "Assistant_Day" && Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("04_Day_Show_Recorded");
                    }

                    if (clickObject.name == "SSVEP_Lamp" && Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("18_Recording");
                    }

                    if (clickObject.name == "Settings_Something" && Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("06_Settings");
                    }

                    if (clickObject.name == "Streaming_Window" && Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("08_Window_Streaming");
                    }
                    break;

                    // Game 구현된 후(나중에 BCI로 수정해야됨)
                    /*
                    case 2:
                        if (Input.GetMouseButtonDown(0))
                        {
                            SceneManager.LoadScene("07_Studying");
                        }
                    break;

                    case 6:
                        if (Input.GetMouseButtonDown(0))
                        {
                            SceneManager.LoadScene("05_Lamp_SSVEP");
                        }
                    break;
                }
                    */
            }

            if (clickObject.name == "GoToMain" && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("02_Room_Main");
            }
        }
    }

    void Update()
    {
        SceneChanger();
    }
}