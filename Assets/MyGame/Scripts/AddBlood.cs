using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AddBlood : MonoBehaviour {
	private GameObject MyPlayer;
//	public Stack<GameObject> StackBloodBar;
	private GameObject StackPeekBloodBar;
	private GameObject[] HeroBarTwenty;
	private GameObject HeroBar;
	private bool isRemoved;
	private bool isPlayParticle=false;
	private GameObject Blur;
	private GameObject Beam;

	private GameObject BlurRes;
	private GameObject BeamRes;
	private GameObject Portal;
	private float timer=0;
	// Use this for initialization
	void Start () {
		Portal=GameObject.Find("Portal");
		BlurRes=Resources.Load("Blur")as GameObject;
		BeamRes=Resources.Load("Beam")as GameObject;
		Debug.Log ("Beam:"+Beam);
		MyPlayer=GameObject.FindGameObjectWithTag(Tags.Player);

		HeroBarTwenty=new GameObject[21];
		for(int i=1;i<=20;i++){
			HeroBarTwenty[i]=Resources.Load("HeroBarTwenty"+i) as GameObject;
		}

		HeroBar=GameObject.Find("HeroBar");
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject==MyPlayer){
//			HeroBloodValue.HeroHp+=5f;
			print("heroHp:"+HeroBloodValue.HeroHp);
			if(HeroBloodValue.HeroBlood.Peek()==null)return;
			Debug.Log("HeroBloodValue.HeroBlood.Peek()"+HeroBloodValue.HeroBlood.Peek());
			for(int i=1;i<=20;i++){
				if(("HeroBarTwenty"+i)==HeroBloodValue.HeroBlood.Peek().name){
					if(GameObject.Find(HeroBloodValue.HeroBlood.Peek().name)){
						Debug.Log("GameObject.Find(HeroBarTwenty+(i+1):"+GameObject.Find("HeroBarTwenty"+i));
						if(HeroBloodValue.HeroHp<100){
							Debug.Log("GameObject.Find(HeroBarTwenty+(i+1):"+HeroBarTwenty[i+1]);
							GameObject tmp1=GameObject.Instantiate(HeroBarTwenty[i+1]);
							tmp1.name="HeroBarTwenty"+(i+1);
							tmp1.transform.parent=HeroBar.transform;
							tmp1.transform.localPosition=HeroBarTwenty[i+1].transform.localPosition;
							tmp1.transform.localEulerAngles=HeroBarTwenty[i+1].transform.localEulerAngles;
							HeroBloodValue.HeroBlood.Push(HeroBarTwenty[i+1]);
							//						Debug.Log ("HeroBloodValue.HeroBlood.Peek()"+HeroBloodValue.HeroBlood.Peek());
							HeroBloodValue.HeroHp+=5f;

							Destroy(gameObject);
							isRemoved=true;
						}
					}

				}
			}
//			if(HeroBloodValue.HeroHp<100){
//
//			}
			if(isRemoved==false){
				Destroy(gameObject);
			}

			isPlayParticle=true;
			if(isPlayParticle){
				AddBloodParticle ();
			}
		}
		
	}
	
	void AddBloodParticle ()
	{
		Blur=GameObject.Instantiate(BlurRes,MyPlayer.transform.position,MyPlayer.transform.rotation) as GameObject;
		Beam=GameObject.Instantiate(BeamRes,MyPlayer.transform.position,MyPlayer.transform.rotation)as GameObject;
		Blur.transform.parent=Portal.transform;
		Beam.transform.parent=Portal.transform;
		Beam.transform.localEulerAngles=Beam.transform.localEulerAngles+new Vector3(0,0,180);
		Blur.AddComponent<BloodParticleDestory>();
		Beam.AddComponent<BloodParticleDestory>();
		isPlayParticle=false;

	}


	// Update is called once per frame
	void Update () {

		Destroy(gameObject,30f);

	}
}
