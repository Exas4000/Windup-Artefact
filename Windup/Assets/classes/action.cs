using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action
{


    /// <summary>
    /// General parent class for the various aspect of  the combat system. could encompass Passives, Combat actions and status effects
    /// </summary>
    /// 
    public string name = "Default Action";
    public string description = "This is a default description from the action class.";

    public int effectNumber_0 = 0;
    public int effectNumber_1 = 0;
    public int effectNumber_2 = 0;
    public int effectNumber_3 = 0;

    //will be called once once batlers are initialized. reserved for passives actions
    public virtual void OnPreBattle(bool isPlayerAction, BattleManager _manager)
    {

    }

    //called once per turn at start of the turn, reserved for passive actions
    public virtual void OnStartTurn(bool isPlayerAction, BattleManager _manager)
    {

    }

    //called once per turn at once combat actions have been settled on (could be used for passive and any actions benefitting from going first)
    public virtual void OnCombatStart(bool isPlayerAction, BattleManager _manager)
    {

    }

    //Main function called for any combat actions. 
    public virtual void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {

    }

    //for any actions doing something after their OnActionUsed()
    public virtual void OnPostAction(bool isPlayerAction, BattleManager _manager)
    {

    }

    //for after all actions were called, could also be used for actions benefitting from going last
    public virtual void OnCombatEnd(bool isPlayerAction, BattleManager _manager)
    {

    }

    //for passives 
    public virtual void OnEndTurn(bool isPlayerAction, BattleManager _manager)
    {

    }

    //for any passive effects activating from winning/losing a combat
    public virtual void OnPostBattle(bool isPlayerAction, BattleManager _manager)
    {

    }
}

public class combat_action : action
{

    public int chargeCost = 0;

    public combat_action()
    {
        name = "Default Combat Action";
        description = "this is the default combat_action description.";
    }

    public combat_action(int num0, int num1, int num2, int num3)
    {
        effectNumber_0 = num0;
        effectNumber_1 = num1;
        effectNumber_2 = num2;
        effectNumber_3 = num3;

        name = "Default Combat Action with numbers";
        description = "this is the default combat_action description.\nnum0 = " + effectNumber_0 + ". num1 = " + effectNumber_1 + 
            ". num2 = " + effectNumber_2 + ". num3 = " + effectNumber_3 + ".";
    }

}

public class passive_action : action
{

    public bool isPositive = false;

    public passive_action()
    {
        name = "Default Passive Action";
        description = "this is the default passive_action description.";
    }

    public passive_action(int num0, int num1, int num2, int num3)
    {
        effectNumber_0 = num0;
        effectNumber_1 = num1;
        effectNumber_2 = num2;
        effectNumber_3 = num3;

        name = "Default Passive Action with numbers";
        description = "this is the default passive_action description.\nnum0 = " + effectNumber_0 + ". num1 = " + effectNumber_1 +
            ". num2 = " + effectNumber_2 + ". num3 = " + effectNumber_3 + ".";
    }



}

public class status_action : action
{

    public int stacks = 0;
    public bool isPositive = false;

    public status_action()
    {
        name = "Default Status Effect";
        description = "this is the default passive_action description.";
    }

    public status_action(int num0, int num1, int num2, int num3, int quantity)
    {
        effectNumber_0 = num0;
        effectNumber_1 = num1;
        effectNumber_2 = num2;
        effectNumber_3 = num3;

        stacks = quantity;

        name = "Default Status Effect with numbers";
        description = "this is the Status effect description.\nnum0 = " + effectNumber_0 + ". num1 = " + effectNumber_1 +
            ". num2 = " + effectNumber_2 + ". num3 = " + effectNumber_3 + ". Stacks = " + stacks + ".";
    }



}

