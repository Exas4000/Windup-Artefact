using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class passive_selfDamage : passive_action
{
    public override void OnPreBattle(bool isPlayerAction, BattleManager _manager)
    {
        base.OnPreBattle(isPlayerAction, _manager);

    }
}

public class passive_debugTest : passive_action
{
    public override void OnPreBattle(bool isPlayerAction, BattleManager _manager)
    {
        base.OnPreBattle(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " pre-battle check");
    }

    public override void OnActionUsed(bool isPlayerAction, BattleManager _manager)
    {
        base.OnActionUsed(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on Action Used check");
    }

    public override void OnCombatEnd(bool isPlayerAction, BattleManager _manager)
    {
        base.OnCombatEnd(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on Combat End check");
    }

    public override void OnCombatStart(bool isPlayerAction, BattleManager _manager)
    {
        base.OnCombatStart(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on Combat Start check");
    }

    public override void OnEndTurn(bool isPlayerAction, BattleManager _manager)
    {
        base.OnEndTurn(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on end turn check");
    }

    public override void OnPostAction(bool isPlayerAction, BattleManager _manager)
    {
        base.OnPostAction(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on post Action check");
    }

    public override void OnPostBattle(bool isPlayerAction, BattleManager _manager)
    {
        base.OnPostBattle(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " post-battle check");
    }

    public override void OnStartTurn(bool isPlayerAction, BattleManager _manager)
    {
        base.OnStartTurn(isPlayerAction, _manager);

        _manager.CommandWriteInDebug(isPlayerAction, " on start turn check");
    }
}
