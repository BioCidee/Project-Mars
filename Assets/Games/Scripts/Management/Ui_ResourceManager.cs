using TMPro;
using UnityEngine;

public class Ui_ResourceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentFuel;
    private string zero = "0";

    private void Start() {
        InitializeResource();
    }

    private void InitializeResource() {
        currentFuel.text = zero;
    }

    public void UpdateCurrentFuel(int _currentFuel) {
        currentFuel.text = _currentFuel.ToString();
    }
}
