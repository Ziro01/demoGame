using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    public class managerGame : getDataForm_fileTXT
    {
        public static managerGame c_managerGame;
        public TextAsset Textasset_overGame;
        private void Awake() {
            c_managerGame = this;
        }

        public void readyGame(){
            string[] txtCount = {"เตรียมตัว !","3","2","1","เริ่ม!"};
            DialogueText.c_DialogueText.enter_DialogsReady(200,txtCount);
        }

        public void overGame(){
            txtList.Clear();
            getData_in_fileTXT(Textasset_overGame);
            int n = managerQuestion.random_Number(0,txtList.Count);
            manager_UI.c_manager_UI.gameOver(false ,managerQuestion.c_managerQuestion.setScore);
            DialogueText.c_DialogueText.enter_Dialog_over(100,txtList[n]);
        }

        public void Home(){
            SceneManager.LoadScene("game_home");
        }
    }
