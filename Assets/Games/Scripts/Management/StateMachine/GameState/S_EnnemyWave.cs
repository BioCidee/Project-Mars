using System.Collections;
using UnityEngine;

public class S_EnnemyWave : BasicState
{
    public S_EnnemyWave(string _name, string _description, StateMachine _stateMachine) : base(_name, _description, _stateMachine)
    {
        eventManager = EventManager.Instance;
    }

    private EventManager eventManager;

    [Header("---- Wave Parameters ----")]
    [SerializeField] private float waveDuration = 10;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private int lastWave = 0;
    [SerializeField] private bool isAWaveInDuration = false;

    public override void OnStart()
    {
        eventManager.TriggerEvent(EventNameEnum.eventName.OnEnnemyCanSpawn.ToString());
    }

    public override void OnLogicUpdate()
    {

    }

    public override void OnPhysicsUpdate()
    {

    }

    public override void OnExit()
    {

    }

    private IEnumerator CurrentWaveLife()
    {
        yield return new WaitForSeconds(waveDuration);
    }
    
}
