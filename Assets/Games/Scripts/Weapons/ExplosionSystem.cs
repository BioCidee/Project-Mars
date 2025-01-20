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
        Debug.Log(hit.Length);

        foreach (RaycastHit hit2 in hit) {
            I_Damageable objectToDamage =  hit2.collider.gameObject.GetComponent<I_Damageable>();

            if (objectToDamage != null) {
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
