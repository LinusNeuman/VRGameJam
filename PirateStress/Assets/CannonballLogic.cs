using UnityEngine;
using System.Collections;

public class CannonballLogic : MonoBehaviour {

    public enum eCannonballType
    {
        Cannonball,
        Grapeshot
    }

    [SerializeField]
    private eCannonballType myCannonBallType = eCannonballType.Cannonball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public eCannonballType GetCannonballType()
    {
        return myCannonBallType;
    }
}
