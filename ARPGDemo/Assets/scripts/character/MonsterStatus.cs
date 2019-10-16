using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    public class MonsterStatus : CharacterStatus
    {

        public int GiveExp;

        override public void OnDamage(int damageVal)
        {

        }

        public override void Dead()
        {
            throw new System.NotImplementedException();
        }
    }
}
