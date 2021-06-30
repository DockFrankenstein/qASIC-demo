using System.Collections.Generic;
using qASIC.Console.Commands;
using UnityEngine;

public class NoclipCommand : GameConsoleCommand
{
    public override string CommandName { get; } = "noclip";
    public override string Description { get; } = "toggles noclip";
    public override string Help { get; } = "Use noclip; noclip <state>";
    public override string[] Aliases { get; } = new string[] { "nc" };

    static bool noclip = false;
    
    public override void Run(List<string> args)
    {
        if (!CheckForArgumentCount(args, 0, 1)) return;
        bool newState;

        switch(args.Count)
        {
            case 2:
                if (bool.TryParse(args[1], out newState)) break;
                ParseException(args[1], "bool");
                return;
            default:
                newState = !noclip;
                break;
        }

        noclip = newState;
        for (int i = 0; i < 31; i++)
            if (LayerMask.LayerToName(i).Length > 0)
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), i, noclip);
        Log($"Noclip has been {(noclip ? "enabled" : "disabled")}", "cheat");
    }
}
