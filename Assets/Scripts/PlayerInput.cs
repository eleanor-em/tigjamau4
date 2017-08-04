using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    new private SpriteRenderer renderer;
    private PlayerController controller;
    
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
	}
	
	void Update () {
        // Handle general movement
        if (!controller.grabbing) {
            if (Input.GetKey(KeyCode.RightArrow)) {
                controller.dir = Vector3.right;
                renderer.flipX = false;
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                controller.dir = Vector3.left;
                renderer.flipX = true;
            } else {
                controller.dir = Vector3.zero;
            }
        } else {
            controller.dir = (renderer.flipX == false ? Vector3.right : Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (controller.onGround || controller.grabbing) {
                controller.jumped = true;
            }
        }
    }
}
