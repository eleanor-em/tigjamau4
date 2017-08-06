using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNextSceneTrigger : MonoBehaviour {
    public bool canExit;
    public Vector2 minExit;
    public Vector2 maxExit;
    public string nextScene;

    void Update() {
        if (canExit && transform.position.x > minExit.x && transform.position.x < maxExit.x
            && transform.position.y > minExit.y && transform.position.y < maxExit.y) {
            var fade = FindObjectOfType<FadeInController>();
            fade.scene = nextScene;
            fade.dir = 1;
        }
    }
}
