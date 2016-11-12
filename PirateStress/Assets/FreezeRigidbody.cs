using UnityEngine;
using System.Collections;

public class FreezeRigidbody : MonoBehaviour {

	void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
	}
}
