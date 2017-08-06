using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour {
    private const float amount = 0.01f;
    private Image image;
    public string scene;
    public int dir = -1;

	void Start () {
        image = GetComponent<Image>();

		if (!SceneManager.GetActiveScene().name.Contains("light")) {
            image.color = Color.black;
        }
	}
	
	void FixedUpdate () {
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + dir * amount);
        if (image.color.a < 0) {
            dir = 0;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
        if (image.color.a > 1) {
            SceneManager.LoadScene(scene);
        }
	}
}
