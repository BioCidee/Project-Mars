using UnityEngine;

public class IA_Life : MonoBehaviour, I_Damageable {

    [Header("Life Parameters")]
    [SerializeField] private int maxLife;
    private int minLife = 0;
    private int currentLife = 0;

    private enum nameOfEvent {
        OnPlayerDie,
    }

    // Colision System
    private Collider Collider;

    private void Start() {
        Initialize();
    }

    private void Initialize() {
        currentLife = maxLife;
    }

    private void CheckLife() {
        if (currentLife <= minLife) {

        }
    }

    private void Death() {
        EventManager.Instance.TriggerEvent(nameOfEvent.OnPlayerDie.ToString());
    }

    public void TakeDamage(int _damage) {
        currentLife -= _damage;
        CheckLife();
    }
}
