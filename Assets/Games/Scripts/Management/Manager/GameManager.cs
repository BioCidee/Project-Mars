using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // System
    private EventManager EventManager;

    // Ship
    private Transform shipTransform;
    private bool isShipSet = false;
    private int shipNumber = 0;

    // Map Parameters
    private int width;
    private int length;

    // Game Parameters
    private bool canEnnemySpawn = false;

    // Name of Event
    private enum nameOfEvent {
        OnGameStart,
        OnGameEnd,
        OnPlayerDie,
    }

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

        EventManager = EventManager.Instance;
        EventManager.SubscribreToEvent(nameOfEvent.OnPlayerDie.ToString(), GameEnd);
    }

    #region ShipParameters
    public void SetShipParameters(Transform _shipTransform) {
        if (shipNumber == 0 || isShipSet == false) {
            shipTransform = _shipTransform;
            isShipSet = true;
            Debug.Log("Ship parameters set");
        }
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
    #endregion

    #region MapParameters
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
    #endregion

    public void StartEnnemySpawn() {
        EventManager.TriggerEvent("OnEnnemyCanSpawn");
        Debug.Log("TRIGGER EVENT ENNEMY SPAWN");
    }

    #region GameCommand
    private void StartGame() {
        if (isShipSet) {
            canEnnemySpawn = false;
        }
    }

    private void RestartGame() {
        canEnnemySpawn = true;
        isShipSet = false;
    }

    private void OnMainShipDie() {
        SceneManager.LoadScene("GameOverScene");
    }

    private void GameEnd() {
        // TODO : Step Before game end
        OnMainShipDie();
    }
    #endregion
}
