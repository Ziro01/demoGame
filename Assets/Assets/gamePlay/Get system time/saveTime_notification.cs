using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class saveTime_notification : MonoBehaviour
{
    public static saveTime_notification c_saveTime = null;
    int countTime;
    private void Awake(){
		if (c_saveTime == null){
			c_saveTime = this;
		}
		else if (c_saveTime != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);


        Input.backButtonLeavesApp = true;
	}

    void Start(){
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            // OnApplicationQuit();
        }
    }
    public void set_time(int _h,int _m){  //time save
        PlayerPrefs.SetInt("H",_h);
        PlayerPrefs.SetInt("M",_m);
    }
    public static int get_timeHour(){
        int h= PlayerPrefs.GetInt("H");
        return h;
    }

    public static int get_timeMinute(){
        int m =  PlayerPrefs.GetInt("M");
        return m;
    }

    public static int get_Hour(){
        int rt_h = System.DateTime.Now.Hour;
        return rt_h;
    }
    public static int get_Minute(){
        int rt_m = System.DateTime.Now.Minute;
        return rt_m;
    }

    public static int convertH_s(int _h){
        int s = _h *60;
        return s;
    }
}
