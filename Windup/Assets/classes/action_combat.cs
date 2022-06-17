using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_clash : combat_action
{
    //simple clashing action template class, for damaging action based on highest rolls.
    public combat_clash(int num0, int num1, string clashName)
    {
        effectNumber_0 = num0;//min value
        effectNumber_1 = num1;//max value

        name = clashName;

        description = "Clash the opponent for " + effectNumber_0 + "-" + effectNumber_1 + " damage.";
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        int clashValue = Random.Range(effectNumber_0, effectNumber_1);

        _manager.CommandClash(isPlayerAction,clashValue);
    }
}

public class combat_defend : combat_action
{
    //simple block action template class, for damage reduction
    public combat_defend(int num0, int num1, string blockName)
    {
        effectNumber_0 = num0;//min value
        effectNumber_1 = num1;//max value

        name = blockName;

        description = "Reduce incoming damage by a value between " + effectNumber_0 + "-" + effectNumber_1 + ".";
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        int clashValue = Random.Range(effectNumber_0, effectNumber_1);

        _manager.CommandBlockChange(isPlayerAction, clashValue);
    }
}

public class combat_charge : combat_action
{
    //simple block action template class, for damage reduction
    public combat_charge(int num0, string chargeName)
    {
        effectNumber_0 = num0; //used as the charge to be gained/lost

        name = chargeName;

        description = "Gain " + effectNumber_0 + " ability charge.";
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        _manager.CommandChargeChange(isPlayerAction,effectNumber_0);
    }
}

public class combat_keyHeal : combat_action
{
    //simple block action template class, for damage reduction
    public combat_keyHeal(int num0, int num1, string clashName)
    {
        effectNumber_0 = num0; //heal ammount, negative = heal
        chargeCost = num1;//cost to use

        name = clashName;

        description = "Spend" + chargeCost + " ability charges to heal " + effectNumber_0 + " health.";
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        //who is using this? does he have the energy for it?
        if (isPlayerAction && _manager.GetBatlerList()[0].GetWind() >= effectNumber_1) //player
        {
            _manager.CommandHealthChange(isPlayerAction, effectNumber_0);
            _manager.CommandChargeChange(isPlayerAction,-chargeCost);
        }
        else if (_manager.GetBatlerList()[1].GetWind() >= effectNumber_1) //rival
        {
            _manager.CommandHealthChange(isPlayerAction, effectNumber_0);
            _manager.CommandChargeChange(isPlayerAction, -chargeCost);
        }
    }
}

public class combat_clashDefend : combat_action
{
    //simple clashing action template class, for damaging action based on highest rolls.
    //also add defend actions
    public combat_clashDefend(int num0, int num1, int num2, int num3, string clashName)
    {
        effectNumber_0 = num0;//min value clash
        effectNumber_1 = num1;//max value clash
        effectNumber_2 = num2;//min value defend
        effectNumber_3 = num3;//max value defend

        name = clashName;

        description = "Clash the opponent for " + effectNumber_0 + "-" + effectNumber_1 + " damage and reduce incoming damage by a value between " + effectNumber_2 + "-" + effectNumber_3 + ".";
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        int clashValue = Random.Range(effectNumber_0, effectNumber_1);
        int blockValue = Random.Range(effectNumber_2, effectNumber_3);

        _manager.CommandClash(isPlayerAction, clashValue);
        _manager.CommandBlockChange(isPlayerAction, blockValue);
    }
}


