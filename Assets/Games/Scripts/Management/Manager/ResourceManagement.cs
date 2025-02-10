using System;
using UnityEngine;

public class ResourceManagement : MonoBehaviour
{
    [Header("Ressource Parameters")]
    [SerializeField] private int oil;
    [SerializeField] private int maxOil;
    private int minOil = 0;

    [Header("UI Parameters")]
    [SerializeField] private Ui_ResourceManager ui;

    private Action produceOil;
    private enum nameEvent {
        makeOil,
        OnGameStart,
    }

    private void Start() {
        EventManager eV = EventManager.Instance;

        eV.CreateEvent(nameEvent.makeOil.ToString());
        eV.SubscribreToEvent(nameEvent.makeOil.ToString(), MakeOil);
        eV.SubscribreToEvent(nameEvent.makeOil.ToString(), MakeOil);
        eV.SubscribreToEvent(nameEvent.OnGameStart.ToString(), InitializeGameBegening);
    }

    //Public Fonction

    public bool CanBuy(int price)
    {
        bool canbuild = price <= oil ? true : false;
        return canbuild;
    }

    public void OnObjectBuild(int _price) {
        oil -= _price;
        UpdateOilUi();
    }

    public void MakeOil() {
        oil++;
        CheckMaxOil();
        UpdateOilUi();
    }

    // Private Fonction

    // Oil
    private void UpdateOilUi() {
        ui.UpdateCurrentFuel(oil);
    }

    private void CheckMaxOil() {
        if (oil >= maxOil) {
            oil = maxOil;
        }
    }

    private void InitializeGameBegening() {
        oil = 10; 
        UpdateOilUi();
    }
}
