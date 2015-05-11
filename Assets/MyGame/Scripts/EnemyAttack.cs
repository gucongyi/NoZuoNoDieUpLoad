using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float attack=5f;
	public float attackTime=1f;
	private float timer;
	private EnemyHealth health;
	// Use this for initialization
	void Start () {
		timer=attackTime;
		health=GetComponent<EnemyHealth>();
	}
	
	void OnTriggerStay(Collider coll) {
		if(coll.tag==Tags.Player&&health.hp>0){
			timer+=Time.deltaTime;
			if(timer>=attackTime){
				timer-=attackTime;
				coll.GetComponent<PlayerHealth>().TakeDamage(attack);
			}
		}
	}
}
