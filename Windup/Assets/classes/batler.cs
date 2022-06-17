using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batler
{
    [SerializeField] private int maxHp = 100;
    private int hp;

    [SerializeField] private int maxWindup = 5;
    private int windup = 0;

    public List<equipment> batler_equip = new List<equipment>();
    public List<status_action> batler_status = new List<status_action>();

    public batler()
    {
        hp = maxHp;
        
    }

    public batler(int maxHpValue,int maxWindupValue)
    {
        maxHp = maxHpValue;
        hp = maxHpValue;
        maxWindup = maxWindupValue;
        
    }

    public batler(int maxHpValue, int maxWindupValue, equipment _equip1, equipment _equip2, equipment _equip3)
    {
        maxHp = maxHpValue;
        hp = maxHpValue;
        maxWindup = maxWindupValue;

        batler_equip.Add(_equip1);
        batler_equip.Add(_equip2);
        batler_equip.Add(_equip3);

    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int value)
    {
        hp = Mathf.Clamp(value, 0, maxHp);
    }

    public void DamageHp(int value)
    {
        hp = Mathf.Clamp(hp-value, 0, maxHp);
        
    }

    public int GetMaxWind()
    {
        return maxWindup;
    }

    public int GetWind()
    {
        return windup;
    }

    public void SetWind(int value)
    {
        windup = Mathf.Clamp(value,0, maxWindup);
    }

    public void LowerWind(int value)
    {
        windup = Mathf.Clamp(windup - value, 0, maxWindup);

    }
}
