using UnityEngine;
using System.Collections;

public class windzoneAboveLock : MonoBehaviour
{
    [SerializeField]
    private float myDistance;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = transform.parent.position;

        newPos.y += myDistance;

        transform.position = newPos;
	}
}
