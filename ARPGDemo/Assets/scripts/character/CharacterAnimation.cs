using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        public Animator anim;

        public void Start()
        {
            anim = this.GetComponentInChildren<Animator>();
        }

        public void PlayAnimation(string name, bool show)
        {
            anim.SetBool(name, show);
        }




    }
}
