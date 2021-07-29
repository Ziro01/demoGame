using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCard : MonoBehaviour
{
    public static managerCard c_managerCard;
    public List<Transform> position = new List<Transform>();
    private void Awake() {
        c_managerCard = this;
    }
    private void Start() {
        // outCards();
        reset_Position();
    }

    public void outCards(){
        managerQuestion.c_managerQuestion.swipCard();
        for (int i = 0; i < manager_UI.c_manager_UI.CardID.Count; i++){
            manager_UI.c_manager_UI.CardID[i].gameObject.SetActive(true);
            Vector2 vec2 = new Vector2(position[i+1].position.x,position[i+1].position.y);
            manager_UI.c_manager_UI.CardID[i].move(vec2);
        }
        manager_UI.c_manager_UI.stetus_Card(true);
    }
    public void reset_Position(){
        for (int i = 0; i < manager_UI.c_manager_UI.CardID.Count; i++){
            Vector2 vec2 = new Vector2(position[0].position.x,position[0].position.y);
            manager_UI.c_manager_UI.CardID[i].move(vec2);
        }
    }
}
