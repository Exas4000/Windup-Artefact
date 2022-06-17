using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prototype_BatlerTester : MonoBehaviour
{
    List<batler> fighterList = new List<batler>();
    [SerializeField] Text HpDisplay_1;
    [SerializeField] Text WindupDisplay_1;
    [SerializeField] Text HpDisplay_2;
    [SerializeField] Text WindupDisplay_2;

    [SerializeField] Text equipmentText;
    

    // Start is called before the first frame update
    void Start()
    {
        fighterList.Add(new batler(120, 3));
        fighterList.Add(new batler());

        UiInfoRefresh();

        TestEquipment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UiInfoRefresh()
    {
        HpDisplay_1.text = "Hp: " + fighterList[0].GetHp() + "/" + fighterList[0].GetMaxHp();
        HpDisplay_2.text = "Hp: " + fighterList[1].GetHp() + "/" + fighterList[1].GetMaxHp();
        WindupDisplay_1.text = "Charge: " + fighterList[0].GetWind() + "/" + fighterList[0].GetMaxWind();
        WindupDisplay_2.text = "Charge: " + fighterList[1].GetWind() + "/" + fighterList[1].GetMaxWind();
    }

    public void DebugDamage_1()
    {
        fighterList[0].DamageHp(10);
    }

    public void DebugSetMaxHP_1()
    {
        fighterList[0].SetHp(fighterList[0].GetMaxHp());
    }

    public void Debugheal_1()
    {
        fighterList[0].DamageHp(-10);
    }

    public void DebugCharge_1()
    {
        fighterList[0].LowerWind(-1);
    }

    public void DebugSpendCharge_1()
    {
        fighterList[0].LowerWind(1);
    }

    public void TestEquipment()
    {

        fighterList.Add(new batler(30,3,new equipment("Joe's key", 0, new passive_action(), new combat_action(1,1,1,1), new combat_action(), new combat_action()), new equipment(), new equipment()));

        equipmentText.text = "Testing " + fighterList[2].batler_equip[0].name + "\n" + fighterList[2].batler_equip[0].equipAction[0].name + " : " + fighterList[2].batler_equip[0].equipAction[0].description;
    }

   
}
