using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ARPGDemo.Skill {

    [Serializable]
    public class SkillData 
    {
        //技能ID
        public int skillID;
        //技能名称
        public string name;
        //技能描述
        public string description;
        //冷却时间
        public int coolTime;
        //冷却剩余
        public int coolRemain;
        //魔法消耗
        public int costSP;
        //攻击距离
        public float attackDistance;
        //攻击角度
        public float attackAngle;
        //攻击目标
        public string[] acctackTargetTags = { "Enemy", "Boss" };
        //攻击目标对象数组;
        [HideInInspector]
        public GameObject[] attackTargets;
        //连击的下一个技能编号
        public int nextBatterId;
        //伤害比率
        public float damage;
        //持续时间
        public float durationTime;
        //伤害间隔
        public float damageInterval;
        //技能所属
        [HideInInspector]
        public GameObject Onwer;
        //技能预制件名称
        public string perfabName;
        //预制件对象
        [HideInInspector]
        public GameObject skillPerfab;
        //动画名称
        public string animationName;
        //受击特效名称
        public string hitFxName;
        //受击特效对象
        [HideInInspector]
        public GameObject hitFxPerfab;
        //等级
        public int level;
        //是否激活
        public bool activated;

        //技能类型
        public SkillAttackType attackType;
        //伤害模式
        public DamageMode damageMode;
        

    }



}

