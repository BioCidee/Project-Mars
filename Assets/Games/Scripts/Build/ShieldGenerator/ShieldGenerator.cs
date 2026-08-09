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
        if (!isShieldGenerated) {
            if(isShieldCanBeGenerated) {
                yield return new WaitForSeconds(timeToGenerate);
                GameObject NewShield = Instantiate(shield, shieldTransform);
                isShieldGenerated = true;
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
