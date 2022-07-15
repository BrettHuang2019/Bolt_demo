using UnityEngine;

public abstract class StateBase
{
    protected GameObject self;

    public StateBase(GameObject self)
    {
        this.self = self;
    }
    
    public virtual void OnEnter(){}
    public virtual void OnLogic(){}
    public virtual void OnExit(){}
    
}