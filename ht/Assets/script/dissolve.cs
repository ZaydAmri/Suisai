using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolve : MonoBehaviour {

    public bool startWithSolve = false;
    private bool startFinished = false;
    public float smoothness = 0.1f;
    public float duration = 1f;
    public float startDissolving;
    public float startSolving;
    public float waitAfterDissolve = 0.05f;


    void Start()
    {
       
    }

    void Update()
    {
        if (startWithSolve && !startFinished)
        {
            SolveIt();
            startFinished = true;
        }
        
    }
    public void DissolveIt()
    {
        StartCoroutine("DissolveCoroutine");
    }

    public void SolveIt()
    {
        StartCoroutine("SolveCoroutine");
    }

    private IEnumerator DissolveCoroutine()
    {
        
        float progress = 0; 
        float increment = smoothness / duration; 
        gameObject.GetComponent<Renderer>().material.SetFloat("_Level", startDissolving);
        while (progress < 1.05f)
        {

            gameObject.GetComponent<Renderer>().material.SetFloat("_Level", Mathf.Lerp(startDissolving, 1, progress));
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        yield return new WaitForSeconds(0.5f);
       //Destroy(this.gameObject);
        
    }
    
    private IEnumerator SolveCoroutine()
    {
        float progress = 0;
        float increment = smoothness / duration;
        gameObject.GetComponent<Renderer>().material.SetFloat("_Level", startSolving);
        //print(gameObject.GetComponent<Renderer>().material.GetFloat("_Level"));
        while (progress < 1.05f && gameObject.GetComponent<Renderer>().material.GetFloat("_Level") > 0)
        {

            gameObject.GetComponent<Renderer>().material.SetFloat("_Level", Mathf.Lerp(startSolving, 0, progress));
            print(gameObject.GetComponent<Renderer>().material.GetFloat("_Level"));
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        while (progress < 1.05f && gameObject.GetComponent<Renderer>().material.GetFloat("_Edges") > 0)
        {

            gameObject.GetComponent<Renderer>().material.SetFloat("_Level", Mathf.Lerp(startSolving, 0, progress));
            print(gameObject.GetComponent<Renderer>().material.GetFloat("_Level"));
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        yield return new WaitForSeconds(0.5f);
        //print("a");

    }


    //--------------------------------------
}
