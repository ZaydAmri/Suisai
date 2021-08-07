using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Camera camera;
    public float DesignAspectHeight;
    public float DesignAspectWidth;

    
    public void Start()
    {
        camera.aspect = 16f / 9f;
    }


    

}
