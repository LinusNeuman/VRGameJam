﻿using UnityEngine;
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
    private float delay;
    private float shakeTimer;
    private float shakeTimeGoal;
    private Quaternion originalRotation;

    public void Activate()
    {
        shaking = true;
        delay = 0.0f;
        originalRotation = gameObject.transform.rotation;
        shakeTimeGoal = Random.Range(shakeTimeMin, shakeTimeMax);
        GetComponent<waveSimulation>().Pause();
    }

	// Use this for initialization
	void Start ()
    {
        shaking = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shaking == true)
        {
            if (delay >= 1.5f)
            {
                Vector3 newShake;

                newShake.x = Random.Range(-magnitude, magnitude);
                newShake.y = Random.Range(-magnitude, magnitude);
                newShake.z = Random.Range(-magnitude, magnitude);

                gameObject.transform.rotation = Quaternion.Euler(newShake);

                shakeTimer += Time.deltaTime;

                if (shakeTimer >= shakeTimeGoal)
                {
                    gameObject.transform.rotation = originalRotation;
                    shaking = false;
                    shakeTimer = 0.0f;
                    GetComponent<waveSimulation>().Unpause();
                    GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                delay += Time.deltaTime;
            }
        }
    }
}
