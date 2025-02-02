using System;
using UnityEngine;

public class GameStepManager : MonoBehaviour
{
    private enum GameStep {
        MapChoice,
        Begining,
        EnnemiSpawn,
        PeaceMoment,
    }

    [Header("Step Parameters")]
    [SerializeField] private GameStep currentState;

    private void ChangeStep(string _newState) {
        if (Enum.TryParse<GameStep>(_newState, out GameStep parsedGameState)) { 
            currentState = parsedGameState;
        } else {
            Debug.LogWarning($"GameStepManager: The GameStep you try to initiate {_newState} in fonction 'ChangeStep', is not valide.");
        }
    }

    private void Update() {
        
    }

    private void UpdateStep() {
        switch (currentState) {
            case GameStep.Begining:

                break;
            case GameStep.EnnemiSpawn:

                break;
            case GameStep.PeaceMoment:

                break;
            case GameStep.MapChoice:

                break;
        }
    }
}
