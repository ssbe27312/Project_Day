using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeEffect : MonoBehaviour
{
	public float animTime = 2f;
	private Image fadeImage;

	private float start = 1f;
	private float end = 0f;
	private float time = 0f;

	public bool stopIn = false;
	public bool stopOut = true;

	void Awake()
	{
		fadeImage = GetComponent<Image>();
	}

	void Update()
	{
		if (stopIn == false && time <= 2)
		{
			PlayFadeIn();
		}
		if (stopOut == false && time <= 2)
		{
			PlayFadeOut();
		}
		if (time >= 2 && stopIn == false)
		{
			stopIn = true;
			time = 0;
			SceneManager.LoadScene("02_Room_Main");
		}
		if (time >= 2 && stopOut == false)
		{
			stopIn = false;
			stopOut = true;
			time = 0;
		}
	}

	void PlayFadeIn()
	{
		time += Time.deltaTime / animTime;

		Color color = fadeImage.color;

		if (color != null)
        {
			color.a = Mathf.Lerp(start, end, time);

			fadeImage.color = color;
		}


	}

	void PlayFadeOut()
	{
		time += Time.deltaTime / animTime;

		Color color = fadeImage.color;

		color.a = Mathf.Lerp(end, start, time);

		fadeImage.color = color;
	}
}