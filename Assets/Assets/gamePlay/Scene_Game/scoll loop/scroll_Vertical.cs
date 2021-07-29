using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
public class scroll_Vertical : MonoBehaviour
{
   
    public RectTransform panel;
    public RectTransform center;
    public int IDing;
    public getValue[] bttn;
    
    public int startButton = 1;
    public float[] distance;
    public float[] distReposition;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private  int bttnLenght;
    private bool messageSend = false;
    private float speed = 10f;
    private bool targetIndex = true;


    private float setPhase,maxBffn;

    void Start(){
        for(int i = 0; i < bttn.Length;i++){
            Vector2 pos = new Vector2(0,setPhase);
            bttn[i].transform.localPosition  = pos;
            bttn[i].enter_number(i);
            setPhase -= 130;
        }
        

        bttnLenght = bttn.Length;
        maxBffn = bttn[bttnLenght-1].transform.localPosition.y;
        distance = new float [bttnLenght];
        distReposition = new float[bttnLenght];

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.y - bttn[0].GetComponent<RectTransform>().anchoredPosition.y);
        // print(bttnDistance);
    }
    void Update(){
        for (int i = 0; i < bttn.Length; i++){
            distReposition[i] = center.GetComponent<RectTransform>().position.y - bttn[i].GetComponent<RectTransform>().position.y; 
            // distance[i] = Mathf.Abs(center.transform.position.y - bttn[i].transform.position.y);
            distance[i] = Mathf.Abs(distReposition[i]);

            if(distReposition[i] > maxBffn){
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX , curY + (bttnLenght * bttnDistance));
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }

            if(distReposition[i] < -maxBffn){
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX , curY - (bttnLenght * bttnDistance));
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }
        if(targetIndex){
            float minDistance = Mathf.Min(distance);
            for (int j = 0; j < bttn.Length; j++){
                if(minDistance == distance[j])
                    minButtonNum = j;
            }
            
        }

        if(! dragging)
            LerpToBttn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.y);
            // IDing = minButtonNum;        
    }
    void LerpToBttn(float _poosition){
        float newY = Mathf.Lerp(_poosition,panel.anchoredPosition.y,Time.deltaTime * speed);

        if(Mathf.Abs(_poosition - newY) < 5f)
            speed = 1f;
        
        if(Mathf.Abs(newY) >= Mathf.Abs(_poosition)-1f && Mathf.Abs(newY) <= Mathf.Abs(_poosition)+1f && !messageSend){
            IDing = minButtonNum;
            messageSend = true;
            
            // print("bnt : "+bttn[minButtonNum].name);
        }
        
        Vector2 newPosition = new Vector2(panel.anchoredPosition.x,newY);
        panel.anchoredPosition = newPosition;
    }

    public void startDrag(){
        messageSend = false;
        speed = 5f;
        dragging = true;
        targetIndex = true;
    }
    public void endDrag(){
        dragging = false;
    }

    public void index_ID(int _enter){
        targetIndex = false;
        minButtonNum = _enter;
        IDing = minButtonNum;
    }
}
