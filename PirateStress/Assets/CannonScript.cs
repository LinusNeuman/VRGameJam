﻿using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myCannonShot;
    private float myCooldownTimer = 0;
    private float myFireCooldownTimer = 0;

    private bool myIsReady = false;

    private GunpowderLogic.ePowderType myWishedPowderType;
    private CannonballLogic.eCannonballType myWishedCannonballType;

    private bool myHasGottenRightGunpowder = false;
    private bool myHasGottenRightCannonball = false;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();

        myWishedPowderType = GenerateWishedGunpowder();
        myWishedCannonballType = GenerateWishedCannonball();
    }

    GunpowderLogic.ePowderType GetWishedGunpowder()
    {
        return myWishedPowderType;
    }

    CannonballLogic.eCannonballType GetWishedCannonball()
    {
        return myWishedCannonballType;
    }

    GunpowderLogic.ePowderType GenerateWishedGunpowder()
    {
        if (UnityEngine.Random.Range(0, 1) == 0)
        {
            return GunpowderLogic.ePowderType.Normal;
        }
        else
        {
            return GunpowderLogic.ePowderType.HighExplosive;
        }
    }

    CannonballLogic.eCannonballType GenerateWishedCannonball()
    {
        if (UnityEngine.Random.Range(0, 1) == 0)
        {
            return CannonballLogic.eCannonballType.Cannonball;
        }
        else
        {
            return CannonballLogic.eCannonballType.Grapeshot;
        }
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
            if(myHasGottenRightCannonball == false || myHasGottenRightGunpowder == false)
            {
                return;
            }

            if (myCooldownTimer <= 0)
            {
                myCannonShot.AddForce(-40, 0, 0, ForceMode.Impulse);
                myCannonShot = null;

                myHasGottenRightGunpowder = false;
                myHasGottenRightCannonball = false;
            }
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
        if(aCollider.GetComponent<CannonballLogic>().GetCannonballType() == myWishedCannonballType)
        {
            myHasGottenRightCannonball = true;
            myCannonShot = aCollider.GetComponent<Rigidbody>();
            myCooldownTimer = 5.5f;
            myAnimator.SetBool("IsReloading", false);
            myIsReady = false;
        }
    }

    internal bool GetIsReloading()
    {
        return myAnimator.GetBool("IsReloading");
    }
}
