using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private bool myIsActive = false;

    private Animator myAnimator;
    private Rigidbody myCannonShot;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Reload()
    {
        if (myCannonShot != null)
        {
            myCannonShot.AddForce(-32, 0, 0, ForceMode.Impulse);
        }
        myAnimator.SetBool("IsReloading", true);
    }

    public void Shot(Collider aCollider)
    {
        myCannonShot = aCollider.GetComponent<Rigidbody>();
        myAnimator.SetBool("IsReloading", false);
    }

    internal bool GetIsReloading()
    {
        return myAnimator.GetBool("IsReloading");
    }
}
