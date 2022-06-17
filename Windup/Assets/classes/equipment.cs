using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment
{

    public string name = "Default equipment";
    public int equipSlot = 0;

    public passive_action passive;

    public List<combat_action> equipAction = new List<combat_action>();

    public equipment()
    {
    }

    public equipment(string _name, int slot, passive_action _passive, combat_action Action_0, combat_action Action_1, combat_action Action_2)
    {
        name = _name;

        equipSlot = slot;

        passive = _passive;

        equipAction.Add(Action_0);
        equipAction.Add(Action_1);
        equipAction.Add(Action_2);

    }
}
