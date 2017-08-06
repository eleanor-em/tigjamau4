using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light3StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I am lost",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "Fear is a map",
                fadeInDelay = 1,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "but I am not alone",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            },
            new TextInfo {
                text = "that when followed blindly",
                fadeInDelay = 3,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "and I am afraid",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            },
            new TextInfo {
                text = "will steal from you",
                fadeInDelay = 5,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = TextColors.MonsterCol
            }
        }));

        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "of what the future holds.",
                fadeInDelay = 6,
                fadeInTime = 1,
                lifetime = 1,
                fadeOutTime = 1,
                offset = 3,
                color = Color.white
            },
            new TextInfo {
                text = "your ability to see.",
                fadeInDelay = 7,
                fadeInTime = 1,
                lifetime = 1,
                fadeOutTime = 1,
                offset = 3,
                color = TextColors.MonsterCol
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
