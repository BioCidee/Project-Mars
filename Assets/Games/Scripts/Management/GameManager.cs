using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Ship
    private Transform shipTransform;
    private bool isShipSet = false;
    private int shipNumber = 0;

    // Map Parameters
    private int width;
    private int length;

    // Game Parameters
    private bool canEnnemySpawn = false;

    #region SINGLETON
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null)
                Debug.LogError("There is no GameManager in this Scene");

            return instance; 
        }
    }

    private void InitializeSingleton() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    #endregion 

    private void Awake() {
        InitializeSingleton();
    }

    private void Start() {
        if (shipTransform != null) {
            StartGame();
        }

        EventManager eM = EventManager.Instance;

        eM.CreateEvent("OnGameStart");
        eM.CreateEvent("OnGameEnd");
    }

    public void SetShipParameters(Transform _shipTransform) {
        if (shipNumber == 0 || isShipSet == false) {
            shipTransform = _shipTransform;
            isShipSet = true;
            Debug.Log("Ship parameters set");
        }
    }

    public void SetMapParameters(int _width, int _height) {
        width = _width; length = _height;
    }

    public void ReturnMapParameters(out int _width, out int _length) {
        _width = width;
        _length = length;
    }

    public void ReturnMapSize(out int _width, out int _length) {
        _width = width;
        _length = length;
    }

    public bool ReturnMainShipStatue() {
        return isShipSet;
    }

    public Transform ReturnMainShipTransform() {
        if (isShipSet) {
            return shipTransform;
        } else {
            Debug.Log("Something try to get Main Ship Transform before her spawn");
        }

        return null;
    }

    private void StartGame() {
        canEnnemySpawn = false;
    }

    private void RestartGame() {
        canEnnemySpawn = true;
        isShipSet = false;
    }
}
