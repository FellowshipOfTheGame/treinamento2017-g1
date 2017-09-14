/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel pelo gerenciamento do player: sua movimentação e seu inventário.
   */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//keyboard
	public float speed = 10f;
	public static bool[] items = new bool[10];
	public static RaycastHit raycast;
	public static bool hit;
	private Vector3 forward;
	private static AudioSource audio;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Confined;		// O cursor não aparece e mantém dentro da game window.
		for (int i = 1; i < 6; i++)	// Inicializa o inventário vazio.
			items [i] = false;
		audio = GameObject.Find ("Audio1").GetComponent<AudioSource> ();	// Leve gambi!
		items [0] = true;
	}

	// Update is called once per frame
	void Update () {
		//forward = transform.TransformDirection (Vector3.forward)*3;			// Pega o que está à frente
		//hit = Physics.Raycast(transform.position, forward, out raycast);	// Se tá dando raycast
		keyboard ();
	}

	// Movimentação do teclado
	private void keyboard(){
		float rotX, rotZ;
		rotX = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;		// Movimento em X
		rotZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;			// Movimento em Z
		this.transform.Translate (rotX, 0, rotZ);							// Translação

		if (Input.GetKeyDown ("escape"))			// Se sair, retorna o cursor ao modo normal
			Cursor.lockState = CursorLockMode.None;
	}

	// Guarda um objeto no inventário
	public static void SaveObject(int id){
		items[id] = true;
		print ("Guardou o objeto " /*+ items[id].name*/);
		if(id < 3 && id > 0) // Se o item recuperado é uma fita, chama o método que a toca.
			PlayTape(id);
	}

	// Toca a fita correspondente ao id dado
	public static void PlayTape(int id){
		//Identifica qual áudio deve ser tocado a partir do id.
		StopAudio();
		switch (id) {
		case 1:
			audio = GameObject.Find ("Audio1").GetComponent<AudioSource> ();
			break;
		case 2:
			audio = GameObject.Find ("Audio2").GetComponent<AudioSource> ();
			break;
		}

		audio.Play ();
		audio.volume = Settings.GetVolume ();
		audio.Play (44100);
	}

	// Para de tocar um áudio, se estiver tocando. Usado no pause do game. Retorna true se havia um áudio tocando ou false, caso contrário.
	public static bool PauseAudio(){
		if (audio.isPlaying) {
			audio.Pause ();
			return true;
		}
		return false;
	}

	// Volta a tocar o áudio, caso estivesse tocando antes do pause.
	public static void ResumeAudio(){
		audio.UnPause ();
	}

	//Para de tocar o áudio definitivamente, caso esteja tocando.
	public static void StopAudio(){
		if (audio.isPlaying)
			audio.Stop ();
	}

	public void SetSpeed (float speed) {
		this.speed = speed;
	}

}
