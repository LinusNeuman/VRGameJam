using UnityEngine;
using System.Collections;

public class DistantShipFire : MonoBehaviour {

    private float myTimerSinceShooting = 0.0f;

    [SerializeField]
    private float myFireCooldown = 0.0f;
    [SerializeField]
    private float myFireRandomAmount = 0.0f;

    private float myFireMaxTime = 0.0f;

    [SerializeField]
    private takeHit myTakeHitReference;
	// Use this for initialization
	void Start () {
        myFireMaxTime = Random.Range(myFireCooldown - myFireRandomAmount, myFireCooldown + myFireRandomAmount);
	}
	
	// Update is called once per frame
	void Update () {
        myTimerSinceShooting += Time.deltaTime;	

        if(myTimerSinceShooting >= myFireMaxTime)
        {
            myTimerSinceShooting = 0.0f;
            myFireMaxTime = Random.Range(myFireCooldown - myFireRandomAmount, myFireCooldown + myFireRandomAmount);

            // shoot
            Fire();
        }
	}

    void Fire()
    {
        transform.FindChild("SoundEffects").GetComponent<AudioSource>().Play();

        int chanceOfHit = Random.Range(0, 100);
       // if(chanceOfHit <= 15)
       // {
            myTakeHitReference.Activate();
       // }
    }
}
