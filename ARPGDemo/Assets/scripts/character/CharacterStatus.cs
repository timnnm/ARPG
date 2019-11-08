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
        virtual public  void OnDamage(int damageVal)
        {
            damageVal -= Defence;
            if (damageVal > 0) HP -= damageVal;
            if (HP <= 0) Dead();
        }

        public Transform HitFxPos;
        private void Start()
        {
            HitFxPos = TransformHelper.FindChild(this.transform, "HitFxPos");
        }


        /// <summary>
        /// 死亡
        /// </summary>
        abstract public void Dead();

    }
}
