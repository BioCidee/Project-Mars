using System.Collections;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{
    [Header("---- Shield ----")]
    [SerializeField] private GameObject shield;
    [SerializeField] private Transform shieldTransform;
    private ShieldLife myShieldScript;

    [Header("---- Shield Parameters ----")]
    [SerializeField] private bool isShieldGenerated = false;
    [SerializeField] private bool isShieldCanBeGenerated = true;
    [SerializeField] private int shielCurrentLife = 100;
    [SerializeField] private int shieldLifeMax = 100;

    [Header("---- ShieldGeneration ----")]
    [SerializeField] private float timeToGenerate = 2;

    private void Awake() {
        myShieldScript = shield.GetComponent<ShieldLife>(); 

        myShieldScript.SetShieldGenerator(this);
    }

    private void Start() {
        StartCoroutine(GenerateShield());
    }

    public void OnShieldKilled() {
        SetShieldInactive();
    }

    private void SetShieldInactive() {
        shield.SetActive(false);
    }

    private IEnumerator GenerateShield() {
        Debug.Log("Start Generate Shield");
        if (!isShieldGenerated) {
            if(isShieldCanBeGenerated) {
                Debug.Log("ShieldGenerator : Start Coroutine");
                yield return new WaitForSeconds(timeToGenerate);
                Debug.Log("ShieldGenerator : End Coroutine");

                if (shield == null) Debug.LogError("Shield Generator didnt have any shield to generate !");

                GameObject NewShield = Instantiate(shield, shieldTransform);
                isShieldGenerated = true;

                Debug.Log("Shield generate");
            }  
        }
    }

    private bool CheckShield() {
        if(shield == null) {
            return false;
        } else {
            return true;
        }
    }
}
