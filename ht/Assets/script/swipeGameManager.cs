
using UnityEngine;

using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.UI;

public class swipeGameManager : MonoBehaviour {

    public int compteur = 0, coins = 0;

    public int scene = 0;

    public int nextLevel;
    private Text textNiveau;
    public int coinsNeeded = 0;
    private levelDetails leveldetail;
    SwipeTrail swiper;
    private Text niveauText,levelNumber, bestTimePauseText, levelNumberEnd, bestTimeEndText, currentTimeEndText;
    private GameObject Waiting, endPanel, congratImage, newBestTimeImage, pausePanel;

    
    public float bestScore;
    void Awake() {

        niveauText = GameObject.Find("Niveau text").GetComponent<Text>();
        levelNumber = GameObject.Find("levelNumber").GetComponent<Text>();
        bestTimePauseText = GameObject.Find("best time pause text").GetComponent<Text>();
        levelNumberEnd = GameObject.Find("level Number End").GetComponent<Text>();
        bestTimeEndText = GameObject.Find("best time end text").GetComponent<Text>();
        currentTimeEndText = GameObject.Find("current time end text").GetComponent<Text>();

        Waiting = GameObject.Find("initialization");
        endPanel = GameObject.Find("end Panel");
        pausePanel = GameObject.Find("Pause Panel");
        congratImage = GameObject.Find("congratulation");
        newBestTimeImage = GameObject.Find("new best time");
        swiper = GameObject.Find("Swipe").GetComponent<SwipeTrail>();
        

    }

    
    void Start () {

        congratImage.SetActive(false);
        newBestTimeImage.SetActive(false);
        endPanel.SetActive(false);
        pausePanel.SetActive(false);

        Waiting.SetActive(true);
        leveldetail = this.GetComponent<levelDetails>();
        Int32.TryParse(SceneManager.GetActiveScene().name, out scene);
        GetStats();
        niveauText.text = scene.ToString();
        levelNumber.text = scene.ToString();
        levelNumberEnd.text = scene.ToString();
        leveldetail.sceneName = scene.ToString();
        if (bestScore == 50f)
        {
            bestTimePauseText.text = "...";
            bestTimeEndText.text = "...";
        }
        else
        {
            bestTimePauseText.text = bestScore.ToString();
            bestTimeEndText.text = bestScore.ToString();
        }

        

        leveldetail.Activate();
        StartCoroutine(StartingCoroutine());

        //nextLevel = scene + 1;
        //textNiveau = GameObject.Find("Niveau").GetComponent<UnityEngine.UI.Text>();
        // textNiveau.text = "Niveau " + scene.ToString();
        //leveldetail.thisLevel.

    }

    // Update is called once per frame
    public void GetStats()
    {
        bestScore = PlayerPrefs.GetFloat("highscore" + scene.ToString());
        print(bestScore);
        
    }

    public void UpdateCompteur()
    {
        compteur++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void UpdateCollected()
    {
        coins++;
        

        if (coins == coinsNeeded)
        {
            float i = swiper.myTime;
            i = i * 10;
            int j = Mathf.FloorToInt(i);
            i = (float)j / 10;
            
            currentTimeEndText.text = i.ToString();

            if (i < bestScore)
            {
                bestScore = i;
                bestTimeEndText.text = bestScore.ToString();
                PlayerPrefs.SetFloat("highscore" + scene.ToString(), i);
                PlayerPrefs.Save();
                congratImage.SetActive(true);
                newBestTimeImage.SetActive(true);

            }
            else
            {
                bestTimeEndText.text = bestScore.ToString();
            }


            endPanel.SetActive(true);
        }
    }

    private IEnumerator StartingCoroutine()
    {
        
        yield return new WaitForSeconds(1.5f);
        Waiting.SetActive(false);
        swiper.enabled = true;
    }





}
