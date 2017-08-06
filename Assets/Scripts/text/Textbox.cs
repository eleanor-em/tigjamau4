using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TextColors {
    public static Color MonsterCol = new Color(119f / 255, 28f / 255, 28f / 255);
}

public struct TextInfo {
    public string text;
    public float fadeInDelay;
    public float fadeInTime;
    public float lifetime;
    public float fadeOutTime;
    public int offset;
    public Color color;
}

public class Textbox : MonoBehaviour {
    public float initialY;
    public float offsetAmt = 56f;

    public GameObject textPrefab;
    private GameObject textObject;
    private Text text;
    private float timeOnScreen = 0;
    private bool fadingOut = false;
    private bool delayed = false;

    private List<TextInfo> textsToShow;
    private TextInfo currentTextInfo;

    private Action<GameObject> callback = null;

	private void Setup() {
        textObject = Instantiate(textPrefab);
        // parent the text with the canvas
        textObject.transform.SetParent(transform.GetChild(0), false);
        // we need to adapt the transform to fit the textbox
        //var rect = textObject.GetComponent<RectTransform>();
        textObject.transform.localScale = Vector3.one;

        text = textObject.GetComponent<Text>();
        text.rectTransform.sizeDelta = new Vector2(540, 80);
        transform.SetParent(Camera.main.transform, false);
        textObject.transform.position = new Vector3(0, 3, 10) + Camera.main.transform.position;
    }

    private void Update() {
        timeOnScreen += Time.deltaTime;
        if (delayed == false && timeOnScreen >= currentTextInfo.fadeInDelay) {
            timeOnScreen -= currentTextInfo.fadeInDelay;
            delayed = true;
        }
        if (delayed) {
            if (text.color.a < 1 && !fadingOut) {
                currentTextInfo.color.a = Mathf.Min(timeOnScreen / currentTextInfo.fadeInTime, 1.0f);
                text.color = currentTextInfo.color;
            } else if (timeOnScreen - currentTextInfo.fadeInTime > currentTextInfo.lifetime) {
                fadingOut = true;
            }

            if (fadingOut) {
                // find out how long we've been fading for
                float fadeTime = timeOnScreen - currentTextInfo.fadeInTime - currentTextInfo.lifetime;
                currentTextInfo.color.a = Mathf.Max(1 - fadeTime / currentTextInfo.fadeOutTime, 0.0f);
                text.color = currentTextInfo.color;
                if (text.color.a == 0) {
                    OnClose();
                }
            }
        }
    }

    public void SetText(List<TextInfo> textList) {
        Setup();

        textsToShow = textList;
        // we're about to show the first element
        currentTextInfo = textsToShow[0];
        currentTextInfo.color.a = 0;
        text.text = currentTextInfo.text;
        text.color = currentTextInfo.color;
        textObject.GetComponent<RectTransform>().localPosition -= currentTextInfo.offset * offsetAmt * Vector3.up;
        textsToShow.RemoveAt(0);
    }

    public void SetText(List<TextInfo> textList, Action<GameObject> callback) {
        this.callback = callback;
        SetText(textList);
    }

    private void OnClose() {
        if (callback != null) {
            callback(GameObject.Find("[Prefab]Player"));
        }

        Destroy(textObject);

        if (textsToShow.Count > 0) {
            GameObject newTextbox = Instantiate(transform.gameObject);
            newTextbox.GetComponent<Textbox>().SetText(textsToShow);
            newTextbox.transform.localPosition = transform.localPosition;
        }
        transform.gameObject.SetActive(false);
    }
}
