using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour {
	public static DialogueText c_DialogueText;
	public GameObject textBox;
	public Text text_Dialog;
	public string txt;
	public int textSize;
	[Tooltip("max number message")] public int message_max;
	public float setTime = 1f;

	public int Count = 0;
	private void Awake() {
		c_DialogueText = this;
	}
	// void Start () {}
	public bool isRedy = true;
	public void enter_Dialog(int _txtSize,string _dialog){
		text_Dialog.fontSize = _txtSize;
		StartCoroutine(DisplayString(_dialog));
		textBox.SetActive(true);
	}
	public IEnumerator DisplayString(string txt_dialox){
		if(isRedy == true){
			isRedy = false;
			int txt_value = txt_dialox.Length;
			int txt_index = 0;
			
			while(txt_index<txt_value){
				txt += txt_dialox[txt_index];
				text_Dialog.text = txt;
				txt_index++;

				if(txt_index<txt_value){
					yield return new WaitForSeconds(0.1f);
				}
				else{
					yield return new WaitForSeconds(1f);
					text_Dialog.text = txt ="";
					textBox.SetActive(false);
					isRedy = true;
					break;
				}
			}
		}
	}
	public void enter_DialogsReady(int _txtSize,string[] _dialog){
		text_Dialog.fontSize = _txtSize;
		StartCoroutine(DialogsReady(_dialog));
		textBox.SetActive(true);
	}
	public IEnumerator DialogsReady(string[] txt_dialox){
		if(isRedy == true){
			isRedy = false;
			for (int i = 0; i < txt_dialox.Length; i++){
				text_Dialog.text = "";
				
				if(i < txt_dialox.Length)
					text_Dialog.text = txt_dialox[i];

				yield return new WaitForSeconds(setTime);
			}
			isRedy = true;
			textBox.SetActive(false);
			// managerGame.c_managerGame.stratGame();
			managerCard.c_managerCard.outCards();
		}
	}

	public void enter_Dialogs_Win(int _txtSize,string[] _dialog){
		text_Dialog.fontSize = _txtSize;
		StartCoroutine(Dialogs_Win(_dialog));
		textBox.SetActive(true);
	}
	public IEnumerator Dialogs_Win(string[] txt_dialox){
		if(isRedy == true){
			isRedy = false;
			for (int i = 0; i < txt_dialox.Length; i++){
				text_Dialog.text = "";
				
				if(i < txt_dialox.Length)
					text_Dialog.text = txt_dialox[i];

				yield return new WaitForSeconds(setTime);
			}
			isRedy = true;
			textBox.SetActive(false);
			managerGame.c_managerGame.overGame();
		}
	}

	public void enter_Dialog_over(int _txtSize,string _dialog){
		text_Dialog.fontSize = _txtSize;
		StartCoroutine(Dialog_over(_dialog));
	}
	public IEnumerator Dialog_over(string txt_dialox){
		if(isRedy == true){
			isRedy = false;
			int txt_value = txt_dialox.Length;
			int txt_index = 0;
			textBox.SetActive(true);
			
			
			while(txt_index<txt_value){
				txt += txt_dialox[txt_index];
				text_Dialog.text = txt;
				txt_index++;

				if(txt_index<txt_value){
					yield return new WaitForSeconds(0.1f);
				}
				else{
					yield return new WaitForSeconds(2f);
					text_Dialog.text = txt ="";
					textBox.SetActive(false);
					isRedy = true;
					managerGame.c_managerGame.Home();
					break;
				}
			}
		}
		else{
			yield return new WaitForSeconds(1.5f);
			managerGame.c_managerGame.Home();
			// isRedy = true;
		}
	}
	
}
