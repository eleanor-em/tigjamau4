using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSwing : MonoBehaviour {
    public float amplitude;

    private float Swing(float x) {
        return Mathf.Cos(x) + Mathf.Sin(3 * x + Mathf.PI / 5) * Mathf.Cos(x / 4)
               + Mathf.Pow(Mathf.Cos(1.5f * x + Mathf.PI / 4), 3) + Mathf.Sin(0.1f * x)
               / Mathf.PI;
    }

	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, amplitude * Swing(1.2f * Time.time));
	}
}
