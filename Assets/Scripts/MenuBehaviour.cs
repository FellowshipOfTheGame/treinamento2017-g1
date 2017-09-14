using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {

	public GameObject menu;
	private bool isPause;
	private bool isAudioPlaying;
	private bool isShowingTape;
	public GameObject[] buttons = new GameObject[3];
	public Text[] textos = new Text[3];
	public Image[] imagens = new Image[3];
	public Sprite keyButton;
	public Sprite tapeButton;
	public Sprite bgButton;

	// Use this for initialization
	void Start () {
		isPause = false;
		menu.gameObject.SetActive (false);
		isAudioPlaying = false;
		isShowingTape = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (isPause)
				PauseOff ();
			else
				PauseOn ();
		}
	}
	
	// O pause é chamado
	public void PauseOn(){
		isPause = true;
		gameObject.GetComponent<PlayerController> ().SetSpeed (0f); // O jogador para
		GetComponentInChildren<MouseController> ().SetSense (0f); //  O mouse trava (camera)
		menu.gameObject.SetActive(true); // A interface do menu aparece na tela
		isAudioPlaying = PlayerController.PauseAudio();	// Verifica se, antes do pause, havia alguma música tocando.
		Tapes();
	}

	// Sai do pause
	public void PauseOff(){
		isPause = false;
		gameObject.GetComponent<PlayerController> ().SetSpeed (3f); // A velocidade de movimento do jogador volta ao normal
		GetComponentInChildren<MouseController> ().SetSense (5f); // A velocidade da camera do jogador volta ao normal
		menu.gameObject.SetActive (false); // A interface do menu desaparece da tela
		isShowingTape = false;
		if (isAudioPlaying) {			// Se antes um áudio estava tocando e, no pause, não foi escolhida nenhuma fita, ele volta a tocar.
			PlayerController.ResumeAudio ();
			isAudioPlaying = false;
		} else
			PlayerController.StopAudio ();		// Se uma fita foi houvida enquanto
	}

	// Controle das fitas do inventário exibidas
	public void Tapes(){
		int i;
		string n;
		isShowingTape = true;
		buttons[2].SetActive(false);		// No momento só temos duas fitas. Então, só precisa de dois botões.
		for (i = 0; i < 2; i++) {	
			buttons[i].SetActive(true);		// Seta os botões como ativos
			if (PlayerController.items [i+1]) { 	// Se o player possui o item, aparece o identificador
				textos [i].text = "";
				imagens [i].sprite = tapeButton;
			}
			else{
				textos[i].text = "Slot vazio";	// Caso contrário, aparece que o espaço tá vazio
				imagens [i].sprite = bgButton;
			}
		}
	}

	// Controle das chaves do inventário exibidas
	public void Keys(){
		int i;
		string n;
		isShowingTape = false;
		PlayerController.StopAudio ();
		for (i = 0; i < 3; i++) {			// As três possíveis chaves
			buttons[i].SetActive(true);		// Seta os botões como ativos
			if (PlayerController.items [i + 3]) { 	// Se o player possui o item, aparece o identificador
				textos [i].text = "";
				imagens [i].sprite = keyButton;
			}
			else{
				textos[i].text = "Slot vazio";	// Caso contrário, aparece que o espaço tá vazio
				imagens [i].sprite = bgButton;
			}
		}
	}

	// Executa a tarefa ao clicar no botão de Slot1 do inventário
	public void Slot1(){
		if (isShowingTape) {					// Se estamos no menu de fitas
			if (PlayerController.items [1]) {	// Se o player possui o item
				PlayerController.PlayTape (1);	// Toca a fita
				isAudioPlaying = false;
			}
		} else {
			// O que ele vai fazer caso clique na chave?
		}
	}

	// Executa a tarefa ao clicar no botão de Slot2 do inventário
	public void Slot2(){
		if (isShowingTape) {					// Se estamos no menu de fitas
			if (PlayerController.items [2]){		// Se o player possui o item
				PlayerController.PlayTape (2);	// Toca a fita
				isAudioPlaying = false;
			}
		} else {
			// O que ele vai fazer caso clique na chave?
		}
	}

	// Executa a tarefa ao clicar no botão de Slot3 do inventário
	public void Slot3(){
		// O que ele vai fazer caso clique na chave?
	}

	// Executa a tarefa ao clicar no botão de Slot4 do inventário
	public void Slot4(){
		// O que ele vai fazer caso clique na chave?
	}

	// Executa a tarefa ao clicar no botão de Slot5 do inventário
	public void Slot5(){
		// O que ele vai fazer caso clique na chave?
	}
		
	// Executa a tarefa ao clicar no botão de Slot6 do inventário
	public void Slot6(){
		// O que ele vai fazer caso clique na chave?
	}

	// Executa a tarefa ao clicar no botão de Slot7 do inventário
	public void Slot7(){
		// O que ele vai fazer caso clique na chave?
	}
}
