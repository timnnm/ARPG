using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    public class PlayerStatus : CharacterStatus
    {
        public int Exp;
        public int MaxExp;


        /// <summary>
        /// 收集经验
        /// </summary>
        public void CollectExp()
        {


        }

        /// <summary>
        /// 升级
        /// </summary>
        public void LevelUp()
        {

        }

        override public void OnDamage()
        {

        }

        public override void Dead()
        {
            throw new System.NotImplementedException();
        }


    }
}
