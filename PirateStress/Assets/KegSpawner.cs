using UnityEngine;
using System.Collections;

public class KegSpawner : MonoBehaviour {

    enum eKegType
    {
        Normal,
        HighExplosive
    };

    [SerializeField]
    private eKegType myKegType;
    [SerializeField]
    private float mySpawnRate;

    [SerializeField]
    private GameObject myNormalKeg;

    [SerializeField]
    private bool myShouldAnimate = false;

    [SerializeField]
    private Animator myAnimatorReferenceLeft;
    [SerializeField]
    private Animator myAnimatorReferenceRight;

    private float mySpawnTimer;
    private int mySpawnedInstances;
    private float myCloseAnimationTimer;
    [SerializeField]
    private float myCloseTimer;
    private bool myIsOpen;

    [SerializeField]
    private bool myKick = false;

    [SerializeField]
    private float myKickAmount = -17;
    // Use this for initialization
    void Start () {
        mySpawnTimer = 0.0f;
        mySpawnedInstances = 0;
        myCloseAnimationTimer = 0.0f;
        myIsOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        mySpawnTimer += Time.deltaTime;

	    if(mySpawnTimer >= mySpawnRate)
        {
            ++mySpawnedInstances;
            GameObject spawned = (GameObject)Instantiate(myNormalKeg, transform.position, Quaternion.Euler(90, 0, 0), transform);
            if (myKick == true)
            {
                spawned.GetComponent<Rigidbody>().AddForce(myKickAmount, 0, 0, ForceMode.Impulse);
            }
            mySpawnTimer = 0.0f;
        }

        if(mySpawnedInstances >= 3 && myShouldAnimate == true)
        {
            mySpawnedInstances = 0;
            myAnimatorReferenceLeft.SetBool("IsOpen", true);
            myAnimatorReferenceRight.SetBool("IsOpen", true);

            myCloseAnimationTimer = myCloseTimer;
            myIsOpen = true;
        }

        if (myIsOpen == true)
        {
            myCloseAnimationTimer -= Time.deltaTime;
            if (myCloseAnimationTimer <= 0.0f)
            {
                myIsOpen = false;
                myCloseAnimationTimer = 0.0f;
                myAnimatorReferenceLeft.SetBool("IsOpen", false);
                myAnimatorReferenceRight.SetBool("IsOpen", false);
            }
        }
	}
}
