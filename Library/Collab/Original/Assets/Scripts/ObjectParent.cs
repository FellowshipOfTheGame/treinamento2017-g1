/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por destruir e armazenar um objeto no inventario do jogador*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParent : MonoBehaviour {
	
	public bool ObjInside; // Determina se o jogador esta dentro do raio de colizao do objeto
	public int id; // Codigo de cada objeto que sera utilizado no inventario

	// Use this for initialization
	void Start () {
		ObjInside = false; // Quando incicia esta fora do raio do objeto
		id = 1; // So pra teste, cada objeto vai ter um ID
	}
	
	// Update is called once per frame
	void Update () {

		// Se o player esta no raio de colisao do objeto e apertar a tecla "e"
		if (ObjInside && Input.GetKeyDown ("e")) {
			KeyboardController.SaveObject(this.gameObject, id); // O objeto e' salvo no inventario
			//Destroy(this.gameObject); // Destroi o objeto
		}
	}

	// Quando entrar no trigger do objeto
	void OnTriggerEnter(Collider col){
		ObjInside = true; // O objeto esta dentro
		print ("Colidindo"); // Para testar 
	}

	// Quando sai do trigger do objeto
	void OnTriggerExit(Collider col){
		ObjInside = false; // O objeto esta fora			
	}
}
