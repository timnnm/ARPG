using System;

using ARPGDemo.Skill;
using ARPGDemo.Character;
using System.Collections.Generic;

public class DeployerConfig
{
    public static IAttackSelector CreateAttackSelector(SkillData skill) {

        IAttackSelector attackSelector = null;
        switch (skill.damageMode) {
            case DamageMode.Circle:
                attackSelector = new CircleAttackSelector();
                break;

            case DamageMode.Sector:
                attackSelector = new SectorAttackSelector();
                break;

        }

        return attackSelector;
    }

    public static List<ISelfImpact> CreateSelfImpact(SkillData skill)
    {
        List<ISelfImpact> impactList = new List<ISelfImpact>();
        impactList.Add(new CostPSSelfImpact());

        return impactList;

    }

    public static List<ITargetImpact> CreateTargetImpact(SkillData skill)
    {
        List<ITargetImpact> list = new List<ITargetImpact>();
        list.Add(new DamageTargetImpact());

        return list;
    }

}
