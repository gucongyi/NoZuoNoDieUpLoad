using UnityEngine;
using System.Collections;

public class MenuControll : MonoBehaviour {

	public void StartGame(){
		Debug.Log("StartGame");
		Application.LoadLevel("LoadGame");
	}
	public void GameHelp(){
		Application.LoadLevel("GameHelp");
		Debug.Log("GameHelp");
	}
	public void QuitGame(){
		Debug.Log("QuitGame");
		Application.Quit();
	}
	public void ReturnMainMenu(){
		Debug.Log("ReturnMainMenu");
		Application.LoadLevel("MainMenu");
	}

}
