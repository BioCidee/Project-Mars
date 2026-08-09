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

        hit = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.forward);

        foreach (RaycastHit hit2 in hit) {
            I_Damageable objectToDamage;

            if (hit2.collider.gameObject.TryGetComponent<I_Damageable>(out objectToDamage)) {
                objectToDamage.TakeDamage(explosionDamage);
                Debug.Log(objectToDamage);
            }
        }

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
