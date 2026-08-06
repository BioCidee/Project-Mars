using UnityEngine;

public class S_Begining : BasicState
{
    public S_Begining(string _name, string _description, SM_Game _stateMachine) : base(_name, _description, _stateMachine)
    {
        mySM = _stateMachine;
    }

    private SM_Game mySM;

    [Header("---- Begenin Parameters ----s")]
    [SerializeField] private float noll;
    [SerializeField] private bool isStateEnd = false;
    [SerializeField] private float duration = 60;
    private float timer;

    public override void OnStart()
    {

    }

    public override void OnLogicUpdate()
    {
        BegeningDuration();
        IsStateComplete();
    }

    public override void OnExit()
    {

    }

    private void IsStateComplete()
    {
        if (isStateEnd)
        {
            mySM.ChangeState(mySM.S_EnnemyWave);
        }
    }

    private void BegeningDuration()
    {
        if (timer >= duration)
        {
            timer = 0;
            isStateEnd = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
