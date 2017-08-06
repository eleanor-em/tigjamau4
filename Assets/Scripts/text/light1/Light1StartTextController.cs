using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I am far from home",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "Home is ever changing",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 9,
                fadeOutTime = 1,
                offset = 0,
                color = Color.red
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "and unsure I know",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 1,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "and adapt you must",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 1,
                color = Color.red
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "where I belong.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            },
            // monster text
            new TextInfo {
                text = "for the tides of life",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 1,
                offset = 2,
                color = Color.red
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            // monster text
            new TextInfo {
                text = "stop for no one",
                fadeInDelay = 13,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 3,
                color = Color.red
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
