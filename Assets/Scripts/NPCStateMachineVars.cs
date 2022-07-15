using System;
using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class NPCStateMachineVars : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float idleTime;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed;
    [SerializeField] private float restTime;
    [SerializeField] private SpriteRenderer restZone ;

    public static readonly string TriggerWalk = "Walk";
    public static readonly string TriggerIdle = "Idle";
    public static readonly string TriggerRest = "Rest";
    public static readonly string TriggerDay = "Day";
    public static readonly string TriggerNight = "Night";
    public static readonly string TriggerDie = "Die";
    
    private int currentIndex = 0;
    
    private Idle idleState;
    private Walk walkState;
    private Rest restState;
    private Die dieState;

    public Idle IdleState => idleState ??= new Idle(animator, idleTime, gameObject);
    public Walk WalkState => walkState ??= new Walk(animator, wayPoints, transform, newIndex => currentIndex = newIndex, speed, gameObject);
    public Rest RestState => restState ??= new Rest(animator, restTime, gameObject);
    public Die DieState => dieState ??= new Die(animator, gameObject);
    
    public bool ReachWaypoint()
    {
        return Vector2.Distance(wayPoints[currentIndex].position, transform.position) < 0.1f;
    }

    public bool InRestZone()
    {
        return restZone.bounds.Contains(transform.position);
    }

    public void ToggleNight(bool isNight)
    {
        CustomEvent.Trigger(gameObject, isNight ? TriggerNight : TriggerDay);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CustomEvent.Trigger(gameObject, TriggerDie);
    }
}
