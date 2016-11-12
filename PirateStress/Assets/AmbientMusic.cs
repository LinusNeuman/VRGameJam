using UnityEngine;
using System.Collections;

public class AmbientMusic : MonoBehaviour {

    [SerializeField]
    private AudioClip myWaves;

    private AudioSource myAudioSource;

    // Use this for initialization
    void Start () {

        gameObject.AddComponent<AudioSource>();

        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
        myAudioSource.clip = myWaves;
        myAudioSource.loop = true;
        myAudioSource.Play();

      //  myAudioSource.clip = mySeagulls;
      //  myAudioSource.loop = true;
      //  myAudioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
