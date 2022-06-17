using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prototype_TestBattleManager : MonoBehaviour
{
    private bool choseStateChange = true;

    [SerializeField] BattleManager battleManager;
    [SerializeField] Text HpDisplay_1;
    [SerializeField] Text WindupDisplay_1;
    [SerializeField] Text HpDisplay_2;
    [SerializeField] Text WindupDisplay_2;

    [SerializeField] Button[] ActionButtons;

    private batler batler_0;
    private batler batler_1;

    
    void Start()
    {
        //Always start on a scene with "Library_Initialization"

        batler_0 = new batler(30, 3, Library_Initialization.generalEquipmentList[1], Library_Initialization.generalEquipmentList[2], Library_Initialization.generalEquipmentList[3]);
        batler_1 = new batler(30, 3, Library_Initialization.generalEquipmentList[1], Library_Initialization.generalEquipmentList[2], Library_Initialization.generalEquipmentList[3]);
    }

    private void Update()
    {
        //make sure we update the buttons only when needed.       
        if (choseStateChange != battleManager.IsPlayerChosing())
        {
            ButtonUpdate();
            choseStateChange = battleManager.IsPlayerChosing();
        }

        PlayerUiUpdate();
        
    }

    public void StartBattle()
    {      
        battleManager.startCombatCoroutine(batler_0, batler_1);
    }

    private void PlayerUiUpdate()
    {
        //update hp and charge of batlers on screen
        HpDisplay_1.text = "Hp: " + batler_0.GetHp() + "/" + batler_0.GetMaxHp();
        HpDisplay_2.text = "Hp: " + batler_1.GetHp() + "/" + batler_1.GetMaxHp();
        WindupDisplay_1.text = "Charge: " + batler_0.GetWind() + "/" + batler_0.GetMaxWind();
        WindupDisplay_2.text = "Charge: " + batler_1.GetWind() + "/" + batler_1.GetMaxWind();

        
    }

    private void ButtonUpdate()
    {
        //used to update the information on the buttons
        //for action selection
        if (battleManager.IsPlayerChosing())
        {
            for (int i = 0; i < ActionButtons.Length && i < 3; i++)
            {
                ActionButtons[i].interactable = true;
                ActionButtons[i].GetComponentInChildren<Text>().text = battleManager.GetPlayerCombatList()[i].name;
            }
        }
        else
        {
            for (int i = 0; i < ActionButtons.Length && i < 3; i++)
            {
                ActionButtons[i].interactable = false;
            }
        }
    }
}
