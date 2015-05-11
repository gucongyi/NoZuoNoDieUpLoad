using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(transform.position.y<1.2f){
			if(Input.GetAxis("Jump")!=0){
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up*3*5*10);
			}
		}

	}
}
