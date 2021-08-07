using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ingameCanvas : MonoBehaviour {

    public GameObject panelPause, panelEnd, boutonSound, boutonVibration;
    public bool soundOn = true, VibrationOn = true;
    public Sprite m1, m0, v1, v0;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        CheckSoundAndVibrationOnStart();
    }

    // Update is called once per frame


    public void CheckSoundAndVibrationOnStart()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundOn = true;
        }
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
            VibrationOn = true;
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundOn = false;
            //this.gameObject.GetComponent<AudioSource>().volume = 0;
            boutonSound.GetComponent<Image>().overrideSprite = m0;

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundOn = true;
            //this.gameObject.GetComponent<AudioSource>().volume = 0.5f;
            boutonSound.GetComponent<Image>().overrideSprite = m1;

        }

        if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            PlayerPrefs.SetInt("Vibration", 0);
            VibrationOn = false;
            boutonVibration.GetComponent<Image>().overrideSprite = v0;

        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 1);
            VibrationOn = true;
            boutonVibration.GetComponent<Image>().overrideSprite = v1;

        }
    }

    public void openPausePanel()
    {

        if (panelPause.activeInHierarchy)
        {
            panelPause.SetActive(false);
            GameObject.Find("Swipe").GetComponent<SwipeTrail>().canPlay = true;
            Time.timeScale = 1;
            StartCoroutine("dontMouseUp");
            
        }
        else
        {
            GameObject.Find("Swipe").GetComponent<SwipeTrail>().canPlay = false;

            Time.timeScale = 0;
            panelPause.SetActive(true);
        }


    }

    public void BoutonSound()
    {
        if (soundOn)
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundOn = false;
            //this.gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("audio").GetComponent<AudioSource>().Stop();
            boutonSound.GetComponent<Image>().overrideSprite = m0;

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundOn = true;
            //this.gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("audio").GetComponent<AudioSource>().Play();
            boutonSound.GetComponent<Image>().overrideSprite = m1;
        }
    }
    public void BoutonVibration()
    {
        if (!VibrationOn)
        {
            PlayerPrefs.SetInt("Vibration", 1);
            VibrationOn = true;
            boutonVibration.GetComponent<Image>().overrideSprite = v1;

        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 0);
            VibrationOn = false;
            boutonVibration.GetComponent<Image>().overrideSprite = v0;

        }



    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Next()
    {
        int i = 0;
        string nextScene = "";
        System.Int32.TryParse(SceneManager.GetActiveScene().name, out i);
        if (i == 21)
        {
            nextScene = "1";
        }
        else
        {
            nextScene = (i + 1).ToString();
        }
        SceneManager.LoadScene(nextScene);
    }

    public IEnumerator dontMouseUp()
    {

        yield return new WaitForSeconds(0.1f);
        GameObject.Find("Swipe").GetComponent<SwipeTrail>().mouseUp = false;
    }







    //--------------
}
