using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    List<batler> listBatler = new List<batler>();

    List<combat_action> playerCombatActions = new List<combat_action>();
    List<combat_action> rivalCombatActions = new List<combat_action>();

    private bool playerChosingAction = false; //are we in a moment where the player can decide actions.
    private bool battleIsStarted = false;
    private bool battleIsEnded = false;
    //private float animationDelay = 0; //internal timer for animations


    //stored number for batler command
    private int healthChange_player = 0; //for direct changes unnafected by other factors
    private int healthChange_rival = 0; //for direct changes unnafected by other factors
    private int chargeChange_player = 0;
    private int chargeChange_rival = 0;
    private int clashPower_player = 0; //highest deal damage to opposing side
    private int clashPower_rival = 0; //highest deal damage to opposing side
    private int blockPower_player = 0;
    private int blockPower_rival = 0;




    public void startCombatCoroutine(batler player, batler rival)
    {
        if (rival != null & player != null)
        {
            listBatler.Add(player);
            listBatler.Add(rival);

            //coroutine to start
            StartCoroutine(combatStages());
        }
       
    }

    //
    public void CommandWriteInDebug(bool isPlayerAction, string debugMessage)
    {
        if (isPlayerAction)
        {
            Debug.Log("Player debug : " + debugMessage);
        }
        else
        {
            Debug.Log("Rival debug : " + debugMessage);
        }
    }

    public void CommandClash(bool isPlayerAction, int clashValue)
    {
        if (isPlayerAction)
        {
            clashPower_player = clashValue;
        }
        else
        {
            clashPower_rival = clashValue;
        }
    }

    public void CommandHealthChange(bool isPlayerAction, int healthValue)
    {
        //positive = hurt, negative = heal
        if (isPlayerAction)
        {
            healthChange_player = healthValue;
        }
        else
        {
            healthChange_rival = healthValue;
        }
    }

    public void CommandChargeChange(bool isPlayerAction, int chargeValue)
    {
        //positive = gain charge, negative = lose charge
        if (isPlayerAction)
        {
            chargeChange_player = chargeValue;
        }
        else
        {
            chargeChange_rival = chargeValue;
        }
    }

    public void CommandBlockChange(bool isPlayerAction, int blockValue)
    {
        if (isPlayerAction)
        {
            blockPower_player = blockValue;
        }
        else
        {
            blockPower_rival = blockValue;
        }
    }

    //to resolve any changes in health or charges of the batlers
    private void ResolveClashActionsFunctions()
    {
        if (clashPower_player - clashPower_rival != 0)
        {
            if (clashPower_player > clashPower_rival)
            {
                //player won clash
                listBatler[1].DamageHp(Mathf.Clamp(clashPower_player - blockPower_rival,0,999));
            }
            else
            {
                //rival won clash
                listBatler[0].DamageHp(Mathf.Clamp(clashPower_rival - blockPower_player, 0, 999));
            }
        }

        clashPower_player = 0;
        clashPower_rival = 0;
        blockPower_player = 0;
        blockPower_rival = 0;

        ResolveHealthActionsFunctions();
    }

    private void ResolveHealthActionsFunctions()
    {
        if (chargeChange_player != 0)
        {
            listBatler[0].LowerWind(-chargeChange_player);
        }

        if (chargeChange_rival != 0)
        {
            listBatler[1].LowerWind(-chargeChange_rival);
        }

        if (healthChange_player != 0)
        {
            listBatler[0].DamageHp(healthChange_player);
        }

        if (healthChange_rival != 0)
        {
            listBatler[1].DamageHp(healthChange_rival);
        }

        chargeChange_player = 0;
        chargeChange_rival = 0;
        healthChange_player = 0;
        healthChange_rival = 0;
    }

    private void AddStatusToBattler(batler statusTarget)
    {

    }

    private void GenerateRandomCombatActionList()
    {
        //clear the action list.
        playerCombatActions.Clear();
        rivalCombatActions.Clear();
        int randomNum = 0;

        for (int i = 0; i < 3; i++)
        {
            randomNum = Random.Range(0, 3);
            playerCombatActions.Add(listBatler[0].batler_equip[i].equipAction[randomNum]);

            randomNum = Random.Range(0, 3);
            rivalCombatActions.Add(listBatler[1].batler_equip[i].equipAction[randomNum]);
        }

       
    }

    //small button function in order to indicate when a player can interact with the User interface
    public void EnableDisablePlayerChosing(bool isChosing)
    {
        playerChosingAction = isChosing;
    }

    public bool IsPlayerChosing()
    {
        return playerChosingAction;
    }

    public void EnableDisableEndCombat(bool isEnd)
    {
        battleIsEnded = isEnd;
    }

    public List<combat_action> GetPlayerCombatList()
    {
        return playerCombatActions;
    }

    public List<batler> GetBatlerList()
    {
        return listBatler;
    }



    public void RegisterCombatAction(combat_action actionToRegister, bool isPlayerAction)
    {
        if (isPlayerAction)
        {
            playerCombatActions.Add(actionToRegister);
        }
        else
        {
            rivalCombatActions.Add(actionToRegister);
        }
    }

    public void ClearSingleActionList(int actionToClear, bool isPlayerList)
    {
        if (isPlayerList)
        {
            playerCombatActions.Remove(playerCombatActions[actionToClear]);
        }
        else
        {
            rivalCombatActions.Remove(rivalCombatActions[actionToClear]);
        }
        
    }

    public void ClearFullActionList(bool isPlayerList)
    {
        if (isPlayerList)
        {
            playerCombatActions.Clear();
        }
        else
        {
            rivalCombatActions.Clear();
        }
    }

    private IEnumerator combatStages()
    {

        if (!battleIsStarted)
        {
            //call once effect of passive at the start of the match
            yield return StartCoroutine(PreBattleBehaviour());
        }

        yield return StartCoroutine(TurnStartBehaviour());

        yield return StartCoroutine(CombatBehaviour());

        yield return StartCoroutine(TurnEndBehaviour());

        if (battleIsEnded)
        {
            yield return StartCoroutine(PostBattleBehaviour());
            

        }
        else
        {
            StartCoroutine(combatStages());
        }


    }


    private IEnumerator PreBattleBehaviour()
    {
        //activating passives
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnPreBattle(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnPreBattle(false,this);

            ResolveHealthActionsFunctions();
        }

        battleIsStarted = true;

        yield return null;
    }

    private IEnumerator PostBattleBehaviour()
    {
        //activating passives
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnPostBattle(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnPostBattle(false,this);

            ResolveHealthActionsFunctions(); //not the most useful yet. could be interesting if we have lasting healthdamage in a greater game.
        }


        return null;
    }

    private IEnumerator TurnStartBehaviour()
    {
        
        GenerateRandomCombatActionList();
        playerChosingAction = true;

        //activating passives
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnStartTurn(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnStartTurn(false,this);

            ResolveHealthActionsFunctions();
        }

        //stay in this phase until player is done chosing combat actions.
        while (playerChosingAction)
        {
            yield return null;
        }

        
    }

    private IEnumerator TurnEndBehaviour()
    {


        //activating passives at end of turn
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnEndTurn(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnEndTurn(false,this);

            ResolveHealthActionsFunctions();
        }

       yield return null;


    }

    private IEnumerator CombatBehaviour()
    {

        //activating passives at combat start
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnCombatStart(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnCombatStart(false,this);

            ResolveHealthActionsFunctions();
        }

        //oppener moves
        playerCombatActions[0].OnCombatStart(true,this);
        rivalCombatActions[0].OnCombatStart(false,this);

        ResolveHealthActionsFunctions(); //should not clash, thus we only call for charge and health resolution.

        //cycling through all 3 combat actions in the order chosen by the player.
        for (int i = 0; i < 3; i++)
        {

            //for passives that activates every combat action
            //resolve these first in case we do power ups for clash related stuff.
            for (int j = 0; j < 3; j++)
            {
                //player
                listBatler[0].batler_equip[j].passive.OnActionUsed(true, this);
                //rival
                listBatler[1].batler_equip[j].passive.OnActionUsed(false, this);

                yield return new WaitForSeconds(1);
            }

            //player
            playerCombatActions[i].OnActionUsed(true,this);
            //rival
            rivalCombatActions[i].OnActionUsed(false,this);

            yield return new WaitForSeconds(1);

            ResolveClashActionsFunctions();
        }

        //closer moves effects
        playerCombatActions[2].OnCombatEnd(true,this);
        rivalCombatActions[2].OnCombatEnd(false,this);

        ResolveHealthActionsFunctions();

        //activating passives at combat end
        for (int i = 0; i < 3; i++)
        {
            //player
            listBatler[0].batler_equip[i].passive.OnCombatEnd(true,this);
            //rival
            listBatler[1].batler_equip[i].passive.OnCombatEnd(false,this);

            ResolveHealthActionsFunctions();
        }

    }
}
