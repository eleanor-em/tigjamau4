using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour {
    private Vector3 startPos;
    private Vector3 prevPos;
    public Vector3 delta { get; private set; }
    public float amplitude = 1;
    public float period = 1;

	void Start () {
        startPos = transform.position;
        transform.gameObject.tag = "Platform";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        prevPos = transform.position;
        transform.position = startPos + Vector3.right * amplitude * Mathf.Sin(Time.time / period);
        delta = transform.position - prevPos;
	}
}
