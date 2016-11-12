using UnityEngine;
using System.Collections;

public class ShipSounds : MonoBehaviour {

    [SerializeField]
    private AudioSource[] myCreakSounds;
    // Use this for initialization

    private float myTimeSinceLastPlayOfCreakSound;
    private int myLastPlayedSound;
    private float myTimeToCheckFor;
    void Start () {
        myTimeSinceLastPlayOfCreakSound = 0.0f;
        myLastPlayedSound = 0;
        myTimeToCheckFor = Random.Range(3.0f, 8.0f);
    }
	
	// Update is called once per frame
	void Update () {
        myTimeSinceLastPlayOfCreakSound += Time.deltaTime;

        if(myTimeSinceLastPlayOfCreakSound >= myTimeToCheckFor)
        {
            myTimeToCheckFor = Random.Range(3.0f, 8.0f);
            myTimeSinceLastPlayOfCreakSound = 0.0f;
            int soundToPlay = Random.Range(0, myCreakSounds.Length);
            while (soundToPlay == myLastPlayedSound)
            {
                soundToPlay = Random.Range(0, myCreakSounds.Length);
            }
            myLastPlayedSound = soundToPlay;
            myCreakSounds[soundToPlay].pitch = Random.Range(0.5f, 1.5f);
            myCreakSounds[soundToPlay].Play();
        }
    }
}
