using UnityEngine;

public class SM_Game : StateMachine
{

    // State
    public S_ShipTransformChoice S_ShipTransformChoice;
    public S_Begining S_Begining;
    public S_EnnemyWave S_EnnemyWave;

    private void Awake() {
        S_ShipTransformChoice = new S_ShipTransformChoice("S_ShipTransformChoice", null, this);
        S_Begining = new S_Begining("Game Begening", null, this);
        S_EnnemyWave = new S_EnnemyWave("Ennemy Spawn", null, this);
    }

    protected override BasicState GetInitialState() {
        return S_ShipTransformChoice;
    }

    public GameManager GetGameManager() {
        return GameManager.Instance;
    }
}
