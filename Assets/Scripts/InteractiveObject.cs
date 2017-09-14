/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por iniciar as interfaces dos puzzles quando houver interacao entre o objeto do puzzle e o jogador*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour {
	
	public Text passwordNow; // senha que esta sendo digitada neste momento
	private Collider player; // Representa o corpo interativo do Player 
	private string currentPassword; // Senha certa que deve ser inserida
	public int passwordLength;
	public string password; // Senha que o jogador esta digitando no momento
	public GameObject puzzle1; // Objeto interativo do puzzle 1
	private bool ObjInside; // Booleano que fica verdadeiro quando o jogador esta perto do objeto interativo  
	private int id;
	private AudioSource audio;
	public Text guideText;
	public Image guideImage;
	public GameObject doorToOpen;

	// Use this for initialization
	void Start () {
		ObjInside = false; // Jogador inicia fora dos arredores do objeto interativo do puzzle 1
		puzzle1.SetActive (false); // A interface do puzzle 1 desaparece 
		//password = "1234567"; // Senha certa que deve ser digitada
		currentPassword = ""; // Senha que sera digitada inicia vazia
		guideText.enabled = false;
		guideImage.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (passwordNow.text != "FALSO") {
			ChangeText ();
		}

		if (currentPassword.Length == passwordLength) { 

			// Se a senha digitada for igual a senha 
			if (currentPassword == password) {
				print ("You did it!"); // Teste
				puzzle1.SetActive (false); // A interface do puzzle 1 desaparece
				player.gameObject.GetComponent<PlayerController> ().SetSpeed (3f); // A velocidade de movimento do jogador volta ao normal
				player.GetComponentInChildren<MouseController> ().SetSense (5f); // A velocidade da camera do jogador volta ao normal
				PlayerController.SaveObject(this.id);	// Adiciona o objeto ao inventário
				audio = GetComponent<AudioSource> (); // Pega o audio 
				//audio.Play (); // Toca o audio
				audio.PlayDelayed (44100); // Necessario para tocar o audio
				doorToOpen.GetComponent<DoorBehaviour>().setExtraConditionToOpenDoors(true);
			} 
			else { // Se a senha estiver errada
				passwordNow.text = "FALSO";
				currentPassword = "";
			}

		}

		// Se o jogador esta dentro do campo ao redor do objeto interativo e aperta "e" 
		if (ObjInside && Input.GetKeyDown ("e")) {
			player.gameObject.GetComponent<PlayerController> ().SetSpeed (0f); // O jogador para
			player.GetComponentInChildren<MouseController> ().SetSense (0f); //  O mouse trava (camera)
			puzzle1.gameObject.SetActive(true); // A interface do puzzle 1 aparece na tela
			guideText.enabled = false;
			guideImage.enabled = false;
		}

		//Se o jogador esta dentro do campo ao redor do objetoe aperta "ESC"
		if (ObjInside && Input.GetKeyDown (KeyCode.Escape)) {
			currentPassword = ""; // A senha que estava sendo digitada volta a ser nada
			player.gameObject.GetComponent<PlayerController> ().SetSpeed (3f); // A velocidade de movimento do jogador volta ao normal
			player.GetComponentInChildren<MouseController> ().SetSense (5f); // A velocidade da camera do jogador volta ao normal
			puzzle1.gameObject.SetActive (false); // A interface do puzzle 1 desaparece da tela
		}

	}

	/*IEnumerator ExecuteAfterTime(float time) {
		yield return new WaitForSeconds (time);
	}*/

	// Se o jogador esta dentro do trigger do objeto
	void OnTriggerEnter(Collider col){
		ObjInside = true; // O jogador esta dentro do campo de colisao do objeto interativo do puzzle 1
		print ("Colidindo interactive"); // teste
		player = col;
		guideText.enabled = true;
		guideImage.enabled = true;
	}

	void ChangeText () {
		passwordNow.text = currentPassword;
	}

	// Se o jogador sai de dentro do trigger do objeto
	void OnTriggerExit(Collider col){
		ObjInside = false;	// O jogador esta fora do campo de colisao de objeto interativo do puzzle 1
		guideText.enabled = false;
		guideImage.enabled = false;
	}

	//Funcao para o botao 1, todas as funcoes seguintes fazem a mesma coisa para botoes diferentes
	public void Button1 () {
		currentPassword += "1"; // Adiciona "1" na string que armazena a senha que esta sendo digitada
		passwordNow.text = currentPassword;
	}

	public void Button2 () {
		currentPassword += "2";
		passwordNow.text = currentPassword;
	}

	public void Button3 () {
		currentPassword += "3";
		passwordNow.text = currentPassword;
	}

	public void Button4 () {
		currentPassword += "4";
		passwordNow.text = currentPassword;
	}

	public void Button5 () {
		currentPassword += "5";
		passwordNow.text = currentPassword;
	}

	public void Button6 () {
		currentPassword += "6";
		passwordNow.text = currentPassword;
	}

	public void Button7 () {
		currentPassword += "7";
		passwordNow.text = currentPassword;
	}

	public void Button8 () {
		currentPassword += "8";
		passwordNow.text = currentPassword;
	}

	public void Button9 () {
		currentPassword += "9";
		passwordNow.text = currentPassword;
	}

	// ATENCAO, O Button10 escreve "0"
	public void Button10 () {
		currentPassword += "0";
		passwordNow.text = currentPassword;
	}

}
