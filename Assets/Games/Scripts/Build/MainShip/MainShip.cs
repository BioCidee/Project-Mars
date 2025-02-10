using UnityEngine;

public class MainShip : MonoBehaviour
{
    private enum nameOfEvent {
        OnGameStart,
    }

    private void Start() {
        OnShipIsCreate();
        OnGameStart();
    }

    private void OnShipIsCreate() {
        GameManager.Instance.SetShipParameters(this.transform);
        Debug.Log("Main Ship Create");
    }

    private void OnGameStart() {
        EventManager.Instance.TriggerEvent(nameOfEvent.OnGameStart.ToString());
        Debug.Log("Main Ship Activate");
    }
}
