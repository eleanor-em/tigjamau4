using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
    public float scrollSpeed;
    private Vector3 startPos;

    private void Start() {
        startPos = transform.position - Vector3.right * 10;
    }
    
    void LateUpdate () {
        transform.localPosition = startPos + Vector3.right * (Camera.main.transform.position.x - 10) * scrollSpeed;
	}
}
