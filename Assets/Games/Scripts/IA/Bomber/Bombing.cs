using UnityEngine;
using UnityEngine.Events;

public class Bombing : MonoBehaviour
{
    // Parameters
    [Header("Bombing Parameters")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform dropPosition;
    [SerializeField] private float timeBetweenStrikes;
    [SerializeField] private bool readyToStrike = false;
    private float strikeTimer = 0;

    // Event
    [SerializeField] private UnityEvent OnShipIsReadyToFire;

    // IDEA FOR ADD
    // - Make number bomb drop on a variable

    private void Start() {
        if(OnShipIsReadyToFire == null)
            OnShipIsReadyToFire = new UnityEvent();

        OnShipIsReadyToFire.AddListener(SetReadyToFire);
    }

    private void Update() {
        if (readyToStrike) {
            TimerForStrike();
        } else {
            strikeTimer = 0;
        }
    }

    private void TimerForStrike() {
        if (strikeTimer <= 0) {
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

    private void SetReadyToFire() {
        readyToStrike = !readyToStrike;
    }
}
