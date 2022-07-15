using Bolt;
using UnityEngine;
using Timer = FSM.Timer;

public class Rest : StateBase
{
    private Animator animator;
    private float restTime;
    private Timer timer;
    
    public Rest(Animator animator,float restTime,GameObject self): base(self)
    {
        this.animator = animator;
        this.restTime = restTime; 
        timer = new Timer();
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Rest");
        timer.Reset();
    }

    public override void OnLogic()
    {
        if (timer.Elapsed > restTime)
        {
            CustomEvent.Trigger(self,NPCStateMachineVars.TriggerWalk);
        }
    }

    public override void OnExit()
    {
        animator.ResetTrigger("Rest");
    }
}