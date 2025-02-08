using UnityEngine;

public class S_ShipTransformChoice : BasicState
{
    public S_ShipTransformChoice(string _name, string _description, SM_Game _stateMachine) : base(_name, _description, _stateMachine) {
        myStateMachine = _stateMachine;
    }

    private SM_Game myCurrentSM;

    private GameManager GameManager;
    private bool isShipSet;
    private bool isStepComplete;

    // Text Display Parameters
    private string messageForSetMainShip = "Please ! Set your MainShip for launch the game !";
    private int textSize = 80;
    private float textDelay = 4;

    public override void OnStart() {
        myCurrentSM = (SM_Game)myStateMachine;  

        Debug.Log($"The state of {myName} as just started");
        GameManager = myCurrentSM.GetGameManager();

        DisplayTextSystem.instance.DisplayText(messageForSetMainShip, textSize, textDelay);
    }

    public override void OnLogicUpdate() {
        isShipSet = GameManager.ReturnMainShipStatue();

        IsStateComplete();
    }

    public override void OnPhysicsUpdate() {

    }

    public override void OnExit() {
        Debug.Log($"The state of {myName} as just ended");
    }

    private void IsStateComplete() {
        if (isShipSet) {
            isStepComplete = true;
        }

        if (isStepComplete) {
            myStateMachine.ChangeState(myCurrentSM.S_Begining);
        }
    }
}
