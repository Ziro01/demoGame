using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager_ingame : getDataForm_fileTXT
{
    public TextAsset Textasset_HomeGame;
    public string scenename;
   public void playGame(){
        int ths = saveTime_notification.convertH_s(saveTime_notification.get_timeHour());
        int tms = saveTime_notification.get_timeMinute();
        int hvms = ths + tms;
        // print("hvms : "+hvms);

        int thr = saveTime_notification.convertH_s(saveTime_notification.get_Hour());
        int tmr = saveTime_notification.get_Minute();
        int hvmr = thr + tmr;
        // print("hvmr : "+hvmr);

        if(hvmr > hvms){
            SceneManager.LoadScene(scenename);
        }
        else{
            txtList.Clear();
            getData_in_fileTXT(Textasset_HomeGame);
            int n = managerQuestion.random_Number(0,txtList.Count-1);
            DialogueText.c_DialogueText.enter_Dialog(150,txtList[n]);
        }
            

   }
}
