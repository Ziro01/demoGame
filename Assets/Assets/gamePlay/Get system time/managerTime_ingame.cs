using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerTime_ingame : MonoBehaviour
{
    public static managerTime_ingame c_inGame;
    private void Awake() {
        c_inGame = this;
    }
    void Start(){
        saveTime_notification.c_saveTime.set_time(1,2);
        print(saveTime_notification.get_timeMinute());
    }
    void Update(){}

    public void in_Game(){
        
    }


}
