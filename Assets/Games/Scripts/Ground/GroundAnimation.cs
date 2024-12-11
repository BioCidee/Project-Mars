using System.Collections;
using UnityEngine;

public class GroundAnimation : MonoBehaviour
{
    private float scaleTimer = 0;

    [SerializeField] private Transform objectOnTop;
    [SerializeField] private float growSpeed;

    private void Start() {
        transform.localScale = Vector3.zero;
        StartCoroutine(SpawnAnim());
    }

    private IEnumerator SpawnAnim() {
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.one;

        while (scaleTimer < 0.2f) {
            scaleTimer += Time.deltaTime * growSpeed;
            float progress = scaleTimer / 0.2f;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null; 
        }

        transform.localScale = Vector3.one;   
    }
}
