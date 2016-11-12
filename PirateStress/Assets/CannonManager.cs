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
            mySwitchCannonTimer = 0;

            int index = Random.Range(0, myCannons.Count);
            for (; index < myCannons.Count; ++index)
            {
                myCannons[index].Reload();
            }
        }
    }
}
