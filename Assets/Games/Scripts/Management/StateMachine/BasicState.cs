using UnityEngine;

public class BasicState 
{
    //System
    protected StateMachine myStateMachine;

    // Parameters
    protected string myName;
    protected string myDescription;

    public BasicState(string _name, string _description, StateMachine _stateMachine) {
        myName = _name;
        myDescription = _description;
        myStateMachine =_stateMachine;
    }

    public virtual void OnStart() {
        Debug.Log($"The state of {myName} as just started");
    }

    public virtual void OnLogicUpdate() {
    }
    
    public virtual void OnPhysicsUpdate() {

    }

    public virtual void OnExit() {
        Debug.Log($"The state of {myName} as just ended");
    }
}
