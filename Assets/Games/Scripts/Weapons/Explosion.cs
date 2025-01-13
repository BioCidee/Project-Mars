using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Explosion Parameters")]
    [SerializeField] private float explosionRadius;
    [SerializeField] private int explosionDamage;

    private void OnCollisionEnter(Collision collision) {
        
    }
}
