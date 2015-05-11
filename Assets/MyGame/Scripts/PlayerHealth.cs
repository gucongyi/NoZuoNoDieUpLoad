using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

	public float hp;
	private Animator anim;
	PlayerMove playerMove;
	private float smoothing=5f;
	SkinnedMeshRenderer bodyRenderer;
	PlayerShoot   playerShoot;
	public AudioSource deathAudio;
	public AudioSource huntAudio;
	private GameObject[] HeroBar;
	private GameObject popHeroBar;
	private GameObject peekHeroBar;
	private GameObject HeroBarBg;
	private GameObject HeroBarBgBack;


	void Awake() {
		anim=GetComponent<Animator>();
		playerMove=GetComponent<PlayerMove>();

	}
	void Start () {
		hp=HeroBloodValue.HeroHp;
		bodyRenderer=transform.Find("PlayerHasMat").GetComponent<Renderer>() as SkinnedMeshRenderer ;
		playerShoot=transform.GetComponentInChildren<PlayerShoot>();
		HeroBar=new GameObject[21];
		HeroBarBg=GameObject.Find("HeroBarBg");
		HeroBarBgBack=GameObject.Find("HeroBarBgBack");
//		HeroBlood=new Stack<GameObject>();
		for(int i=1;i<=20;i++){
			HeroBar[i]=GameObject.Find("HeroBarTwenty"+i);
			HeroBloodValue.HeroBlood.Push(HeroBar[i]);
		}
//		Debug.Log(HeroBlood.Count);
	}
	

	public void TakeDamage(float damage){
		if(HeroBloodValue.HeroHp<=0){
			return;
		}
		HeroBloodValue.HeroHp-=damage;
		print ("PlayerHealth hp:"+HeroBloodValue.HeroHp);
		if(HeroBloodValue.HeroBlood.Count>0){
			while((damage/5)>0){
				peekHeroBar=HeroBloodValue.HeroBlood.Peek();
				popHeroBar=HeroBloodValue.HeroBlood.Pop();

				if(popHeroBar!=null&&peekHeroBar==popHeroBar){
					Destroy(GameObject.Find(popHeroBar.name));
					damage-=5f;
				}

			}
		}
		if(HeroBloodValue.HeroBlood.Count==0){
			Destroy(HeroBarBg);
			Destroy(HeroBarBgBack);
		}
		huntAudio.Play();
		bodyRenderer.material.color=Color.red;
		if(HeroBloodValue.HeroHp<=0){

			anim.SetBool("Dead",true);
			Dead();
		}

	}

	void Dead(){
		deathAudio.Play();
		playerMove.enabled=false;
		playerShoot.enabled=false;

	}
	void Update () {
//		if(Input.GetMouseButtonDown(0)){
//			TakeDamage(30);
//		}
		hp=HeroBloodValue.HeroHp;
		bodyRenderer.material.color=Color.Lerp(bodyRenderer.material.color,Color.white,smoothing*Time.deltaTime);
		if(HeroBloodValue.HeroHp<=0){
			Destroy(GameObject.Find ("MyPlayer").GetComponent<Rigidbody>());
			GameObject.Find ("MyPlayer").transform.Translate(Vector3.down*Time.deltaTime*0.5f);

			if(transform.position.y<=-2){
				Destroy(GameObject.Find ("MyPlayer"));
				Application.LoadLevel("GameOver");
			}
		}

	}
}
