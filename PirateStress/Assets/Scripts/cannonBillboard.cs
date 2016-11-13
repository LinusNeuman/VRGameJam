using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cannonBillboard : MonoBehaviour
{
    [SerializeField]
    private bool isWaiting;

    [SerializeField]
    private Image myCannonballImage;

    [SerializeField]
    private Image myGunpowderImage;

    [SerializeField]
    private Sprite cannonballSprite;

    [SerializeField]
    private Sprite grapeshotSprite;

    [SerializeField]
    private Sprite powderSprite;

    [SerializeField]
    private Sprite HESprite;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<CannonScript>().Get

        if(isWaiting == true)
        {
            Color col;

            col.r = 255.0f;
            col.g = 255.0f;
            col.b = 255.0f;
            col.a = 255.0f;

            myCannonballImage.color = col;

            switch(GetComponent<CannonScript>().GetWishedCannonball())
            {
                case CannonballLogic.eCannonballType.Cannonball:
                    myCannonballImage.sprite = cannonballSprite;
                    break;

                case CannonballLogic.eCannonballType.Grapeshot:
                    myCannonballImage.sprite = grapeshotSprite;
                    break;
            }

            switch(GetComponent<CannonScript>().GetWishedGunpowder())
            {
                case GunpowderLogic.ePowderType.Normal:
                    myGunpowderImage.sprite = powderSprite;
                    break;

                case GunpowderLogic.ePowderType.HighExplosive:
                    myGunpowderImage.sprite = HESprite;
                    break;
            }
        }
        else if(isWaiting == false)
        {
            Color col;

            col.r = 0.0f;
            col.g = 0.0f;
            col.b = 0.0f;
            col.a = 125.0f;

            myCannonballImage.color = col;
        }
	}
}
