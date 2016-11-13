using UnityEngine;
using System.Collections;

public class takeHit : MonoBehaviour
{
    [SerializeField]
    private float magnitude;

    [SerializeField]
    private float shakeTimeMin;
    [SerializeField]
    private float shakeTimeMax;

    [SerializeField]
    private bool shaking;
    private bool playSound;
    private bool shakeRampUp;
    private float delay;
    private float shakeRamp;
    private float shakeTimer;
    private float shakeTimeGoal;
    private Quaternion originalRotation;

    public void Activate()
    {
        shaking = true;
        playSound = true;
        shakeRampUp = true;
        shakeRamp = 0.0f;
        delay = 0.0f;
        originalRotation = gameObject.transform.rotation;
        shakeTimeGoal = Random.Range(shakeTimeMin, shakeTimeMax);
        GetComponent<waveSimulation>().Pause();
    }

	// Use this for initialization
	void Start ()
    {
        shaking = false;
        playSound = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shaking == true)
        {
            if (delay >= 1.5f)
            {
                if(playSound == true)
                {
                    playSound = false;
                    GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
                    GetComponent<AudioSource>().Play();
                }

                Vector3 newShake;

                newShake.x = Random.Range(-magnitude, magnitude) * shakeRamp;
                newShake.y = Random.Range(-magnitude, magnitude) * shakeRamp;
                newShake.z = Random.Range(-magnitude, magnitude) * shakeRamp;

                if(shakeRamp >= shakeTimeGoal / 2)
                {
                    shakeRampUp = false;
                }

                if(shakeRampUp == true)
                {
                    shakeRamp += Time.deltaTime * (shakeTimeGoal / 2);
                }
                else
                {
                    shakeRamp -= Time.deltaTime * (shakeTimeGoal / 2);
                }

                gameObject.transform.rotation = Quaternion.Euler(newShake);

                shakeTimer += Time.deltaTime;

                if (shakeTimer >= shakeTimeGoal)
                {
                    gameObject.transform.rotation = originalRotation;
                    shaking = false;
                    shakeTimer = 0.0f;
                    GetComponent<waveSimulation>().Unpause();
                }
            }
            else
            {
                delay += Time.deltaTime;
            }
        }
    }
}
