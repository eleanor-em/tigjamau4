using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I am here to find respite",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 9,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "Ceasing to move",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 0,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "from the constant darkness",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            },
            new TextInfo {
                text = "when you must",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 1,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "of my weary soul.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            },
            new TextInfo {
                text = "will rob respite from you.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 1,
                fadeOutTime = 1,
                offset = 2,
                color = TextColors.MonsterCol
            }
        }));

        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "The thought of moving often",
                fadeInDelay = 6,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 3,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "exhausts me.",
                fadeInDelay = 8,
                fadeInTime = 1,
                lifetime = 1,
                fadeOutTime = 1,
                offset = 4,
                color = Color.white
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
