using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public float startupDelay = 5;

    new private SpriteRenderer renderer;
    private PlayerController controller;
    
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
	}
	
	void Update () {
        if (Time.time < startupDelay) {
            return;
        }

        // Handle general movement
        if (Input.GetKey(KeyCode.RightArrow)) {
            controller.dir = Vector3.right;
            renderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            controller.dir = Vector3.left;
            renderer.flipX = true;
        } else {
            controller.dir = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Z) && controller.onGround) {
            controller.jumped = true;
        }
        if (Input.GetKey(KeyCode.Z) && !controller.onGround) {
            controller.holdJump = true;
        } else {
            controller.holdJump = false;
        }
    }
}
