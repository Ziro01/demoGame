using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class display_selectLvel : getDataForm_fileTXT
{
    public Text[] txt_bnt; 
    public TextAsset enterTextasset;
    void Start(){
        getData_in_fileTXT(enterTextasset);
        try{
            for (int i = 0; i < txt_bnt.Length; i++){
                txt_bnt[i].text = txtList[i];
            }
        }
        catch (Exception e) {
            Debug.Log(e);
        }
    }
}
