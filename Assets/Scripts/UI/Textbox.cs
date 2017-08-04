using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour {
    public GameObject textPrefab;
    private GameObject textObject;
    private Text text;

    private List<string> textsToShow;

	private void Setup() {
        textObject = Instantiate(textPrefab);
        // parent the text with the canvas
        textObject.transform.SetParent(transform.GetChild(0), true);
        // we need to adapt the transform to fit the textbox
        var rect = textObject.GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        rect.localPosition = Vector3.zero;
        rect.sizeDelta = new Vector2(540, 80);

        text = textObject.GetComponent<Text>();
        transform.SetParent(Camera.main.transform);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            OnClose();
        }
    }

    public void SetText(List<string> textList) {
        Setup();

        textsToShow = textList;
        // we're about to show the first element
        text.text = textsToShow[0];
        textsToShow.RemoveAt(0);
    }

    private void OnClose() {
        //textObject.transform.SetParent(null);
        Destroy(textObject);

        if (textsToShow.Count > 0) {
            GameObject newTextbox = Instantiate(transform.gameObject);
            newTextbox.GetComponent<Textbox>().SetText(textsToShow);
            newTextbox.transform.localPosition = transform.localPosition;
        }
        gameObject.SetActive(false);
    }
}
