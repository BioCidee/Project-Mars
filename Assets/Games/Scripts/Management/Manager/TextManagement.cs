using System.Collections;
using TMPro;
using UnityEngine;

public class TextManagement : MonoBehaviour
{
    [Header("Text Parameters")]
    [SerializeField] private Transform defaultTransform;
    [SerializeField] private GameObject textGO;
    [SerializeField] private TMP_Text paragraph;

    private bool isAnyTextDisplay;
    private int defaultSize = 70;

    private void Awake() {
        DeleteAndSetDefaultText();
    }

    public void DisplayText(string _text, int size, float delay) {
        paragraph.text = _text;
        paragraph.fontSize = size;
        StartCoroutine(TextDelay(delay));
    }

    public void DisplayText(string _text, int size, float delay, Vector2 textPosition) {
        paragraph.text = _text;
        paragraph.fontSize = size;
        paragraph.transform.position = textPosition;
        StartCoroutine(TextDelay(delay));
    }

    private void DeleteAndSetDefaultText() {
        textGO.transform.position = defaultTransform.position;
        paragraph.text = null;
        isAnyTextDisplay = false;
    }

    private IEnumerator TextDelay(float delay) {
        yield return new WaitForSeconds(delay);

        DeleteAndSetDefaultText();
    }
}
