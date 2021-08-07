
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;





public class levelDetailsInSelection : MonoBehaviour {


    public string sceneName;
    private int sceneNumber;

    public Text levelNameText;
    public Text bestScoreText;
    public GameObject unlockedPicture,timePicture;
    

    public int unlocked;
    public float bestScore = 20;
    public bool newnew = false;
    public byte[,] colorTab = { { 255,184,184,255}, {255,156,156,255}, {255,113,113,255}, {255,192,144,255}, {128,190,216,255},
    {94,137,188,255},{174,135,188,255},{249,149,111,255},{114,216,165,255},{122,182,182,255}};
    
   

    void Awake()
    {

        sceneName = this.gameObject.name;
        Int32.TryParse(sceneName, out sceneNumber);
        

        //this.GetComponentInChildren<Text>().text = sceneName;

        if (!PlayerPrefs.HasKey("highscore" + sceneName))
        {
            
            PlayerPrefs.SetInt("unlocked" + sceneName, 0);
            PlayerPrefs.SetFloat("highscore" + sceneName, 50f);
            
            if (sceneNumber == 1)
            {
                PlayerPrefs.SetInt("unlocked" + sceneName, 1);
                unlocked = 1;
                Debug.Log("done 1");
            }

            PlayerPrefs.Save();
            newnew = true;
            Debug.Log("save");

        }
        else
        {
            unlocked = PlayerPrefs.GetInt("unlocked" + sceneName);
            bestScore = PlayerPrefs.GetFloat("highscore" + sceneName);
            
            
        }
        
        
    }
    // Use this for initialization
    void Start () {

        ChangeColor();

        if (unlocked==1)
            {
            unlockedPicture.SetActive(false);
            timePicture.SetActive(true);
            levelNameText.text = sceneName;

            if (newnew || bestScore==50)
            {
                bestScoreText.text = "...";
                newnew = false;
            }
            else
            {
                bestScoreText.text = bestScore.ToString();
            }
            
            

        }
            else
            {
            unlockedPicture.SetActive(true);
            timePicture.SetActive(false);
            levelNameText.text = "";
            bestScoreText.text = "";
        }


        }

    public void LoadScene()
    {
        if (unlocked==1)
        {
            SceneManager.LoadScene(sceneName);
        }

    }

    public void ChangeColor()
    {
        int i = UnityEngine.Random.Range(0, 9);

        gameObject.GetComponent<Image>().color = new Color32(colorTab[i, 0], colorTab[i, 1], colorTab[i, 2], colorTab[i, 3]);
    }
    ///---------------------------
}
