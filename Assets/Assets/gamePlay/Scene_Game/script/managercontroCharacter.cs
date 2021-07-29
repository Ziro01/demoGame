using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Spine.Unity.Examples {
    public class managercontroCharacter : MonoBehaviour
    {
        public static managercontroCharacter s_controCharacter;
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idle1,idle2;
        private void Awake() {
            s_controCharacter = this;
        }

        public void switchAnim(bool _isStetus){
            var state = skeletonAnimation.AnimationState;
            if(_isStetus == true){
                state.SetAnimation(0, idle1, false);
            }
            else{
                state.SetAnimation(0, idle2, false);
            }
             
            
        }

        
    }
}
