using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cannonBillboard : MonoBehaviour
{
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
        if (GetComponent<CannonScript>().GetHasBall() == true)
        {
            Color col;

            col.r = 0.0f;
            col.g = 0.0f;
            col.b = 0.0f;
            col.a = 0.0f;

            myCannonballImage.color = col;
        }
        else
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
        }

        if (GetComponent<CannonScript>().GetHasPowder() == true)
        {
            Color col;

            col.r = 0.0f;
            col.g = 0.0f;
            col.b = 0.0f;
            col.a = 0.0f;

            myGunpowderImage.color = col;
        }
        else
        {
            Color col;

            col.r = 255.0f;
            col.g = 255.0f;
            col.b = 255.0f;
            col.a = 255.0f;

            myGunpowderImage.color = col;

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
	}
}
