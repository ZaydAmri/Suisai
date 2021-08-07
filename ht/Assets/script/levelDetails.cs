
using UnityEngine;
using UnityEngine.UI;

public class levelDetails : MonoBehaviour {

    public string sceneName;
    

    

    public int unlocked;
    

    // Use this for initialization
    void Awake () {
        

    }
	
   
    
    public void Activate()
    {
        unlocked = 1;
        PlayerPrefs.SetInt("unlocked" + sceneName, 1);
        //PlayerPrefs.SetString("lastLevelPlayed", sceneName);
        PlayerPrefs.Save();
    }

    public void Desactivate()
    {
        
    }

}
