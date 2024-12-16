using System;
using UnityEngine;

public class ResourceManagement : MonoBehaviour
{
    [SerializeField] private int oilResource;
    private Action produceOil;
    private enum nameEvent {
        makeOil,
    }

    private void Start() {
        EventManager eV = EventManager.Instance;
        eV.CreateEvent(nameEvent.makeOil.ToString());
        eV.SubscribreToEvent(nameEvent.makeOil.ToString(), MakeOil);
    }

    public void MakeOil() {
        oilResource++;
    }
}
