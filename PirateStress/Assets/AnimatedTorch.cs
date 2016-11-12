using UnityEngine;
using System.Collections;

public class AnimatedTorch : MonoBehaviour {

    [SerializeField]
    private float myFlickerAmount;
    [SerializeField]
    private Light myLight;
    private float myLightGoal;

	// Use this for initialization
	void Start ()
    {
        myLightGoal = Random.Range(1.0f, 2.25f);
        myLight.intensity = .75f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (myLight.intensity < myLightGoal)
        {
            myLight.intensity += Time.deltaTime * myFlickerAmount;
        }
        else
        {
            myLight.intensity -= Time.deltaTime * myFlickerAmount;
        }

        if(Random.Range(0.0f, 100.0f) < 50.0f)
        {
            myLightGoal = Random.Range(1.0f, 2.25f);
        }
	}
}
