using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {


    public float smoothness = 0.01f;
    public float duration = 1f;
    public GameObject sound;

    // Use this for initialization
    void Start () {
        StartCoroutine("SolveCoroutine");
        
    }
    
    private IEnumerator StartingCoroutine()
    {





        yield return new WaitForSeconds(1.5f);
        
    }

    private IEnumerator SolveCoroutine()
    {
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.
        //gameObject.GetComponent<Renderer>().material.SetFloat("_Level", 0.12f);
        while (progress < 1.05f)
        {

            gameObject.transform.GetChild(0).GetComponent<SpriteMask>().alphaCutoff = Mathf.Lerp(1, 0, progress);
            //currentColor = Color.Lerp(Color.red, Color.blue, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("dissolveCoroutine");
        //Destroy(this.gameObject);
        //manager.UpdateCollected();

        //---------------------

    }
    private IEnumerator dissolveCoroutine()
    {
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.
        //gameObject.GetComponent<Renderer>().material.SetFloat("_Level", 0.12f);
        while (progress < 1.05f)
        {

            gameObject.transform.GetChild(0).GetComponent<SpriteMask>().alphaCutoff = Mathf.Lerp(0, 1, progress);
            //currentColor = Color.Lerp(Color.red, Color.blue, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        yield return new WaitForSeconds(0.5f);
        sound.GetComponent<AudioSource>().Stop();
        sound.GetComponent<AudioSource>().volume = 0.2f;
        sound.GetComponent<AudioSource>().Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainScene");
        //Destroy(this.gameObject);
        //manager.UpdateCollected();

        //---------------------

    }
}
