using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainscene_levelSelection : MonoBehaviour {

    
    
    
    
    
    

    //------------------------
    private float time = 0;
    private float angle = 0;
    private bool soundOn = true,VibrationOn = true;
    Vector3 rotation1;
    public GameObject panelSetiings,panelLevels, boutonSound, boutonVibration, settingsPicture, playPicture,contentPanel;
    public bool rotate = false;
    public Sprite m1, m0, v1, v0;
	void Start () {

        Time.timeScale = 1;
        
        CheckSoundAndVibrationOnStart();



    }

    void Update ()
    {
        RotationFunction();
    }

    
    public void RotationFunction()
    {
        if (rotate)
        {
            time += Time.deltaTime * 70;
            angle += Time.deltaTime * 5;
            rotation1 = new Vector3(0, 0, time);

            playPicture.transform.eulerAngles = rotation1;
            
            settingsPicture.transform.eulerAngles = new Vector3(0, 0, 5 * Mathf.Sin(angle));
            
        }
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
            GameObject.Find("audio").GetComponent<AudioSource>().Stop();
            //this.gameObject.GetComponent<AudioSource>().volume = 0;
            boutonSound.GetComponent<Image>().overrideSprite = m0;
            
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundOn = true;
            GameObject.Find("audio").GetComponent<AudioSource>().Play();
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

    public void openLevelSelection()
    {

        if (panelLevels.activeInHierarchy)
        {
            panelLevels.SetActive(false);
            foreach(Transform b in contentPanel.transform)
            {
                b.gameObject.GetComponent<levelDetailsInSelection>().ChangeColor();
            }
        }
        else
        {
            panelLevels.SetActive(true);
        }


    }

    public void openMainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    
    public void ButtonSettings()
    {
        if (panelSetiings.activeInHierarchy)
        {
            panelSetiings.SetActive(false);
        }
        else
        {
            panelSetiings.SetActive(true);
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
    public void BoutonRateUs()
    {
        //Application.OpenURL("http://play.google.com/store/apps/details?id=" + Application.bundleIdentifier);
        Application.OpenURL("http://play.google.com/") ;
        //Application.OpenURL("market://details?id=com.Hallogamie.CoinPong/");
    }

    public void BoutonSite()
    {
        
        Application.OpenURL("http://day1studio.com/");
        //Application.OpenURL("market://details?id=com.Hallogamie.CoinPong/");
    }
    public void BoutonFollowFacebook()
    {
        Application.OpenURL("https://www.facebook.com/hallogamie/");

    }
    public void BoutonFollowInstagram()
    {
        Application.OpenURL("https://www.instagram.com/hallogamie/");

    }
    public void PrintTest()
    {
        print("test");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    

    //--------------------------------------
}
