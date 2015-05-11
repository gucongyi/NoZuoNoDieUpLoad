using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public float ShootRate=2f;
	private float timer=0f;
	public bool isHeld;
	Light light;
	LineRenderer lineRenderer;
	private ParticleSystem particleSystem;
	public float attackValue=30f;
	AudioSource audioShoot;
	// Use this for initialization
	void Start () {
		isHeld =true;
		light=GetComponent<Light>();
		lineRenderer=GetComponent<LineRenderer>();
		audioShoot=GetComponent<AudioSource>();
		particleSystem=GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isHeld){
			timer+=Time.deltaTime;
			if(timer>=1/ShootRate){
				timer-=1/ShootRate;
				Shoot();
				audioShoot.Play();
			}
		}

		if(isHeld==false){
			if(Input.GetMouseButtonDown(0)){
				Shoot();
				audioShoot.Play();
			}
		}

	}


	void Shoot(){
		light.enabled=true;
		particleSystem.transform.position=transform.position;
		particleSystem.Play ();
		lineRenderer.enabled=true;
		lineRenderer.SetPosition(0,transform.position);
		Ray ray=new Ray(transform.position,transform.forward);
//		Ray ray=new Ray(transform.position,(Input.mousePosition-transform.position));
		RaycastHit hitInfo;
		if(Physics.Raycast(ray,out hitInfo)){
			lineRenderer.SetPosition(1,hitInfo.point);
			if(hitInfo.collider.tag==Tags.Enemy){
				hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attackValue,hitInfo.point);
			}
		}else{
			lineRenderer.SetPosition(1,transform.position+transform.forward*100);
		}

		Invoke("ClearEffect",0.05f);
	}

	void ClearEffect(){
		light.enabled=false;
		lineRenderer.enabled=false;
	}

}
