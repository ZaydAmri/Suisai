using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrail : MonoBehaviour {

    public bool test=false;
    
    
    public GameObject prefab;

    private int coinsNumber = 0;
    private int coinsCounter=0;
    private Collider2D SpecialCollider = null;
    private bool SpecialColliderBool = false;
    

    Plane objPlane;

    private List<Vector2> mousePositionList;
    private List<Vector2> distances;
    public bool mouseUp = false;
    private int i = 0, j = 0;
    private int frequence = 2;
    private swipeGameManager manager;
    private TrailRenderer trail;
    private Collider2D coll;
    public bool gameStart = false;
    private bool validShape = false;
    private bool endWait = false;
    public bool canPlay = true, drag = false;

    public float myTime = 0f;
    private GameObject pausePanel;

    //--------------
    private Vector3 mouseStartPosition = Vector3.zero;
    private Vector3 mousePosition = Vector3.zero;
    private Vector3 mouseEndPosition = Vector3.zero;

    void Awake()
    {
        pausePanel = GameObject.Find("Pause Panel");
        manager = GameObject.Find("SwipeGameManager").GetComponent<swipeGameManager>();
        trail = GetComponent<TrailRenderer>();
        coll = GetComponent<Collider2D>();
        coinsNumber = manager.coinsNeeded;
        TestTime();
    }

    // Use this for initialization
    void Start () {


        trail.enabled = false;
        coll.enabled = false;
        
        
        mousePositionList = new List<Vector2>();
        distances = new List<Vector2>();
        StartCoroutine(waitOneSecond());
        //this.transform.position = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {

        if (pausePanel.activeInHierarchy)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
        }



        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) )
        {

            if (Input.touchCount > 0)
            {
                mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else
            {
                mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            Click();
        }

        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)) && canPlay && !gameStart)
        {
            
            if (trail.enabled == false)
            {
                trail.enabled = true;
            }

            if (coll.enabled == false)
            {
                coll.enabled = true;
            }

            if (Input.touchCount > 0)
            {
                int touchCount = Input.touchCount;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCount - 1).position);
            }
            else
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            Drag();

        }

        
        if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && canPlay && drag)
        {
            drag = false;

            if (Input.touchCount > 0)
            {
                int touchCount = Input.touchCount;
                mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCount - 1).position);

            }
            else
            {
                mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
            //--
            mouseUp = true;
             
       }




            if (mouseUp && !SpecialColliderBool && !gameStart && validShape)
            {
                
                gameStart = true;
                Debug.Log("start after releasing the mouse button");
                mouseUp = false;


            }
            else if(mouseUp && SpecialColliderBool && !gameStart && validShape)
            {
            print("aa");
            SpecialTrigger(SpecialCollider);
            gameStart = true;
            mouseUp = false;
            }
            
            if (mouseUp && !gameStart && canPlay)
            {
            print("az");
            destroyIt();
            }
            
            if (gameStart)
            {
            myTime += Time.deltaTime; 
            
            TestColor();
            Repeat();
            }
        //}

        
	}

    public void Click()
    {
        if(mouseStartPosition.x > 7.5f && mouseStartPosition.y > 3.5f)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
        }

        if (pausePanel.activeInHierarchy)
        {
            canPlay = false;
        }
        else
        {
            canPlay = true;
        }
    }

    public void Drag()
    {
        //print("aaaee");
        mousePosition.z = 0;
        mousePositionList.Add(mousePosition);
        int count = mousePositionList.Count;
        this.transform.position = mousePosition;
        if (count > 1)
        {
            Vector2 newDistance = new Vector2(mousePositionList[count - 1].x - mousePositionList[count - 2].x, mousePositionList[count - 1].y - mousePositionList[count - 2].y);

            distances.Add(newDistance);
            if (Mathf.Abs(mousePositionList[count - 1].x - mousePositionList[0].x) > 0.6f || Mathf.Abs(mousePositionList[count - 1].y - mousePositionList[0].y) > 0.6f)
            {
                validShape = true;
                drag = true;
            }

        }
    }
    public void Release()
    {

    }


    public void Repeat()
    {

        if (canPlay)
        {
            if (i < distances.Count)
            {
                this.transform.position = new Vector2(this.transform.position.x + distances[i].x, this.transform.position.y + distances[i].y);

                i++;
            }
            if (i == distances.Count)
            {
                i = 0;
                j++;
            }

        }




    }

    private void destroyIt()
    {
        GameObject newprefab = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);

        if (pausePanel.transform.parent.gameObject.GetComponent<ingameCanvas>().VibrationOn)
        {
            Handheld.Vibrate();
        }

        
        Destroy(this.gameObject);
        Debug.Log("died");
        manager.UpdateCompteur();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if(!mouseUp && other.CompareTag("coins"))
        {
            print("special");
            SpecialCollider = other;
            SpecialColliderBool = true;
            print(other.gameObject.name);
        }


        if (gameStart && other.CompareTag("coins") )
        {
            other.enabled = false;

            coinsCounter++;

            if (coinsCounter == coinsNumber)
            {
                trail.enabled = false;
                coll.enabled = false;
            }


            other.GetComponent<CoinScript>().destroyCoin();
            
            
        }

        if (other.CompareTag("obstacle") )
        {
            print("az1");
            destroyIt();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("coins") && !gameStart && SpecialColliderBool)
        {

            print("az2");
            destroyIt();
            //destroyIt();
        }

        
    }
    public void SpecialTrigger(Collider2D _other)
    {
        _other.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        coinsCounter++;
        _other.GetComponent<CoinScript>().destroyCoin();
        SpecialColliderBool = false;
    }

    void TestTime()
    {
        if (test)
        {
            trail.time = 20;
        }
    }

    void TestColor()
    {
        if (test)
        {
            trail.material.color = new Color32(130, 130, 255, 255);
        }
    }
     private IEnumerator waitOneSecond()
     {
         yield return new WaitForSeconds(0.3f);
         Debug.Log("end wait");
         endWait = true;
     }

    private IEnumerator waitForObstacle()
    {

        yield return new WaitForSeconds(0.3f);
        Debug.Log("end wait");
        endWait = true;
    }


   


    //------------------------------------------
}
