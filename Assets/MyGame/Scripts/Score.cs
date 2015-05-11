using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private string MyScore;
	public static int crashScore;
	private Transform scoreLabel;
	private UILabel uiLabel;
	private GameObject UIScoreRoot;
	public Texture PauseTexture;
	public Texture GoOnTexture;
	private bool isPause=false;
	// Use this for initialization
	void Awake(){
//		UIScoreRoot=GameObject.Find("UIScoreRoot");
//		DontDestroyOnLoad(UIScoreRoot);

	}
	void Start () {
		scoreLabel=transform.Find("ScoreLabel").transform;
		uiLabel=scoreLabel.GetComponent<UILabel>();

	}
	
	// Update is called once per frame
	void Update () {
		MyScore="Score:"+crashScore;
		uiLabel.text=MyScore;
	}


	void OnGUI() {


		if(isPause==false){
			Time.timeScale=1;
			if(GUI.Button(new Rect(0, 0, 500, 150), PauseTexture)){
				isPause=true;
			}
		}

		if(isPause){
			Time.timeScale=0;
			if(GUI.Button(new Rect(0, 0, 500, 150), GoOnTexture)){
				isPause=false;
			}
		}



	}
}
