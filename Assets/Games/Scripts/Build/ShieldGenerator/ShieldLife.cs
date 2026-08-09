using UnityEngine;

public class ShieldLife : MonoBehaviour, I_Damageable
{
    [Header("---- Life Parameters ----")]
    [SerializeField] private bool isShieldActive;
    [SerializeField] private int currentLife;
    [SerializeField] private int maxLife;

    [Header("---- Shield Generator ----")]
    [SerializeField] ShieldGenerator shieldGenerator;

    public void GenerateShield() {
        currentLife = maxLife;
        isShieldActive = true;
    }

    public int ReturnLife() {
        return currentLife;
    }

    public bool IsShieldActive() {
        return isShieldActive;
    }

    public void SetShieldGenerator(ShieldGenerator _myShield) {
        shieldGenerator = _myShield;
    }

    public void TakeDamage(int _damage) {
        currentLife -= _damage;

        if (currentLife <= 0) {
            isShieldActive = false;
            currentLife = 0;
            shieldGenerator.OnShieldKilled();
        }
    }
}
