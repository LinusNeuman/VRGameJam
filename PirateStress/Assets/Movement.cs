using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.AddForce(new Vector3(100, 0, 0));
    }

	void FixedUpdate()
    {

	}
}
