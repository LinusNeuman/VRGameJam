using UnityEngine;
using System.Collections;

public class FuseScript : MonoBehaviour {

    [SerializeField]
    private CannonScript myCannonScript = null;
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
            myCannonScript.Shot(collision);
        }
    }
}
