using UnityEngine;

public class MainShipLife : MonoBehaviour, I_Damageable {

    [Header("Main Ship Life Parameters")]
    [SerializeField] private int maxLife;
    [SerializeField] private int currentLife;
    private int minLife = 0;

    private enum nameOfEvent {
        OnPlayerDie,
    }

    private void Start() {
        currentLife = maxLife;
    }

    private void CheckLife() {
        if (currentLife <= minLife) {
            PlayerDie();
        }
    }

    private void PlayerDie() {
        EventManager.Instance.TriggerEvent(nameOfEvent.OnPlayerDie.ToString());
    }

    public void TakeDamage(int _damage) {
        currentLife -= _damage;
        CheckLife();
    }
}
