using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayTextSystem : MonoBehaviour
{
    [Header("Text Parameters")]
    [SerializeField] private Transform defaultTransform;
    [SerializeField] private GameObject textGO;
    [SerializeField] private TMP_Text paragraph;

    private Color defaultColor;
    private bool isAnyTextDisplay;
    private int defaultSize = 70;

    #region SINGLETON

    private static DisplayTextSystem Instance;
    public static DisplayTextSystem instance {
        get {
            if (Instance == null)
                Debug.LogError("Try to get TextManagement instance but is do not exist");

            return Instance;
        }
    }

    private void InitializeSingleton() {
        if (Instance != null) {
            if (Instance != this) {
                Destroy(this.gameObject);
            }
        } else {
            Instance = this;
        }
    }

    #endregion

    private void Awake() {
        InitializeSingleton();

        defaultColor = paragraph.color;
        DeleteAndSetDefaultText();
    }

    public void DisplayText(string _text, float delay) {
        textGO.SetActive(true);
        paragraph.text = _text;
        paragraph.fontSize = defaultSize;
        StartCoroutine(TextDelay(delay));
    }

    public void DisplayText(string _text, int size, float delay) {
        textGO.SetActive(true);
        paragraph.text = _text;
        paragraph.fontSize = size;
        StartCoroutine(TextDelay(delay));
    }

    public void DisplayText(string _text, int size, float delay, Vector2 textPosition) {
        textGO.SetActive(true);
        paragraph.text = _text;
        paragraph.fontSize = size;
        paragraph.transform.position = textPosition;
        StartCoroutine(TextDelay(delay));
    }

    public void DisplayText(string _text, int size, float delay, Color _myColor) {
        textGO.SetActive(true);
        paragraph.text = _text;
        paragraph.fontSize = size;
        StartCoroutine(TextDelay(delay));
    }

    private void DeleteAndSetDefaultText() {
        textGO.transform.position = defaultTransform.position;
        paragraph.text = null;
        isAnyTextDisplay = false;
        paragraph.color = defaultColor;
        textGO.SetActive(false);
    }

    private IEnumerator TextDelay(float delay) {
        float elapsedTime = delay;
        Color color = paragraph.color;

        while (elapsedTime > 0) {
            yield return new WaitForSeconds(0.01f);
            elapsedTime -= 0.01f;

            color.a = Mathf.Lerp(0f, 1f, elapsedTime / delay);
            paragraph.color = color;
        }

        DeleteAndSetDefaultText();
    }
}