using UnityEngine;
using UnityEngine.Events;

public class Bombing : MonoBehaviour
{
    // Parameters
    [SerializeField] private IA_Movement movement;

    [Header("Bombing Parameters")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform dropPosition;
    [SerializeField] private float timeBetweenStrikes;
    [SerializeField] private bool readyToStrike = false;
    private float strikeTimer = 0;

    // IDEA FOR ADD
    // - Make number bomb drop on a variable

    private void Start() {
       
    }

    private void Update() {
        if (readyToStrike) {
            TimerForStrike();
        } else {
            strikeTimer = 0;
        }

        readyToStrike = movement.ReturnIfIsReadyToFire();
    }

    private void TimerForStrike() {
        if (strikeTimer > 0) {
            strikeTimer -= Time.deltaTime;
        } else {
            strikeTimer = timeBetweenStrikes;
            DropBomb();
        }
    }

    private void DropBomb() {
        GameObject newBomb = Instantiate(bomb);
        bomb.transform.position = dropPosition.position;
    }

    public void SetReadyToFire(bool _newStat) {
        readyToStrike = _newStat;
    }
}
