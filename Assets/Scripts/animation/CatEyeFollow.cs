using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEyeFollow : MonoBehaviour {
    public GameObject target;

	void FixedUpdate () {
        float x = transform.position.x - target.transform.position.x;
        float y = transform.position.y - target.transform.position.y;
        float theta = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        transform.rotation = Quaternion.Euler(0, 0, theta);
	}
}
