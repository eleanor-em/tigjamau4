using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public Vector3 cameraOffset;

    private PlayerController controller;

    private void Start() {
        controller = GetComponent<PlayerController>();
    }

    private void LateUpdate() {
        float camYpos = Camera.main.transform.position.y - cameraOffset.y;
        float lerpAmount = 0.05f;
        if (controller.onGround) {
            camYpos = Mathf.Lerp(camYpos, transform.position.y, lerpAmount);
        }
        // Camera has to be back a bit on the z axis
        Camera.main.transform.position
            = new Vector3(transform.position.x, camYpos, -10)
            + cameraOffset;
        if (Camera.main.transform.position.x < 0) {
            Camera.main.transform.position -= Camera.main.transform.position.x * Vector3.right;
        }
    }
}
