using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour {
    private Vector3 startPos;
    private Vector3 prevPos;
    public Vector3 delta { get; private set; }

    public Vector3 direction = Vector3.right;
    public float amplitude = 1;
    public float period = 1;
    public float phase = 0;
    public float power = 0;
    public float offset = 0;

	void Start () {
        startPos = transform.position;
        transform.gameObject.tag = "Platform";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        prevPos = transform.position;
        transform.position = startPos + direction *
            (offset + amplitude * Mathf.Pow(Mathf.Sin((phase + Time.time) / period), 2 * power + 1));
        delta = transform.position - prevPos;
	}
}
