using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameOverUIControll : MonoBehaviour {
	private GameObject score;
	private UILabel uiCurrentLabel;
	void Start () {
		score=GameObject.Find("Score");
		uiCurrentLabel=score.GetComponent<UILabel>();

	}
	
	// Update is called once per frame
	void Update () {
		uiCurrentLabel.text="YourScore:"+Score.crashScore;
	}
	public void RestartGame(){
		Debug.Log("RestartGame");
		Score.crashScore=0;
		HeroBloodValue.HeroHp=100f;
		HeroBloodValue.HeroBlood=null;
		HeroBloodValue.HeroBlood=new Stack<GameObject>();
		EnemyTotal.Count=0;
		Application.LoadLevel("LoadGame");


	}
	public void Quit(){
		Debug.Log("Quit");
		Application.Quit();
	}
}
