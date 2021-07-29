using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class cardGame : MonoBehaviour
{
    public List<Sprite> imgcard = new List<Sprite>();
    public SpriteRenderer cardFace;
    public int cardId;
    public bool isReady = false;
    public int number;
    public void enter_Number(int _number){
        number = _number;
    }
    void OnMouseDown(){
        if(isReady == true){
            if(gameObject.tag == "card"){
                // manager_UI.c_manager_UI.choose_Card(cardId);
                managerQuestion.c_managerQuestion.addScore(number);
                StartCoroutine("Anim_Opencard");
                manager_UI.c_manager_UI.stetus_Card(false);
            }
        }
    }
    float x,y = 1,z;
    public GameObject cardsBack;
    public bool cardBackIsActive;
    private int timer;

    private void Start() {
        cardBackIsActive = false;
    }

    void Flip(){
        if(cardBackIsActive == true){ 
            cardsBack.SetActive(false);
            cardBackIsActive = false;
        }
        else{
            switch (number){
            case 5 :cardFace.sprite = imgcard[0];
            break;
            case 10 :cardFace.sprite = imgcard[1];
            break;
            case 15 :cardFace.sprite = imgcard[2];
            break;
            }
            cardsBack.SetActive(true);
            cardBackIsActive = true;
        }
    }

    public IEnumerator Anim_Opencard(){
        for (int i = 0; i < 180; i++){
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
                Flip();

            yield return new WaitForSeconds (0.00001f);
        }
        timer = 0;
        // print("stop");  //ให้ทำงานต่อ
        yield return new WaitForSeconds (2f);
        StartCoroutine("Anim_closecard");
        managerCard.c_managerCard.reset_Position();
        managerQuestion.c_managerQuestion.random_Question();
    }    

     public IEnumerator Anim_closecard(){
        for (int i = 0; i < 180; i++){
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
                Flip();

            yield return new WaitForSeconds (0.00001f);
        }
        timer = 0;
        // print("stop");  
    }   


    bool isMove;
    private void FixedUpdate() {
        if(transform.position.x != setPosition.x &&  transform.position.y != setPosition.y ){
            Vector2 setPoint = new Vector2(setPosition.x,setPosition.y);
            transform.position = Vector3.Lerp(transform.position, setPosition, Time.deltaTime * 2f);
        }    
    }
    Vector2 setPosition;
    public void move( Vector2 _position){
        setPosition =new Vector2(_position.x,_position.y);
    }

}
