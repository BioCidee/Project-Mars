using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private int moveSpeed;
    private Transform dir;
    private Rigidbody rb;

    public BulletLogic(Transform _dir) {
        dir = _dir;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();

        transform.rotation = dir.rotation;
    }

    private void Update() {
        Movement();
    }

    private void SetDirection() {
        if (dir != null) {

        } else {
            Debug.LogWarning("There is no direction for this bullet");
        }
    }

    private void Movement() {
    }
}
