using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {
    public float lerpAmount = 0.05f;
    public GameObject target;

	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, lerpAmount);
        // camera is positioned back
        transform.position -= Vector3.forward * transform.position.z;
	}
}
