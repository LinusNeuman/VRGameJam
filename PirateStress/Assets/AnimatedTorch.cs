using UnityEngine;
using System.Collections;

public class AnimatedTorch : MonoBehaviour {

    [SerializeField]
    private float myFlickerAmount;
    [SerializeField]
    private Light myLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        myLight.intensity = Mathf.Sin(Time.realtimeSinceStartup) + 1;
	}
}
