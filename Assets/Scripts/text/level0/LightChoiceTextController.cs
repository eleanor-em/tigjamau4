using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightChoiceTextController : MonoBehaviour {
    public GameObject textboxPrefab;
    public SceneAsset nextScene;
    public GameObject arrow;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Or, I could reach for the light.",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Its warmth is unfamiliar",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "And for that, I do not trust it.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            }
        }), obj => {
            var trigger = obj.GetComponent<PlayerNextSceneTrigger>();
            trigger.canExit = true;
            trigger.nextScene = nextScene.name;
        });

        // the player has made their choice!
        arrow.SetActive(false);
        GameObject.Find("[Prefab]Player").GetComponent<PlayerNextSceneTrigger>().canExit = false;
        transform.gameObject.SetActive(false);
    }
}
