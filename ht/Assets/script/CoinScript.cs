using System.Collections;

using UnityEngine;




public class CoinScript : MonoBehaviour {

    
    private swipeGameManager manager;
    public Transform thisTransform;
    public Vector3 thisScale;
    public bool animate = false;

    private bool startFinished = false;
    public float smoothness = 0.1f;
    public float duration = 1f;
    
    public float waitAfterDissolve = 0.05f;

    // Use this for initialization
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
        thisScale = thisTransform.localScale;
        manager = GameObject.Find("SwipeGameManager").GetComponent<swipeGameManager>();
    }
    void Start ()
    {
        if (animate)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteMask>().alphaCutoff = 1;
            StartCoroutine(SolveCoroutine(duration));
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void destroyCoin()
    {
        StartCoroutine(DestroyCoroutine(duration));
        //thisTransform.localScale = Vector3.Lerp(thisTransform.localScale, Vector3.zero, Time.deltaTime);
        
    }


   

    private IEnumerator DestroyCoroutine(float duration)
    {
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = 0.01f / duration; //The amount of change to apply.
        //gameObject.GetComponent<Renderer>().material.SetFloat("_Level", 0.12f);
        while (progress < 1.05f)
        {

            gameObject.transform.GetChild(0).GetComponent<SpriteMask>().alphaCutoff = Mathf.Lerp(0, 1, progress);
            //currentColor = Color.Lerp(Color.red, Color.blue, progress);
            progress += increment;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        manager.UpdateCollected();

        //---------------------
        
    }

    private IEnumerator SolveCoroutine(float duration)
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

        //Destroy(this.gameObject);
        //manager.UpdateCollected();

        //---------------------

    }
   
    //----------------------


}




