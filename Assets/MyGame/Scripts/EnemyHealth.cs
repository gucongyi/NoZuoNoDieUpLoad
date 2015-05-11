using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

	Animator anim;
	NavMeshAgent agent;
	EnemyMove move;
	EnemyAttack enemyAttack;
	CapsuleCollider capColl;
	public float hp = 100f;
	public AudioSource dealthAudio;
	public AudioSource hitedAudio;
	private ParticleSystem particleSystem;
	private GameObject EnemyPrefab;
	private GameObject HellephantPoint;
	private GameObject ZomBearPoint;
	private GameObject ZombunnyPoint;
	private GameObject Blood;

	void Awake ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		move = GetComponent<EnemyMove> ();
		capColl = GetComponent<CapsuleCollider> ();
		enemyAttack = GetComponent<EnemyAttack> ();
		particleSystem = GetComponentInChildren<ParticleSystem> ();
	}

	void Start ()
	{
		HellephantPoint = GameObject.Find ("HellephantSpawnPoint");
		ZomBearPoint = GameObject.Find ("ZomBearSpawnPoint");
		ZombunnyPoint = GameObject.Find ("ZomBunnySpawnPoint");
		Blood = Resources.Load ("Blood") as GameObject;
	}
	
	public void TakeDamage (float damage, Vector3 effectPoint)
	{
		particleSystem.transform.position = effectPoint;
		particleSystem.Play ();
		if (hp <= 0)
			return;
		hp -= damage;
		hitedAudio.Play ();
		if (hp <= 0) {
			Dead ();
		}
	}

	void Dead ()
	{
		dealthAudio.Play ();
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		capColl.enabled = false;
		move.enabled = false;
		enemyAttack.enabled = false;
	}

	void Update ()
	{
		if (hp <= 0) {
			transform.Translate (Vector3.down * Time.deltaTime * 1f);
			if (transform.position.y < -2) {
				Destroy (gameObject);
				Score.crashScore+=100;
				EnemyDeadCount.EnemyDeadthCount++;
//				Debug.Log(EnemyDeadCount.EnemyDeadthCount);
				if (EnemyDeadCount.EnemyDeadthCount % 5 == 0) {
					GameObject BloodInstant = GameObject.Instantiate (Blood, new Vector3 (transform.position.x, 0.5f, transform.position.z), transform.rotation)as GameObject;
//					BloodInstant.AddComponent<AddBlood> ();
				}
				float randomValue = Random.value;
				if (randomValue < 0.4f) {
					EnemyPrefab = Resources.Load ("Hellephant") as GameObject;
					GameObject.Instantiate (EnemyPrefab, HellephantPoint.transform.position, HellephantPoint.transform.rotation);
				} else if (randomValue >= 0.4f && randomValue < 0.7f) {
					EnemyPrefab = Resources.Load ("ZomBear") as GameObject;
					GameObject.Instantiate (EnemyPrefab, ZomBearPoint.transform.position, ZomBearPoint.transform.rotation);
				} else {
					EnemyPrefab = Resources.Load ("Zombunny") as GameObject;
					GameObject.Instantiate (EnemyPrefab, ZombunnyPoint.transform.position, ZombunnyPoint.transform.rotation);
				}
			}
		}
	}
}
