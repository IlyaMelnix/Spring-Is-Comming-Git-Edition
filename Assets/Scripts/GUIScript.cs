using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// Делал используя туториал: https://www.youtube.com/watch?v=wtQ1ylRLZsA
// Корутины и IEnumerator вместо Update: http://docs.unity3d.com/ru/current/Manual/Coroutines.html


public class GUIScript : MonoBehaviour
{
    public MusicManagerScript MusicManager;
    public GameObject PauseUI;
    public GameObject LossUI;
    public GameObject VictoryUI;
    public Button Music;
    public Button Restart;
    public Slider BeforeTheArrivalOfSpring;
    public Slider BurningIndicator;
    bool paused = false, music = true, sounds = true;


    public void PlayPause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            paused = false;

        }
        PauseUI.SetActive(paused);

    }

    public void MusicToggle()
    {
        if (!music)
        {
            MusicManager.SetVolume(1.0f);
            music = true;
        }
        else
        {
            MusicManager.SetVolume(0.0f);
            music = false;

        }
    }

    // Запускается каждые 10 секунд и уменьшает "горение" на единицу
    IEnumerator reduceFire()
    {
        while (true) //fireCounter >= 0
        {
            if (PlayerPrefs.HasKey("burning"))
            {
                PlayerPrefs.SetInt("burning", PlayerPrefs.GetInt("burning") - 1);
                PlayerPrefs.Save();
            }
            Debug.Log(PlayerPrefs.GetInt("burning"));
            yield return new WaitForSeconds(10.0f);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        BeforeTheArrivalOfSpring.value = 0;
        StartCoroutine(reduceFire());
        PauseUI.SetActive(paused);

        // Установка первоначального значения горения burning
        if (PlayerPrefs.HasKey("burning"))
        {
            PlayerPrefs.SetInt("burning", 5);
        }
        PlayerPrefs.Save();
    }

    void Update()
    {   
        // Установка значения индикатора горения
        if (PlayerPrefs.HasKey("burning"))
        {
            BeforeTheArrivalOfSpring.value = Mathf.MoveTowards(BeforeTheArrivalOfSpring.value, 100.0f, PlayerPrefs.GetInt("burning") * Time.deltaTime / 5);
            BurningIndicator.value = PlayerPrefs.GetInt("burning");
        }
        if (PlayerPrefs.GetInt("burning") == 0)
        {
            loss();
        }
        if (BeforeTheArrivalOfSpring.value == 100)
        {
            victory();
        }
    }

    void loss()
    {
        Time.timeScale = 0;
        LossUI.SetActive(true);
    }

    void victory()
    {
        Time.timeScale = 0;
        VictoryUI.SetActive(true);
    }

    public void restart ()
    {
        Application.LoadLevel(Application.loadedLevelName);   
    }

}

