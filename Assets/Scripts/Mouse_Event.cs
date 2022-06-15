using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Mouse_Event : MonoBehaviour
{

    private float timer;
    private float dead_time;

    void Start()
    {
        timer = 0.0f;
        dead_time = 5.0f;
    }

    public void GoToGame() // 책 이외에 다른 객체를 누르면 뜨는 씬
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (clickObject != null)
        {
            if ((clickObject.name == "flower" || clickObject.name == "dog" || clickObject.name == "heart") && Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("13_Go_Back");
        }
    }

    public void WiseSayingToGame() // 명언 등장 후 다음 게임을 시작 
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (clickObject != null)
        {
            if (SceneManager.GetActiveScene().name == "10_Wise_Saying")
            {
                if (clickObject.name == "GoToGame" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("11_Book_ERP_Game");
            }

            if (SceneManager.GetActiveScene().name == "14_Wise_Saying")
            {
                if (clickObject.name == "GoToGame" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("12_Book_ERP_Game");
            }

            if (SceneManager.GetActiveScene().name == "15_Wise_Saying")
            {
                if (clickObject.name == "GoToGame" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("08_Window_Streaming");
            }

        }
    }

    public void GoToWiseSaying() // 각 씬에서 책을 누르면 명언 씬 등장
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (clickObject != null)
        {
            if (SceneManager.GetActiveScene().name == "03_Book_ERP_Game" && 
                clickObject.name == "book" && 
                Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("10_Wise_Saying");

            if (SceneManager.GetActiveScene().name == "11_Book_ERP_Game" &&
                clickObject.name == "book" &&
                Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("14_Wise_Saying");

            if (SceneManager.GetActiveScene().name == "12_Book_ERP_Game" &&
                clickObject.name == "book" &&
                Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("15_Wise_Saying");

        }
    }

    public void Restart() // 게임 내에서 버튼을 누르면 재시작
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (clickObject != null)
        {
            if(SceneManager.GetActiveScene().name == "03_Book_ERP_Game")
            {
                if (clickObject.name == "Restart" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("03_Book_ERP_Game");
            }

            if(SceneManager.GetActiveScene().name == "11_Book_ERP_Game")
            {
                if (clickObject.name == "Restart" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("11_Book_ERP_Game");
            }

            if (SceneManager.GetActiveScene().name == "12_Book_ERP_Game")
            {
                if (clickObject.name == "Restart" && Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("12_Book_ERP_Game");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        GoToGame();
        GoToWiseSaying();
        WiseSayingToGame();
        Restart();
    }
}
