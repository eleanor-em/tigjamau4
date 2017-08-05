using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public float startupDelay = 5;
    public GameObject particlePrefab;
    private bool awake = false;

    new private SpriteRenderer renderer;
    private PlayerController controller;
    private Animator animator;
    
	void Start () {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
	}

    private bool JumpKeyDown() {
        return Input.GetKeyDown(KeyCode.Z)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.UpArrow);
    }

    private bool JumpKey() {
        return Input.GetKey(KeyCode.Z)
            || Input.GetKey(KeyCode.Space)
            || Input.GetKey(KeyCode.UpArrow);
    }

    void Update () {
        if (Time.time < startupDelay) {
            return;
        }
        if (!awake) {
            awake = true;
            Instantiate(particlePrefab).transform.SetParent(transform);
        }

        bool wasMoving = controller.dir != Vector3.zero;
        // Handle general movement
        if (Input.GetKey(KeyCode.RightArrow)) {
            controller.dir = Vector3.right;
            renderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            controller.dir = Vector3.left;
            renderer.flipX = true;
        } else {
            controller.dir = Vector3.zero;
            if (wasMoving) {
                animator.ResetTrigger("OnRun");
                animator.SetTrigger("StopRun");
            }
        }
        if (!wasMoving && controller.dir != Vector3.zero) {
            animator.ResetTrigger("StopRun");
            animator.SetTrigger("OnRun");
        }

        if (JumpKeyDown() && controller.onGround) {
            animator.ResetTrigger("StopJump");
            animator.SetTrigger("OnJump");
            controller.jumped = true;
        }
        if (JumpKey() && !controller.onGround) {
            controller.holdJump = true;
        } else {
            controller.holdJump = false;
        }
    }
}
