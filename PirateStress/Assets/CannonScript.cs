using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private bool myIsActive = false;

    private Animator myAnimator;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Reload()
    {
        myAnimator.SetBool("IsReloading", true);
    }

    public void Shot()
    {
        myAnimator.SetBool("IsReloading", false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Shot();
    }

    internal bool GetIsReloading()
    {
        return myAnimator.GetBool("IsReloading");
    }
}
