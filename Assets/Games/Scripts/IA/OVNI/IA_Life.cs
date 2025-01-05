using UnityEngine;

public class IA_Life : MonoBehaviour, I_Damageable {

    [Header("Life Parameters")]
    [SerializeField] private int maxLife;
    private int minLife = 0;
    private int currentLife = 0;

    // Colision System
    private Collider Collider;

    private void Start() {
        
    }

    public void TakeDamage(int _damage) {
        throw new System.NotImplementedException();
    }
}
