/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por matar o personagem caso ele entre em contato com um objeto
   OBSERVACAO: Usado no puzzle do chao para o chao matar o jogador*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKiller : MonoBehaviour {

	public GameObject killer;
	public GameObject playerAll;
	private Collider player;
	public bool objInside;
	private float angle; // angulo final que a porta vai alcancar

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Se o jogador esta dentro do trigger do objeto
	void OnTriggerEnter(Collider col){
		Destroy (playerAll);
		objInside = true; // O jogador esta dentro do campo de colisao do objeto interativo do puzzle 1
		print ("Colidindo"); // teste
		player = col;
		//player = col;
	}

	// Se o jogador sai de dentro do trigger do objeto
	void OnTriggerExit(Collider col){
		objInside = false;	// O jogador esta fora do campo de colisao de objeto interativo do puzzle 1		
	}
}
