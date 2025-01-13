using UnityEngine;

public class ExplosionSystem : MonoBehaviour
{
    [Header("Explosion Parameters")]
    [SerializeField] private float explosionRadius;
    [SerializeField] private int explosionDamage;

    private void OnCollisionEnter(Collision collision) {
        Explosion();
    }

    private void Explosion() {
        RaycastHit[] hit;

        hit = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.zero);

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
