using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swippingValue : MonoBehaviour
{
    // public List<int> items = new List<int>();
    public List<int> data = new List<int>();
    public void swipping(){
        int n = data.Count-1;
        for (int i = n; i > 0; i--){  
            int nr = Random.Range(0,n);
            int setN =  data[i];
            data[i] = data[nr];
            data[nr] = setN;
        } 
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
