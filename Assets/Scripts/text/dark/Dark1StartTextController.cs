using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark1StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Where am I?",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "It is a never changing",
                fadeInDelay = 1,
                fadeInTime = 1,
                lifetime = 11,
                fadeOutTime = 1,
                offset = 0,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I know this place so well",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "constant nothingness.",
                fadeInDelay = 3,
                fadeInTime = 1,
                lifetime = 9,
                fadeOutTime = 1,
                offset = 1,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "but I understand nothing of it.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "It was designed,",
                fadeInDelay = 5,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 2,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            // monster text
            new TextInfo {
                text = "by you,",
                fadeInDelay = 16,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 3,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            // monster text
            new TextInfo {
                text = "to be this way.",
                fadeInDelay = 18,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 4,
                color = TextColors.MonsterCol
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
