using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    private PlayerController controller;

    private void Start() {
        controller = GetComponent<PlayerController>();
    }

    private void LateUpdate() {
        if (!controller.grabbing) {
            // Camera has to be back a bit on the z axis
            Camera.main.transform.position = transform.position + Vector3.back * 10;
        }
    }
}
