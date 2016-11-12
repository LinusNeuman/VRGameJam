using UnityEngine;
using System.Collections;

public class CannonCollider : MonoBehaviour
{
    [SerializeField]
    private CannonScript myCannonScript = null;

    public void OnTriggerEnter(Collider collision)
    {
        myCannonScript.Shot(collision);
    }
}
