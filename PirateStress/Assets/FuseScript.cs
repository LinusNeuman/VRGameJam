using UnityEngine;
using System.Collections;

public class FuseScript : MonoBehaviour {

    [SerializeField]
    private CannonScript myCannonScript = null;

    [SerializeField]
    private ParticleSystem myFuseEmitter;

    [SerializeField]
    private AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Torch")
        {
            if(collision.gameObject.GetComponent<torch>().GetLit() == true)
            {
                myAudioSource.Play();
                myFuseEmitter.Play();
                myCannonScript.Fire();
            }
        }
    }
}
