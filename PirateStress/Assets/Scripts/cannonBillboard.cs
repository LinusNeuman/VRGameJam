using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cannonBillboard : MonoBehaviour
{
    [SerializeField]
    private bool isWaiting;

    [SerializeField]
    private Image myImage;

    [SerializeField]
    private Sprite arrow;

    [SerializeField]
    private Sprite check;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isWaiting == true)
        {
            Color col;

            col.r = 255.0f;
            col.g = 0.0f;
            col.b = 0.0f;
            col.a = 255.0f;

            myImage.color = col;
            myImage.sprite = arrow;
        }
        else if(isWaiting == false)
        {
            Color col;

            col.r = 0.0f;
            col.g = 255.0f;
            col.b = 0.0f;
            col.a = 255.0f;

            myImage.color = col;
            myImage.sprite = check;
        }
	}
}
