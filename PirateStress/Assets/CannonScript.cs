using UnityEngine;
using System.Collections;

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
}
