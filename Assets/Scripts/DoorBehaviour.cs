/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por girar a porta*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

	//public GameObject porta;
	public float speed;
	private bool objInside; // Booleano que fica verdadeiro quando o jogador esta perto do objeto interativo
	private bool ePressionado; // Marca se o "e" foi pressionado
	public float angle; // angulo final que a porta vai alcancar
	private Collider player; // Representa o corpo interativo do Player 
	public int id; // Identidade da porta
	public bool ladoGirar; // Criado para resolver o problema da porta do guarda-roupa, na qual cada lado gira para um lado e o maior e menor no codigo nao funcionariam
	public float anguloGirar; // Angulo que o objeto vai girar
	public bool extraConditionToOpenDoors; //Condição extra para abrir a porta, no caso de precisar de um password

	// Use this for initialization
	void Start () {
		objInside = false; // Jogador inicia fora do campo de colisao do objeto
		ePressionado = false; // O "e" inicia como nao pressionado
		angle = this.transform.eulerAngles.y + anguloGirar; // A porta vai girar 85 graus
	}
	
	// Update is called once per frame
	void Update () {

		// Se o jogador esta dentro do campo de colisao o objeto e o "e" foi pressionado
		if (objInside && Input.GetKeyDown ("e")) {
			ePressionado = true; // Marca que o "e" foi pressionado
		}

		// Se o jogador esta dentro do campo de colisao e a variavel que marca que o "e" foi pressionado esta ativada
		if (objInside && ePressionado && PlayerController.items[id] && extraConditionToOpenDoors == true) {

			// Se a porta ainda nao foi aberta
			// Gita para angulos positivos
			if (this.transform.eulerAngles.y < angle && ladoGirar == true) {
				if (this.transform.eulerAngles.y == angle + anguloGirar) {
					AudioSource audio = GetComponent<AudioSource> (); // Pega o audio 
					audio.Play (); // Toca o audio
					audio.Play (44100); // Necessario para tocar o audio
				}
				this.transform.Rotate (Vector3.up * speed); // gira a porta 85 graus
			}

			// Se a porta ainda nao foi aberta
			// Gira para angulos negativos
			if (this.transform.eulerAngles.y > angle && ladoGirar == false) {
				if (this.transform.eulerAngles.y == angle - anguloGirar) {
					AudioSource audio = GetComponent<AudioSource> (); // Pega o audio 
					audio.Play (); // Toca o audio
					audio.Play (44100); // Necessario para tocar o audio
				}
				this.transform.Rotate (Vector3.up * (-speed) ); // gira a porta 85 graus
			}


		}

		// Se a porta ja abriu
		if (this.transform.eulerAngles.y >= angle && ladoGirar == true) {
			ePressionado = false;
		}

		// Se a porta ja abriu
		if (this.transform.eulerAngles.y <= angle && ladoGirar == false) {
			ePressionado = false;
		}

	}

	// Se o jogador esta dentro do trigger do objeto
	void OnTriggerEnter(Collider col){
		objInside = true; // O jogador esta dentro do campo de colisao do objeto interativo do puzzle 1
		print ("Colidindo"); // teste
		player = col;
		//player = col;
	}

	// Se o jogador sai de dentro do trigger do objeto
	void OnTriggerExit(Collider col){

		// Se a porta ainda nao foi aberta ou ja abriu por completo
		// Para angulos positivos
		if (this.transform.eulerAngles.y == angle - anguloGirar || this.transform.eulerAngles.y >= angle) { 
			if (ladoGirar == true) {
				objInside = false;	// O jogador esta fora do campo de colisao de objeto interativo do puzzle 1		
				ePressionado = false;
			}
		}

	}

	public void setExtraConditionToOpenDoors (bool value){
		this.extraConditionToOpenDoors = value;
	}

}
