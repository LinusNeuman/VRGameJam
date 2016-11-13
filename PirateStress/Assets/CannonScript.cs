using UnityEngine;
using System.Collections;
using System;

public class CannonScript : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myCannonShot;
    private float myCooldownTimer = 0;
    private float myFireCooldownTimer = 0;

    private bool myIsReady = true;

    private GunpowderLogic.ePowderType myWishedPowderType;
    private CannonballLogic.eCannonballType myWishedCannonballType;

    private bool myHasGottenRightGunpowder = false;
    private bool myHasGottenRightCannonball = false;

    private bool myIsFiring = false;
    private bool myTriggered = false;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();

        myWishedPowderType = GenerateWishedGunpowder();
        myWishedCannonballType = GenerateWishedCannonball();
    }

    public bool GetHasBall()
    {
        return myHasGottenRightCannonball;
    }
    public bool GetHasPowder()
    {
        return myHasGottenRightGunpowder;
    }

    public GunpowderLogic.ePowderType GetWishedGunpowder()
    {
        return myWishedPowderType;
    }

    public CannonballLogic.eCannonballType GetWishedCannonball()
    {
        return myWishedCannonballType;
    }

    GunpowderLogic.ePowderType GenerateWishedGunpowder()
    {
        if (UnityEngine.Random.Range(0, 20) >= 10)
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
        if (UnityEngine.Random.Range(0, 20) >= 10)
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

        if (myIsFiring == true)
        {
            myFireCooldownTimer -= Time.deltaTime;

            if (myFireCooldownTimer <= 6.8f && myTriggered == false)
            {
                myTriggered = true;
                myAnimator.SetTrigger("Fire");
            }

            if (myFireCooldownTimer <= 0)
            {
                if (myCannonShot != null)
                {
                    transform.FindChild("CannonBase").FindChild("CannonGun").FindChild("CannonLighter").FindChild("FuseParticle").GetComponent<ParticleSystem>().Stop();

                    transform.FindChild("SoundEffect").GetComponent<AudioSource>().Play();

                    myCannonShot.AddForce(-40, 0, 0, ForceMode.Impulse);
                    myCannonShot = null;

                    myHasGottenRightGunpowder = false;
                    myHasGottenRightCannonball = false;

                    myTriggered = false;

                    myWishedPowderType = GenerateWishedGunpowder();
                    myWishedCannonballType = GenerateWishedCannonball();

                    myFireCooldownTimer = 0;
                }
                myIsFiring = false;
                myIsReady = false;
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

            myFireCooldownTimer = 7.2f;
            myIsFiring = true;
        }
    }

    public void Reload()
    {
        if (myCooldownTimer <= 0.0f && myFireCooldownTimer <= 0.0f && myHasGottenRightCannonball == false && myHasGottenRightGunpowder == false && myIsFiring == false && myIsReady == false)
        {
            myIsReady = true;
            myAnimator.SetBool("IsReloading", true);
        }
    }

    public void Shot(Collider aCollider)
    {
        if(myHasGottenRightGunpowder == false)
        {
            return;
        }

        if(aCollider.GetComponent<CannonballLogic>().GetCannonballType() == myWishedCannonballType)
        {
            myHasGottenRightCannonball = true;
            myCannonShot = aCollider.GetComponent<Rigidbody>();
            myCooldownTimer = 5.5f;
            myAnimator.SetBool("IsReloading", false);
            myIsReady = false;
        }
    }

    public void FillPowder(Collider collision)
    {
        if (collision.GetComponent<GunpowderLogic>().GetPowderType() == myWishedPowderType)
        {
            myHasGottenRightGunpowder = true;
            Destroy(collision.gameObject);
        }
    }

    internal bool GetIsReloading()
    {
        return (myCooldownTimer > 0.0f || myFireCooldownTimer > 0.0f || myIsFiring == true || myHasGottenRightCannonball == true || myHasGottenRightGunpowder == true || myIsReady == true);
    }
}
