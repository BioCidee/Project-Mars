using UnityEngine;

public class Bombing : MonoBehaviour
{
    [Header("Bombing Parameters")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform dropPosition;
    [SerializeField] private float timeBetweenStrikes;
    [SerializeField] private bool readyToStrike = false;
    private float strikeTimer;

    // IDEA FOR ADD
    // - Make number bomb drop on a variable

    private void Update() {
        if (readyToStrike) {
            TimerForStrike();
        } else {
            strikeTimer = 0;
        }
    }

    private void TimerForStrike() {
        if (strikeTimer <= timeBetweenStrikes) {
            strikeTimer += Time.deltaTime;
        } else {
            strikeTimer = 0;
            DropBomb();
        }
    }

    private void DropBomb() {
        GameObject newBomb = Instantiate(bomb);
        bomb.transform.position = dropPosition.position;
    }
}
