using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounder : MonoBehaviour {
    public float XMax = 18.5f;
    public float YMax = -1;

    private void LateUpdate() {
        if (XMax > 0 && transform.position.x > XMax) {
            transform.position += Vector3.right * (XMax - transform.position.x);
        }
        if (YMax > 0 && transform.position.y > YMax) {
            transform.position += Vector3.up * (YMax - transform.position.y);
        }
    }
}
