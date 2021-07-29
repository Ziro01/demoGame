using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getValue : MonoBehaviour
{
    public Text txt;
    public void enter_number(int _number){
        if(_number < 10){
            txt.text = "0"+_number.ToString();
        }
        else{
            txt.text =_number.ToString();
        }
    }
}
