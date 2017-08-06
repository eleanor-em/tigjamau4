using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBoundary : MonoBehaviour {
    public Vector2 minPos;
    public Vector2 maxPos;

	void Update () {
	    if (transform.position.x < minPos.x) {
            transform.position = new Vector3(minPos.x, transform.position.y);
        }
        if (transform.position.x > maxPos.x) {
            transform.position = new Vector3(maxPos.x, transform.position.y);
        }
        if (transform.position.y < minPos.y) {
            //transform.position = new Vector3(transform.position.x, minPos.y);
            // restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (transform.position.y > maxPos.y) {
            transform.position = new Vector3(transform.position.x, maxPos.y);
        }
    }
}
