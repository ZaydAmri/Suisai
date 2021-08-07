
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelSelection : MonoBehaviour {

    // Use this for initialization
    public void reset()
    {
        PlayerPrefs.DeleteAll();
        
        PlayerPrefs.Save();
        print("a");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
