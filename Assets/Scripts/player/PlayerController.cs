using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject scrollPrefab;

    // Constants
    public float speed = 4f;
    public float jumpSpeed = 9f;
    public float holdJumpAmount = 0.5f;
    public float gravity = -20f;
    public float groundStep = 0.03f;
    public float skinStep = 0.005f;
    public float slopeStep = 0.3f;
    public float grabStep = 0.3f;

    // Publicly accessible controls
    public Vector3 dir { get; set; }
    public bool jumped { get; set; }
    public bool holdJump { get; set; }

    // Internally controlled status variables
    public bool onGround { get; private set; }
    public bool grabbing { get; private set; }
    private float yspeed = 0;
    private Vector3 prevPos;

    public Bounds bounds { get; private set; }
    public Vector3 extents { get; private set; }

    private void Awake() {
        var collider = GetComponent<BoxCollider2D>();
        var offset = collider.offset;
        bounds = collider.bounds;
        extents = bounds.extents - new Vector3(offset.x, offset.y, 0);

        dir = Vector3.zero;
        jumped = false;
        onGround = false;
        grabbing = false;

        GameObject scroll = Instantiate(scrollPrefab);
        scroll.GetComponent<Textbox>().SetText(new List<string>(new string [] {
            "It was raining,\nand I was alone.",
            "I decided to get up."
        }));
    }

    void FixedUpdate() {
        float dt = Time.fixedDeltaTime;

        if (jumped) {
            if (grabbing) {
                transform.position = prevPos;
            }
            grabbing = false;
            yspeed = jumpSpeed;
            onGround = false;
        }

        if (!onGround && !grabbing) {
            if (holdJump) {
                yspeed += holdJumpAmount;
            }
            yspeed += gravity * dt;
        }

        Vector3 xDelta = dir * dt * speed;
        Vector3 yDelta = Vector3.up * yspeed * dt;

        var distance = yDelta.magnitude + (yspeed > 0 ? bounds.size.y - extents.y : extents.y);
        if (yspeed != 0 && !RaycastVertRange(yDelta, distance, MoveToContactY)) {
            transform.position += yDelta;
        }

        distance = xDelta.magnitude + extents.x;
        if (!grabbing && dir != Vector3.zero && !RaycastHorizRange(xDelta, distance, hit => {
            // If we wouldn't have hit from slightly up, then we might have stepped up a slope
            if (!RaycastHorizRange(Vector3.up * slopeStep, xDelta, distance)) {
                // To handle this, we move across, then resolve a vertical collision. Yay!
                transform.position += xDelta;
                CheckOnGround(MoveToContactY);
            } else if (!RaycastHorizRange(Vector3.up * (bounds.size.y - extents.y + grabStep), xDelta, distance)) {
                // TODO: Find a better way to classify what constitutes an "edge".
                prevPos = transform.position;
                transform.position = hit.point;
                grabbing = true;
                yspeed = 0;
            } else {
                MoveToContactX(hit);
            }
        })) {
            transform.position += xDelta;
            // If we were on ground but are no longer and we didn't jump, we might have stepped down a slope
            if (onGround && !CheckOnGround() && !jumped) {
                CheckOnGround(Vector3.down * slopeStep, hit => {
                    MoveToContactY(hit);
                });
            }
        }

        if (!grabbing) {
            if (!CheckOnGround()) {
                onGround = false;
            } else if (yspeed <= 0) {
                yspeed = 0;
                onGround = true;
            }
        }

        jumped = false;
    }

    private void MoveToContactX(RaycastHit2D hit) {
        transform.position = new Vector3(hit.point.x + (extents.x + skinStep) * hit.normal.x, transform.position.y);
    }
    private void MoveToContactY(RaycastHit2D hit) {
        yspeed = 0;
        float newY = transform.position.y;
        // Hit from above
        if (hit.normal.y < 0) {
            newY = hit.point.y - (bounds.size.y - extents.y) - skinStep;
        } else {
            // Hit from below
            newY = hit.point.y + extents.y + skinStep;
        }
        transform.position = new Vector3(transform.position.x, newY);
    }

    private bool CheckOnGround() { return CheckOnGround(Vector3.zero, hit => { }); }
    private bool CheckOnGround(Action<RaycastHit2D> callback) {
        return RaycastVertRange(Vector3.zero, Vector2.down, extents.y + groundStep, callback);
    }
    private bool CheckOnGround(Vector3 offset, Action<RaycastHit2D> callback) {
        return RaycastVertRange(offset, Vector2.down, extents.y + groundStep, callback);
    }

    private bool RaycastVertRange(Vector2 direction, float distance, Action<RaycastHit2D> callback) {
        return RaycastVertRange(Vector3.zero, direction, distance, callback);
    }
    private bool RaycastVertRange(Vector3 offset, Vector2 direction, float distance, Action<RaycastHit2D> callback) {
        return RaycastRange(offset + Vector3.left * extents.x, offset + Vector3.right * extents.x, 5, direction, distance, callback);
    }

    private bool RaycastHorizRange(Vector2 direction, float distance, Action<RaycastHit2D> callback) {
        return RaycastHorizRange(Vector3.zero, direction, distance, callback);
    }
    private bool RaycastHorizRange(Vector3 offset, Vector2 direction, float distance) {
        return RaycastRange(offset + Vector3.up * (bounds.size.y - extents.y), offset + Vector3.down * extents.y, 10, direction, distance, hit => { });
    }
    private bool RaycastHorizRange(Vector3 offset, Vector2 direction, float distance, Action<RaycastHit2D> callback) {
        return RaycastRange(offset + Vector3.up * (bounds.size.y - extents.y), offset + Vector3.down * extents.y, 10, direction, distance, callback);
    }

    private bool RaycastRange(Vector3 startOffset, Vector3 endOffset, int count, Vector2 direction, float distance, Action<RaycastHit2D> callback) {
        float stepSize = 1f / count;
        for (int i = 0; i <= count; ++i) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.Lerp(startOffset, endOffset, stepSize * i), direction, distance);
            if (hit.collider != null) {
                callback(hit);
                return true;
            }
        }
        return false;
    }
    private bool RaycastRange(Vector3 startOffset, Vector3 endOffset, int count, Vector2 direction, float distance) {
        return RaycastRange(startOffset, endOffset, count, direction, distance, hit => { });
    }
}
