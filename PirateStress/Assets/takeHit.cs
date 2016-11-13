using UnityEngine;
using System.Collections;

public class takeHit : MonoBehaviour
{
    [SerializeField]
    private float magnitude;

    [SerializeField]
    private float shakeTime;

    private bool shaking;
    private float shakeTimer;
    private Quaternion originalRotation;

    public void Activate()
    {
        shaking = true;
    }

	// Use this for initialization
	void Start ()
    {
        shaking = false;
        originalRotation = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shaking == true)
        {
            Vector3 newShake;

            newShake.x = Random.Range(-magnitude, magnitude);
            newShake.y = Random.Range(-magnitude, magnitude);
            newShake.z = Random.Range(-magnitude, magnitude);

            gameObject.transform.rotation = Quaternion.Euler(newShake);

            shakeTimer += Time.deltaTime;

            if(shakeTimer >= shakeTime)
            {
                gameObject.transform.rotation = originalRotation;
                shaking = false;
                shakeTimer = 0.0f;
            }
        }
    }
}
