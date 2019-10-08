using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    abstract public class CharacterStatus : MonoBehaviour, IOnDamager
    {
        public int HP;
        public int MaxHP;
        public int SP;
        public int MaxSP;
        public int Damage;
        public int Defence;
        public int attackSpeed;
        public int attackDistance;



        /// <summary>
        /// 受击
        /// </summary>
        abstract public void OnDamage();


        /// <summary>
        /// 死亡
        /// </summary>
        abstract public void Dead();

    }
}
