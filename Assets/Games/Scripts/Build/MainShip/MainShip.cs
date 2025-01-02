using UnityEngine;

public class MainShip : MonoBehaviour
{
    // Life parameters
    private int maxLife = 100;
    private int minLife = 0;
    private int currentLife;

    private void Start() {
        OnShipIsCreate();
        SetParameters();
    }

    private void SetParameters() {
        currentLife = maxLife;
    }

    private void OnShipIsCreate() {
        GameManager.Instance.SetShipParameters(this.transform);
    }
}
