using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myCannonShot;
    private float myCooldownTimer = 0;
    private float myFireCooldownTimer = 0;

    private bool myIsReady = false;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        myCooldownTimer -= Time.deltaTime;
        myCooldownTimer = Mathf.Max(0, myCooldownTimer);
        if (myCooldownTimer <= 0 && myIsReady == false)
        {
            if (myFireCooldownTimer == 0)
            {
                myFireCooldownTimer = 2.0f;
            }
            myFireCooldownTimer -= Time.deltaTime;
            myFireCooldownTimer = Mathf.Max(0, myFireCooldownTimer);

            if (myFireCooldownTimer <= 1.0f)
            {
                Fire();
            }

            if (myFireCooldownTimer <= 0.0f)
            {
                myIsReady = true;
            }
        }
    }

    public void Fire()
    {
        if (myCannonShot != null)
        {
            myCannonShot.AddForce(-32, 0, 0, ForceMode.Impulse);
            myCannonShot = null;
        }
    }

    public void Reload()
    {
        if (myCooldownTimer > 0.0f || myFireCooldownTimer > 0.0f)
        {
            return;
        }

        myAnimator.SetBool("IsReloading", true);
    }

    public void Shot(Collider aCollider)
    {
        myCannonShot = aCollider.GetComponent<Rigidbody>();
        myCooldownTimer = 5.5f;
        myAnimator.SetBool("IsReloading", false);
    }

    internal bool GetIsReloading()
    {
        return myAnimator.GetBool("IsReloading");
    }
}
