using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScroll : MonoBehaviour
{
    public static managerScroll c_managerScroll;
    public InputField enterHours;
    public InputField enterMinute;

    public scroll_Vertical scrollHours;
    public scroll_Vertical scrollMinute;
    private void Awake() {
        c_managerScroll = this;
    }
    private void Start() {
        scrollHours.index_ID(saveTime_notification.get_timeHour());
        scrollMinute.index_ID(saveTime_notification.get_timeMinute());

        enterHours.gameObject.SetActive(false);
        enterMinute.gameObject.SetActive(false);

    }
    // void Update() {}
 int countTime;
    public void save_Time(){
        int h = scrollHours.IDing; 
        int m = scrollMinute.IDing; 
        saveTime_notification.c_saveTime.set_time(h,m);
        print( "sH : " + h + "sM : "+ m);
        print( "gH : " + saveTime_notification.get_timeHour() + "gM : "+ saveTime_notification.get_timeMinute());

        int hr = saveTime_notification.convertH_s(saveTime_notification.get_Hour());
        int mr = saveTime_notification.get_Minute();
        int Tr = hr + mr;

        int hs = saveTime_notification.convertH_s(saveTime_notification.get_timeHour());
        int ms = saveTime_notification.get_timeMinute();
        int Ts = hs + ms;

        if(Tr <  Ts){
            countTime = Ts - Tr;
        }
        else{
            int day = 24;
            countTime = (saveTime_notification.convertH_s(day) - Tr) + Ts;
        }
    }

    
    public void resrt_Time(){
        saveTime_notification.c_saveTime.set_time(0,0);
        scrollHours.index_ID(0);
        scrollMinute.index_ID(0);

    }
    public void enter_Hours(){
        enterHours.gameObject.SetActive(true);
        enterHours.text = "";
        StartCoroutine("Anim_Hours");
        // print("enter_Hours");
    }

    public void enter_Minute(){
        enterMinute.gameObject.SetActive(true);
        enterMinute.text = "";
        StartCoroutine("Anim_Minute");
        // print("enter_Minute");
    }
    public IEnumerator Anim_Hours(){
        while(true){
            if(enterHours.text != "" && enterHours.text.Length < 3){
                int h = int.Parse(enterHours.text); 
                if(h > 0 && h <3){
                    yield return new WaitForSeconds (1f); 
                    if(h > 0 && h < 23){
                        inputHours(h);
                    }
                    else{
                    inputHours(23);
                    }
                }
                else {
                inputHours(h);
                }
            }
            else{
                enterHours.text = "";
            }
        yield return new WaitForSeconds (2f); 
        }
    }   

    public IEnumerator Anim_Minute(){
       while(true){
        if(enterMinute.text != "" && enterMinute.text.Length < 3){
            int m =int.Parse(enterMinute.text);
            if(m > 0 && m < 6){
                yield return new WaitForSeconds (1f); 
                if(m > 0 && m < 59){
                    inputMinute(m);
                }
                else{
                    inputMinute(59);  
                }
            }
            else {
                inputMinute(m);
            }
        }
        else{
            enterMinute.text = "";
        }
       yield return new WaitForSeconds (2f); 
       }
    }    

    void inputHours(int _h){
        int H = _h;
        if(_h > 23)
            H = 23;

        scrollHours.index_ID(H);
        enterHours.gameObject.SetActive(false);
        StopCoroutine("Anim_Hours");
        print( "h :"+_h);
        
    }
    void inputMinute(int _m){
        int M = _m;
        if(_m > 59)
            M = 59;

        scrollMinute.index_ID(_m);
        enterMinute.gameObject.SetActive(false);
        StopCoroutine("Anim_Minute");
        print( "M :"+_m);
    }
}
