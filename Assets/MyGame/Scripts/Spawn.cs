using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public float SpawnTime=3f;
	private float timer=0f;
	public GameObject EnemyPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer+=Time.deltaTime;
		if(timer>=SpawnTime){
			timer-=SpawnTime;
			EnemyTotal.Count++;
			if(EnemyTotal.Count<EnemyTotal.EnemyTotalAll){
				SpawnEnemy();
			}

		}
	}

	void SpawnEnemy(){
		GameObject.Instantiate(EnemyPrefab,transform.position,transform.rotation);
	}

}
