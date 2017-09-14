using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

	public GameObject Config;
	public GameObject Main;
	public GameObject Credits;

	public Text sensibilityValue;
	public Text volumeValue;

	private bool menuOpen;
	private bool settingsOpen;
	private bool creditsOpen;

	//public Image background;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (true);
		OpenMenu ();
		sensibilityValue.text = "50";
		volumeValue.text = "50";
	}
	
	// Update is called once per frame
	void Update () {
		if (settingsOpen) {
			sensibilityValue.text = "" + Settings.GetSenseSliderValue ().ToString();
			volumeValue.text = "" + Settings.GetVolumeSliderValue ().ToString ();
		}
	}

	public void NewGame(){
		SceneManager.LoadScene ("Main Scene");
	}
		
	public void OpenSettings(){
		Main.SetActive (false);
		Config.SetActive (true);
		Credits.SetActive (false);
		menuOpen = false;
		settingsOpen = true;
		creditsOpen = false;
	}

	public void OpenMenu(){
		Main.SetActive (true);
		Config.SetActive (false);
		Credits.SetActive (false);
		menuOpen = true;
		settingsOpen = false;
		creditsOpen = false;
	}

	public void OpenCredits(){
		Main.SetActive (false);
		Config.SetActive (false);
		Credits.SetActive (true);
		menuOpen = false;
		settingsOpen = false;
		creditsOpen = true;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
