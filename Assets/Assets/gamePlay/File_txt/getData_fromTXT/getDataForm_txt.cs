using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class getDataForm_txt : MonoBehaviour
{
    // public List<string> txtList = new List<string>();
    public List<string> txtList = new List<string>();
    public TextAsset textAsset;
    void Start(){
         readValue_txt();
    }
    void Update(){
        
    }
    public void readValue_txt(){
        txtList = textAsset.text.Split('\n').ToList();
    }
}
