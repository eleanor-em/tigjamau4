using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLightTextController : MonoBehaviour {
    public GameObject textboxPrefab;

	void Start () {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "There is so much to learn",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 15,
                fadeOutTime = 2,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "Breathe.",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 3,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "Created for TIGJAM Australia 4\nProgramming and level design by Eleanor McMurtry\nArt and writing by Rose Morgan",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 15,
                fadeOutTime = 5,
                offset = 0,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "there is still room to grow",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 13,
                fadeOutTime = 2,
                offset = 1,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "and my embroidered sky",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 11,
                fadeOutTime = 2,
                offset = 2,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "will guide me home",
                fadeInDelay = 6,
                fadeInTime = 1,
                lifetime = 9,
                fadeOutTime = 2,
                offset = 3,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "for as long as I am",
                fadeInDelay = 8,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 2,
                offset = 4,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "breathing.",
                fadeInDelay = 10,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 2,
                offset = 5,
                color = Color.white
            }
        }));
    }
}
