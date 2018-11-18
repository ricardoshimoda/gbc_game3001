using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WanderState : IState
{
    GameObject[] wpArray;
    int currWP = 0;

    public WanderState(StateMachine m, List<IState> l, AgentScript a)
    {
        sm = m;
        states = l;
        actor = a;
        wpArray = GameObject.FindGameObjectsWithTag("SpawnPoint").OrderBy(go => go.name).ToArray();
    }

	public override void Enter () {
        GetNextWP();
    }

    public override void Update () {
        if (!actor.agent.pathPending) // Check to see if agent stopped.
        {
            if (actor.agent.remainingDistance <= actor.agent.stoppingDistance)
            {
                if (!actor.agent.hasPath || actor.agent.velocity.sqrMagnitude == 0f)
                {
                    // Do stuff.
                    currWP++;
                    if(currWP == wpArray.Length){
                        currWP=0;
                    }
                    GetNextWP();
                }
            }
        }
		var distTo = Vector3.Distance(actor.selfTransform.position, actor.heroTransform.position);
		if(distTo < actor.seekDistance){
            sm.ChangeState(states[1]);
		}
    }

    public override void Exit()
    {

    }

    private void GetNextWP()
    {
        actor.agent.destination = wpArray[currWP].transform.position;
        actor.agent.isStopped = false;
    }    
}

public class HungerState : IState
{
    //ClickScript cs;

    public HungerState(StateMachine m, List<IState> l, AgentScript a)
    {
        sm = m;
        states = l;
        actor = a;
        //cs = GameObject.FindGameObjectWithTag("ClickController").GetComponent<ClickScript>();
    }

    public override void Enter()
    {
        GetPlayerPosition();
    }

    public override void Update()
    {
        if (!actor.agent.pathPending) // Check to see if agent stopped.
        {
            if (actor.agent.remainingDistance <= actor.agent.stoppingDistance)
            {
                if (!actor.agent.hasPath || actor.agent.velocity.sqrMagnitude == 0f)
                {
                    // Got to the target.
                }
            }
        }
    }

    public override void Exit()
    {

    }

    private void GetPlayerPosition()
    {
        actor.agent.destination = actor.heroTransform.position;
        actor.agent.isStopped = false;
    }
}
