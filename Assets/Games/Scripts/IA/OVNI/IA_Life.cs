using UnityEngine;

public class IA_Life : MonoBehaviour, I_Damageable {

    [Header("Life Parameters")]
    [SerializeField] private int maxLife;
    private int minLife = 0;
    [SerializeField] private int currentLife = 0;

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
            Death();
        }
    }

    private void Death() {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int _damage) {
        currentLife -= _damage;
        CheckLife();
    }
}
