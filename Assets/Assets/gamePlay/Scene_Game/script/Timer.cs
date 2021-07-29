using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using UnityEditor;

[DisallowMultipleComponent]
public class Timer : MonoBehaviour {
    public static Timer c_Timer;
   public float currentSec;
    private static bool _timer_is_pause = true;
    public static bool timer_is_pause {
        get {
            return _timer_is_pause;
        }
        set {
            if(value!= _timer_is_pause){ 
                _timer_is_pause = value;
            }
        }
    }
    private bool runTime;
    private float _time,setTime; 
    private float _default_pauseTime; 

    private void Awake() {
        c_Timer = this;
    }
    void Start(){
        _time = currentSec;
        setTime = currentSec;
        // startTime();
    }
    bool pauses;

    private void Update() {
        if(pauses == true ){
            if(_time > 0 && pauses == true){
                _time -= Time.deltaTime;
                currentSec = Mathf.Floor(_time);
                UpdateLevelTimer(currentSec);
                
                if (currentSec <= 0) {
                    if (runTime == true) {
                        runTime = false;
                    }  
                    manager_UI.c_manager_UI.display_countTime("00 : 00");
                    managerGame.c_managerGame.overGame();
                    stopTime();
                //---------------------------------time over-------------------------------//
                }      
            }                
        }
	} 
    
    public  void startTime() {
        pauses = true;
        runTime = true;
    }
    public  void resetTime() {
        _time = setTime;
        pauses = true;
        runTime = true;
    }

    public void pausesTime(){
        pauses = false;
    }

    public void stopTime() {
        timer_is_pause = true;
    }
    public void UpdateLevelTimer(float totalSeconds) {
		int minutes = Mathf.FloorToInt(totalSeconds / 60f);
		int seconds = Mathf.RoundToInt(totalSeconds % 60f);
		if (seconds == 60) {
			seconds = 0;
			minutes += 1;
		}
		// txt_timer.text = minutes.ToString("00") + " : " + seconds.ToString("00");
        string txt = minutes.ToString("00") + " : " + seconds.ToString("00");
        manager_UI.c_manager_UI.display_countTime(txt);
	}
}