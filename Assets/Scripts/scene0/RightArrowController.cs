using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowController : MonoBehaviour {
    public GameObject triggerMonitor;
    public GameObject player;

    private void Start() {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    void Update () {
        var trigger = player.GetComponent<PlayerNextSceneTrigger>();
        if (triggerMonitor.gameObject.activeSelf == false && trigger.canExit) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            trigger.minExit = new Vector2(31, 2);
            trigger.maxExit = new Vector2(32, 10);
        }
	}
}
