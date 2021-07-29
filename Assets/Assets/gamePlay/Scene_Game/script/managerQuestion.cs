using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerQuestion : MonoBehaviour
{
    public static managerQuestion c_managerQuestion;
    public List<int> ranNumber = new List<int>();
    public int setScore; 
    public int answer = 0;
    private int number1,number2,answerAgain;
    private int min,max;
    private int valueAnswer,countAgain;
    private int valueRandom,specialNumber;
    private int Score; 
    private void Awake() {
        c_managerQuestion = this;
    }
    void Start(){
        valueAnswer = manager_UI.c_manager_UI.AnswerID.Count;
        levelGame(3);
    }

    // void Update(){}

    public void levelGame(int _level){
        switch (_level){
            case 1: min = 1; max = 10;
                break;
            case 2: min = 10; max = 40;
                break;
            case 3 : min = 50; max = 100;
                break;
        }
    }

    public static int random_Number(int _min,int _max){
        int number_ = Random.Range(_min,_max);
        return number_;
    }
    public static int calculate_Number(int _min,int _max){
        int x = random_Number(_min,_max);
        int y = random_Number(_min,_max);
        int numbers_ = x + y;
        return numbers_;
    }
    
    public void random_Question(){
        if(valueAnswer > 0){
            number1 = random_Number(min,max);
            number2 = random_Number(min,max);
            answer = number1 + number2;     

            if(answer == answerAgain){
                int n = random_Number(min,max);
                answer = answer + n;
                answerAgain = answer;
            }
            random_Answer();
        } 
        Timer.c_Timer.resetTime();
        manager_UI.c_manager_UI.swit_questionBox(true);
    }

    void random_Answer(){
        ranNumber.Clear();

        for (int i = 0; i < valueAnswer; i++) {
            valueRandom = calculate_Number(min,max);;
            ranNumber.Add(valueRandom);
        }
        check_numberAgain();  
    }
    
    void check_numberAgain(){
        specialNumber = 0;countAgain = 0;
        for (int i = 0; i < ranNumber.Count; i++) {
            for (int j = 0; j <  ranNumber.Count; j++){
                if(i != j){
                    if(ranNumber[i] == ranNumber[j]){
                        specialNumber++;
                        ranNumber[i] = max + max + specialNumber;
                    }
                }
            }
        }
        for (int k = 0; k < ranNumber.Count; k++) {
            if(ranNumber[k] == answer){
                countAgain++;
            }
        }
        if(countAgain == 0){
            int id_ = random_Number(0,ranNumber.Count);
            ranNumber[id_] = answer;
        }
        setQuestion_UI();
    }

    public void setQuestion_UI(){
        manager_UI.c_manager_UI.display_Question(number1,number2);
    }


    public void addScore(int _score){
        Score = _score;
        // random_Question();
    }

    public void chect_Answer( int _answer){
        manager_UI.c_manager_UI.swit_questionBox(false);

        if(_answer == answer){
            setScore = setScore + Score;
            manager_UI.c_manager_UI.display_counScore(setScore);
            if(setScore >= 50){
                manager_UI.c_manager_UI.gameOver(true,setScore);
                string txtCount = "ว้าว คุณเก่งมาก";
                DialogueText.c_DialogueText.enter_Dialog_over(150, txtCount);
            }
            else{
                Timer.c_Timer.pausesTime();
                managerCard.c_managerCard.outCards();
            }
        }
        else{
            manager_UI.c_manager_UI.gameOver(false,setScore);
            managerGame.c_managerGame.overGame();
        }
        
    }
    public int countHelper;
    public void helper_2(){
        countHelper = 0;
        for (int k = 0; k < ranNumber.Count; k++) {
            if(ranNumber[k] != answer && countHelper < 2){
                manager_UI.c_manager_UI.helper_2(k);
                countHelper++;
            }
        }
    }

    public List<int> scoreCard = new List<int>();
    public void swipCard(){
        int n = scoreCard.Count-1;
        for (int i = n; i > 0; i--){  
            int nr = Random.Range(0,n);
            int setN =  scoreCard[i];
            scoreCard[i] = scoreCard[nr];
            scoreCard[nr] = setN;
        } 
        manager_UI.c_manager_UI.display_Card();
    }
}
