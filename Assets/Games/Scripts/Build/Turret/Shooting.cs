using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("System Parameters")]
    [SerializeField] private TargetingSystem _detectionSystem;

    [Header("Shoot Parameters")]
    [SerializeField] private float shootSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPosition;
    private float shootTimer;
    private bool isReadyToShoot = false;

    private void Update() {
        isReadyToShoot = _detectionSystem.ReturnIfTargetingReady();

        if (isReadyToShoot) {
            ShootSystem();
        } else {
            shootTimer = 0;
            return;
        }
    }

    private void Shoot() {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = shootPosition.transform.position;
        newBullet.transform.rotation = shootPosition.transform.rotation;
    }

    private void ShootSystem() {
        if(shootTimer >= shootSpeed) {
            shootTimer = 0;
            Shoot();
        } else {
            shootTimer += Time.deltaTime;
        }
    }
}
