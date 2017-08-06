using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark3StartTextController : MonoBehaviour {
    public GameObject textboxPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "Who am I?",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 1,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "Only you hold that answer",
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
                text = "and it is inside a cage",
                fadeInDelay = 12,
                fadeInTime = 1,
                lifetime = 4,
                fadeOutTime = 1,
                offset = 1,
                color = TextColors.MonsterCol
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "locked in a box.",
                fadeInDelay = 14,
                fadeInTime = 1,
                lifetime = 2,
                fadeOutTime = 1,
                offset = 2,
                color = TextColors.MonsterCol
            }
        }));
        transform.gameObject.SetActive(false);
    }
}
