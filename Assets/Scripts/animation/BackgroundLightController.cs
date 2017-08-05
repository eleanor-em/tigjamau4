using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLightController : MonoBehaviour {
    public GameObject player;
    public float fadeoutHeight = -5;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () {
		if (player.transform.position.y < 0) {
            spriteRenderer.color = new Color(1, 1, 1,
                Mathf.Max(1 - player.transform.position.y / fadeoutHeight, 0));
        }
	}
}
