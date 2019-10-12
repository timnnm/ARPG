using UnityEngine;
using System;

namespace ARPGDemo.Skill
{

    public interface IAttackSelector
    {
       
        GameObject[] SelectTagrget(SkillData skillData,Transform transform);
        
    }
}
