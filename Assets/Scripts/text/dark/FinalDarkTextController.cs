using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDarkTextController : MonoBehaviour {
    public GameObject textboxPrefab;

	void Start () {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I know nothing",
                fadeInDelay = 0,
                fadeInTime = 1,
                lifetime = 13,
                fadeOutTime = 2,
                offset = 0,
                color = Color.white
            },
            new TextInfo {
                text = "It doesn't have to be this way.\n\nCreated for TIGJAM Australia 4\nProgramming and level design by Eleanor McMurtry\nArt and writing by Rose Morgan",
                fadeInDelay = 5,
                fadeInTime = 1,
                lifetime = 15,
                fadeOutTime = 5,
                offset = 0,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "and I am nothing",
                fadeInDelay = 2,
                fadeInTime = 1,
                lifetime = 11,
                fadeOutTime = 2,
                offset = 1,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "but this darkness",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 9,
                fadeOutTime = 2,
                offset = 2,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "that I have always called",
                fadeInDelay = 6,
                fadeInTime = 1,
                lifetime = 7,
                fadeOutTime = 2,
                offset = 3,
                color = Color.white
            }
        }));
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "home.",
                fadeInDelay = 8,
                fadeInTime = 1,
                lifetime = 5,
                fadeOutTime = 7,
                offset = 4,
                color = Color.white
            }
        }));
    }
}
