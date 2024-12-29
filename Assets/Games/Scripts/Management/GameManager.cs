using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Transform
    private Transform shipTransform;
    private bool isShipSet = false;

    // Map Parameters
    private int width;
    private int length;

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

    public void SetShipTransform() {

    }

    public void SetMapParameters(int _width, int _height) {
        width = _width; length = _height;
    }

    public void ReturnMapParameters(out int _width, out int _length) {
        _width = width;
        _length = length;
    }
}
