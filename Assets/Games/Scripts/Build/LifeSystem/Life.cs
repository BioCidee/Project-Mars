using UnityEngine;

public class Life : MonoBehaviour, I_Damageable
{
    [Header("Life Parameters")]
    [SerializeField] private int maxLife;
    [SerializeField] private int currentLife;
    private int minLife = 0;

    private void Start() {
        currentLife = maxLife;
    }

    private void CheckLife() {
        if (currentLife <= minLife) {
            Death();
        }
    }

    public void TakeDamage(int _damage) {
        currentLife -= _damage;

        CheckLife();
        Debug.Log("Take Damage : " + this.gameObject.name);
    }

    private void Death() {
        Destroy(this.gameObject);
    }
}
