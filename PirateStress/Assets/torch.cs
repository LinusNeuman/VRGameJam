using UnityEngine;
using System.Collections;

public class torch : MonoBehaviour {

    [SerializeField]
    private bool litAsFuck;

    public bool GetLit()
    {
        return litAsFuck;
    }

    void OnTriggerEnter(Collider aCollider)
    {
        if(aCollider.tag == "Lighter")
        {
            litAsFuck = true;
        }
    }

	// Use this for initialization
	void Start ()
    {
        litAsFuck = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
