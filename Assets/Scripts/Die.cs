using FSM;
using UnityEngine;

public class Die : StateBase
{
    private Animator animator;
    
    public Die(Animator animator,GameObject self): base(self)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Die");
    }

    public override void OnExit()
    {
        animator.ResetTrigger("Die");
    }
}