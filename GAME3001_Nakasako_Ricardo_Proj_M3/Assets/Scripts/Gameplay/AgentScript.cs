using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class AgentScript : MonoBehaviour {
    public NavMeshAgent agent;
    List<IState> stateList;
    StateMachine sm;
    public Transform heroTransform;
    public Transform selfTransform;
    public float seekDistance;
    public int minIntervalRocks;
    public int maxIntervalRocks;
	public GameObject rock; // Prefab to create the projectile
	public Transform rockSpawn; // Where the projectile is instantiated

	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        sm = new StateMachine();
        stateList = new List<IState>();
        stateList.Add(new WanderState(sm, stateList, this));
        stateList.Add(new HungerState(sm, stateList, this));
        sm.ChangeState(stateList[0]);
        heroTransform = GameObject.FindGameObjectWithTag("Hero").transform;
        selfTransform = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        sm.Update();
	}

    public void ShootRock(){
        // Align and shoot rocks until served properly
        gameObject.transform.rotation = heroTransform.rotation;
		GameObject.Instantiate (rock, rockSpawn.position, rockSpawn.rotation);
		Invoke ("ShootRock", Random.Range (minIntervalRocks, maxIntervalRocks));
	}


}
