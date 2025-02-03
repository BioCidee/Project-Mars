using UnityEngine;

public class SM_Game : StateMachine
{
    private S_ShipTransformChoice S_ShipTransformChoice;
    private S_Begining S_Begining;
    private S_EnnemyWave S_EnnemyWave;

    private void Awake() {
        S_ShipTransformChoice = new S_ShipTransformChoice("S_ShipTransformChoice", null, this);
        S_Begining = new S_Begining("Game Begeining", null, this);
        S_EnnemyWave = new S_EnnemyWave("Ennemy Spawn", null, this);
    }

    protected override BasicState GetInitialState() {
        return S_ShipTransformChoice;
    }
}
