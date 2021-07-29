using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity.Examples;

public class manager_UI : MonoBehaviour
{
    public static manager_UI c_manager_UI;
    public Text txt_countTime;
    public Text txt_Score;
    public Text txt_Question;
    [Space(10)]
    public List<answer> AnswerID = new List<answer>();
    public List<cardGame> CardID = new List<cardGame>();
    private List<int> GetNumber = new List<int>();
    [Space(10)]
    public GameObject questionBox;
     [Space(10)]
     public GameObject helperBox;
     [Space(10)]
    public Image popup;
    public Sprite win;
    public Sprite lost;
    public Text txtOver;
    public Text txtscreOver;
    private void Awake() {
        c_manager_UI = this;
    }
    void Start(){managercontroCharacter.s_controCharacter.switchAnim(true);}
    public void display_Question(int _number1,int _number2){
        reset_Question();
        GetNumber.Clear();

        txt_Question.text = txt_Question.text = _number1 +" + "+_number2 +" = ?? ".ToString();
    
        for (int i = 0; i < AnswerID.Count; i++) {
           AnswerID[i].enter_Number(managerQuestion.c_managerQuestion.ranNumber[i]);
        }
    }

    public void display_Card(){
        for (int i = 0; i < CardID.Count; i++) {
           CardID[i].enter_Number(managerQuestion.c_managerQuestion.scoreCard[i]);
        }
    }
    public void stetus_Card(bool _stetus){
        for (int i = 0; i < CardID.Count; i++){
            CardID[i].isReady = _stetus;
        }
    }

    public  void helper_2(int _id){
        for (int i = 0; i < AnswerID.Count; i++) {
            if(i == _id)
                AnswerID[i].gameObject.SetActive(false);
        }
    }

    public  void reset_Question(){
        for (int i = 0; i < AnswerID.Count; i++) {
            AnswerID[i].gameObject.SetActive(true);
        }
    }

    public void display_countTime(string _time){
        txt_countTime.text = _time;
    }
    public void display_counScore(int _score){
        txt_Score.text = "คะแนน : "+_score.ToString();
    }

    public void swit_questionBox(bool _isStetus){
        if(_isStetus == true){
            helperBox.gameObject.SetActive(true);
            questionBox.SetActive(true);
        }
        else{
            helperBox.gameObject.SetActive(false);
            questionBox.SetActive(false);
        }
    }

    public void gameOver(bool _isStetus ,int _score){
        Timer.c_Timer.stopTime();
        swit_questionBox(false);
        popup.gameObject.SetActive(true);

        if(_isStetus == true){
            txtOver.text = "ผ่าน";
            txtscreOver.text = _score +"/50";
            popup.sprite = win;
        }
        else{
            managercontroCharacter.s_controCharacter.switchAnim(false);
            txtOver.text = "คุณไม่ผ่าน";
            txtscreOver.text = _score +"/50";
            popup.sprite = lost;
        }
        
    }

    
}
