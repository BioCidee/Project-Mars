using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BasicState currentState;

    private void Start() {
        currentState = GetInitialState();   

        if(currentState != null ) 
            currentState.OnStart();
    }

    private void Update() {
       if (currentState != null)
            currentState.OnLogicUpdate();
    }

    private void LateUpdate() {
        if(currentState != null)
            currentState.OnPhysicsUpdate();
    }

    protected virtual BasicState GetInitialState() {
        return null;
    }

    public void ChangeState(BasicState state) {
        if (currentState != state) {
            if (currentState != null) {
                currentState.OnExit();
            }

            currentState = state;
            currentState.OnStart();
        }
    }

    private void OnGUI() {
        string content = currentState != null ? currentState.ToString() : "(No current string";
        GUILayout.Label($"<color='black><size=40>{content}</size></color>");
    }
}
