using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerHelpe : MonoBehaviour
{
    public Button bttnHelper_1,bttnHelper_2,bttnHelper_3;
    void Start(){
        bttnHelper_1.onClick.AddListener(Helpe_1);
        bttnHelper_2.onClick.AddListener(Helpe_2);
        bttnHelper_3.onClick.AddListener(Helpe_3);
    }
    // void Update(){}

    public void Helpe_1(){
        Timer.c_Timer.resetTime();
        bttnHelper_1.gameObject.SetActive(false);
    }
    public void Helpe_2(){
        managerQuestion.c_managerQuestion.helper_2();
        bttnHelper_2.gameObject.SetActive(false);
    }
    public void Helpe_3(){
        float value = Random.value;
        if(value > 0.6f){ 
            string txtCount = "ค่อยๆคิด ลองเอาตัวเลขหลังมารวมกันก่อน ";
            DialogueText.c_DialogueText.enter_Dialog(90, txtCount);
            // print("Helpe_3 1");
        }
        else if(value > 0.6f){
            int n = managerQuestion.c_managerQuestion.answer;
            string txtCount = "ช่วยสักข้อ ละกัน ข้อนี้ตอบ " + n;
            DialogueText.c_DialogueText.enter_Dialog(90, txtCount);
            // print("Helpe_3 2");
        }
        else{
            int n = managerQuestion.c_managerQuestion.ranNumber[2];
            string txtCount = "ข้อนนี้คิดว่าตอบ " +n;
            DialogueText.c_DialogueText.enter_Dialog(90, txtCount);
        //    print("Helpe_3 3");
        } 

        bttnHelper_3.gameObject.SetActive(false); 
    }
}
