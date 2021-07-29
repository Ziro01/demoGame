using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionCard : getDataForm_fileTXT
{
    public List<string> txtLists = new List<string>();
    public TextAsset enterTextasset;

    void Start(){
        getData_in_fileTXT(enterTextasset);

        foreach (var item in txtList)
        {
            txtLists.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
