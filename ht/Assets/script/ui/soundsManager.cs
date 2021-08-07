using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsManager : MonoBehaviour {

    private AudioSource audioSource;
        void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = false;
    }
	
	// Update is called once per frame
	void Update () {
     mute( audioSource);    }
    public void mute(AudioSource audioSource)
    {
        audioSource.mute = !audioSource.mute;
    }

    
}
