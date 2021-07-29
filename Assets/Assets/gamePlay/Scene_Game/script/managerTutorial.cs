using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerTutorial : MonoBehaviour
{
    public GameObject toturialBox;
    public GameObject menuBox;
     public GameObject LevelBox;
    public Sprite [] tutorial_ID;
    public Image disPlay;
    public Button bntNext,bntBack,bntSkip;

    public int countID;

    void Start(){
        disPlay.sprite = tutorial_ID[countID];
    }
    public void next(){
        if(countID < tutorial_ID.Length -1){
            countID ++;
            disPlay.sprite = tutorial_ID[countID];
        }
        else{
            Display_Level();
        }
    }
    public void back(){
        if(countID > 0){
            countID --;
            disPlay.sprite = tutorial_ID[countID];
        }
    }
    public void select_Level(int _level){
        
        managerQuestion.c_managerQuestion.levelGame(_level);
        managerGame.c_managerGame.readyGame();
        toturialBox.SetActive(false);
    }
    public void Display_Level(){
        menuBox.gameObject.SetActive(false);
        disPlay.gameObject.SetActive(false);
        LevelBox.gameObject.SetActive(true);
    }
    public void skip(){
        Display_Level();
        // 
        // 
    }
}
