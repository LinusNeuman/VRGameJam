using UnityEngine;
using System.Collections;

public class oscillate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = gameObject.transform.position;

        pos.y += Mathf.Sin(Time.realtimeSinceStartup * 2) * 0.0025f;

        gameObject.transform.position = pos;
	}
}
