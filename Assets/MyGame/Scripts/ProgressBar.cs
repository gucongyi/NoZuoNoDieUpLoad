using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	float hp=0;
	public Texture GroupTexture;
	public Texture DTexture;
	private AsyncOperation asyncOperation;
	private float timer=0f;
	void Start(){
		StartCoroutine(LoadScene());
	}
	void Update () {
		if(hp<630){
			hp+=3;
			timer+=Time.deltaTime;
		}
		if(hp==630){
			Debug.Log(timer);
		}

	}
	IEnumerator LoadScene(){
		yield return new WaitForSeconds(3.75f);
		asyncOperation=Application.LoadLevelAsync("NoZuoNoDie");

	}
	void OnGUI(){
		GUI.BeginGroup(new Rect(Screen.width/2-400, Screen.height-120, 800, 100),GroupTexture);
//		hp is bloodBar's width
		GUI.DrawTexture(new Rect(84,34,hp,42),DTexture);
		GUI.EndGroup();
	}
}
