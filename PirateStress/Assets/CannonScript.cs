using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myCannonShot;
    private float myCooldownTimer = 0;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        myCooldownTimer -= Time.deltaTime;
        myCooldownTimer = Mathf.Max(0, myCooldownTimer);
    }

    public void Reload()
    {
        if (myCooldownTimer > 0.0f)
        {
            return;
        }

        if (myCannonShot != null)
        {
            myCannonShot.AddForce(-32, 0, 0, ForceMode.Impulse);
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
