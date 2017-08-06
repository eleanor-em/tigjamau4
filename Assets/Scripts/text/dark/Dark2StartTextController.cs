using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark2StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Why am I here?",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "It is a two-sided mirror",
                fadeInDelay = 1,
                fadeInTime = 1,
                lifetime = 6,
                fadeOutTime = 1,
                offset = 0,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Why am I always here?",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            },
            new TextInfo {
                text = "that you use as a shield",
                fadeInDelay = 3,
                fadeInTime = 1,
                lifetime = 4,
                fadeOutTime = 1,
                offset = 1,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Why do I feel so alone",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            },
            new TextInfo {
                text = "and the light, it burns you.",
                fadeInDelay = 5,
                fadeInTime = 1,
                lifetime = 2,
                fadeOutTime = 1,
                offset = 2,
                color = TextColors.MonsterCol
            }
        }));

        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "in someplace so familiar?",
                fadeInDelay = 6,
                fadeInTime = 1,
                lifetime = 1,
                fadeOutTime = 1,
                offset = 3,
                color = Color.white
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
