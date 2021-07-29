using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answer : MonoBehaviour
{
    public Text txt_number;
    public int number;

    public void enter_Number(int _number){
        number = _number;
        txt_number.text = number.ToString();
    }
    public void send_Answer(){
       managerQuestion.c_managerQuestion.chect_Answer(number);
    }
}
