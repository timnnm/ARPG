﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character {
    public class AnimationEventBehaviour : MonoBehaviour
    {
 
        public Animator anim;

        private void Start()
        {
            anim = this.GetComponent<Animator>();
        }

        public delegate void AttackHandler();

        public event AttackHandler attackHandler;

        public void OnAttack()
        {
            Debug.Log("GGGGG");
            if (attackHandler != null) {
                attackHandler();
            }
        }
        public void OnCancelAnim(string animName)
        {
            Debug.Log("FFFFF");
            anim.SetBool(animName, false);
        }
    }
}

