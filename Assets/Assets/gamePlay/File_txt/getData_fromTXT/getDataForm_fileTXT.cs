using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class getDataForm_fileTXT : MonoBehaviour
{
    public List<string> txtList = new List<string>();
    // public TextAsset textAsset;
    
    public void getData_in_fileTXT(TextAsset textAsset){
        txtList = textAsset.text.Split('\n').ToList();  
    }
}
