using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonManager : MonoBehaviour {

    private List<CannonScript> myCannons = new List<CannonScript>();

    private float mySwitchCannonTimer = 0;

    void Start()
    {
        GameObject[] cannons = GameObject.FindGameObjectsWithTag("Cannon");
        for (int i = 0; i < cannons.Length; ++i)
        {
            myCannons.Add(cannons[i].GetComponent<CannonScript>());
        }
    }

    void Update()
    {
        mySwitchCannonTimer -= Time.deltaTime;
        if (mySwitchCannonTimer <= 0)
        {
            mySwitchCannonTimer = Random.Range(2.0f, 4.0f);

            int index = -1; //Random.Range(0, myCannons.Count);

            for (int i = 0; i < myCannons.Count; ++i)
            {
                if (myCannons[i].GetIsReloading() == false)
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                myCannons[index].Reload();
            }
        }
    }
}
