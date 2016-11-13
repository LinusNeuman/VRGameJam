using UnityEngine;
using System.Collections;

public class CannonCollider : MonoBehaviour
{
    [SerializeField]
    private CannonScript myCannonScript = null;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Cannonball")
        {
            myCannonScript.Shot(collision);
        }
        if(collision.tag == "Gunpowder")
        {
            myCannonScript.FillPowder(collision);
        }
    }
}
