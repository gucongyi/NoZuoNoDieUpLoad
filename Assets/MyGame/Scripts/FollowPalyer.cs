using UnityEngine;
using System.Collections;

public class FollowPalyer : MonoBehaviour {
	GameObject Player;
	public float smoothing=2f;
	// Use this for initialization
	void Start () {
		Player=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if(Player){
		Vector3 targetPos=Player.transform.position+new Vector3(0,2,-4);
		transform.position=Vector3.Lerp(transform.position,targetPos,smoothing*Time.deltaTime);
		}
	}
}
