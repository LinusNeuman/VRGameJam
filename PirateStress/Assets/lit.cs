using UnityEngine;
using System.Collections;

public class lit : MonoBehaviour
{
    private ParticleSystem myPartSys;
    private Light myLight;
	// Use this for initialization
	void Start ()
    {
        myPartSys = GetComponent<ParticleSystem>();
        myLight = transform.FindChild("light").GetComponent<Light>();
        myPartSys.Stop();
        myLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponentInParent<torch>().GetLit() == true && myPartSys.isStopped == true)
        {
            myPartSys.Play();
            myLight.enabled = true;
        }
	}
}
