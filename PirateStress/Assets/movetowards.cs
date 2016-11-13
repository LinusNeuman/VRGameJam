using UnityEngine;
using System.Collections;

public class movetowards : MonoBehaviour {
    [SerializeField]
    private Transform target;
	
	void Update () {
        Vector3 doorPos = target.position;
        Vector3 handPos = transform.position;

        doorPos.y = 0;
        handPos.y = 0;

        Vector3 difference = handPos - doorPos;
        Vector3 unit = difference.normalized;
        float dot = Vector3.Dot(unit, Vector3.forward);

        float rotation = Mathf.Atan2(unit.x, unit.z);

        Debug.Log(unit);
        Debug.Log(rotation);
        target.localRotation = Quaternion.Euler(0, rotation * (180.0f / Mathf.PI), 0);
    }
}
