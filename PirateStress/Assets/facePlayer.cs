using UnityEngine;
using System.Collections;

public class facePlayer : MonoBehaviour {

    [SerializeField]
    private Camera playerEyes;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.LookAt(playerEyes.transform.position);
	}
}
