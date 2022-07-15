using Bolt;
using UnityEngine;
using Timer = FSM.Timer;

public class Idle : StateBase
{
    private Animator animator;
    private float idleTime;
    private Timer timer;
    
    public Idle(Animator animator,float idleTime, GameObject self):base(self)
    {
        this.animator = animator;
        this.idleTime = idleTime; 
        timer = new Timer();
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Idle");
        timer.Reset();
    }

    public override void OnLogic()
    {
        if (timer.Elapsed > idleTime)
        {
            CustomEvent.Trigger(self, NPCStateMachineVars.TriggerWalk);
        }
    }

    public override void OnExit()
    {
        animator.ResetTrigger("Idle");
    }
}