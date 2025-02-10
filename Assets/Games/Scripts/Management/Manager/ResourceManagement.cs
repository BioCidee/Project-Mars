using System;
using UnityEngine;

public class ResourceManagement : MonoBehaviour
{
    [Header("Ressource Parameters")]
    [SerializeField] private int oilResource;

    [Header("UI Parameters")]
    [SerializeField] private Ui_ResourceManager ui;

    private Action produceOil;
    private enum nameEvent {
        makeOil,
    }

    private void Start() {
        EventManager eV = EventManager.Instance;

        eV.CreateEvent(nameEvent.makeOil.ToString());
        eV.SubscribreToEvent(nameEvent.makeOil.ToString(), MakeOil);

        InitializeGameBegening();
    }

    //Public Fonction

    public bool CanBuy(int price)
    {
        bool canbuild = price <= oilResource ? true : false;
        return canbuild;
    }

    public void OnObjectBuild(int _price) {
        oilResource -= _price;
        UpdateFuelUi();
    }

    public void MakeOil() {
        oilResource++;
        UpdateFuelUi();
    }

    // Private Fonction

    private void UpdateFuelUi() {
        ui.UpdateCurrentFuel(oilResource);
    }

    private void InitializeGameBegening() {
        oilResource += 10; 
        UpdateFuelUi();
    }
}
