using System.Collections;

using UnityEngine;

public class ObstacleScript : MonoBehaviour {


    private swipeGameManager manager;
    public Transform thisTransform;
    public Vector3 thisScale;
    public bool animate = false;
   
    // Use this for initialization
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
        thisScale = thisTransform.localScale;
        manager = GameObject.Find("SwipeGameManager").GetComponent<swipeGameManager>();
    }

    void Start () {
        thisTransform.localScale = Vector3.zero;
        PlayObstacle();
    }
	
	// Update is called once per frame
	void Update () {
		//²while(thisScale.x<=)
	}

    public void PlayObstacle()
    {
        StartCoroutine(PlayCoroutine(1));
        //thisTransform.localScale = Vector3.Lerp(thisTransform.localScale, Vector3.zero, Time.deltaTime);

    }




    private IEnumerator PlayCoroutine(float _time)
    {
        float time = _time;
        float time2 = _time;
        while (time > 0.0f)
        {
            time -= Time.deltaTime;


            transform.localScale = Vector3.Lerp(thisTransform.localScale, thisScale , Time.deltaTime );

            yield return 0;
        }
        



    }

    //-----------------------------
}
