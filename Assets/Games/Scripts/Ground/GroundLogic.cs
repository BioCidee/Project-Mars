using System.Collections;
using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    private float scale = 0;
    private float scaleTimer = 0;

    [SerializeField] private float growSpeed;

    private void Start() {
        transform.localScale = Vector3.zero;
        StartCoroutine(SpawnAnim());
    }

    private void Update() {
        
    }

    private void SpawnAnimation() {
        if (scaleTimer < scale) {
            scaleTimer += Time.deltaTime * growSpeed;
            Vector3 newScale = new Vector3(scaleTimer, scaleTimer, scaleTimer);
            transform.localScale = newScale;    
        } else {
            transform.localScale = new Vector3 (1, 1, 1);
        }
    }

    private IEnumerator SpawnAnim() {
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.one;

        while (scaleTimer < 0.2f) {
            scaleTimer += Time.deltaTime * growSpeed;
            float progress = scaleTimer / 0.2f; // Progrès de 0 à 1

            // Lerp pour interpoler entre les deux échelles
            transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);

            yield return null; // Attendre la prochaine frame
        }

        transform.localScale = Vector3.one;
            
    }
}
