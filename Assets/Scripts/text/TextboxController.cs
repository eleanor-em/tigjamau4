using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxController : MonoBehaviour {
    public GameObject textboxPrefab;
    
	void Start () {
        Instantiate(textboxPrefab).GetComponent<Textbox>().SetText(new List<TextInfo>(new TextInfo[] {
            new TextInfo {
                text = "I am alone",
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
                text = "and I am lost",
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
                text = "but I am not afraid.",
                fadeInDelay = 4,
                fadeInTime = 1,
                lifetime = 3,
                fadeOutTime = 1,
                offset = 2,
                color = Color.white
            }
        }));
    }
}
