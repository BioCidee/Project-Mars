using System.Collections;
using UnityEngine;

public class MiningResource : MonoBehaviour
{
    [SerializeField] private float timerToProduce;
    private EventManager eV;
    private bool isMining;

    private void Start() {
        eV = EventManager.Instance;
        StartCoroutine(Mining());
    }

    private IEnumerator Mining() {
        while(isMining == true) {
            yield return new WaitForSeconds(timerToProduce);
            ProduceResource();
        }
    }

    private void ProduceResource() {
        eV.TriggerEvent("makeOil");
    }
}
