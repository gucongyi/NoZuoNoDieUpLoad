using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	private NavMeshAgent agent;
	private GameObject player;
	private Animator anim;
	void Awake() {
		agent=GetComponent<NavMeshAgent>();
		anim=GetComponent<Animator>();
	}
	void Start () {
		player=GameObject.FindWithTag(Tags.Player);
		Debug.Log (player);
	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			if(Vector3.Distance(transform.position,player.transform.position)<1.5f){
				anim.SetBool("Move",false);
			}else{
				agent.SetDestination(player.transform.position);
				anim.SetBool("Move",true);
			}
		}

	}
}
