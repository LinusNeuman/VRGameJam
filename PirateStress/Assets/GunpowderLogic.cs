using UnityEngine;
using System.Collections;

public class GunpowderLogic : MonoBehaviour {
    public enum ePowderType
    {
        Normal,
        HighExplosive
    }

    [SerializeField]
    private ePowderType myPowderType = ePowderType.Normal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public ePowderType GetPowderType()
    {
        return myPowderType;
    }
}
