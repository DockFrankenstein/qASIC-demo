using System.Collections.Generic;
using qASIC.Demo;
using qASIC.Console.Commands;

public class GunCommand : GameConsoleCommand
{
    public override string CommandName { get; } = "gun";
    public override string Description { get; } = "toggles gun";
    public override string Help { get; } = "Use gun; gun <state> to toggle fun";
    public override string[] Aliases { get; } = new string[] { "weapon", "fun" };
    
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
                newState = !PlayerGunController.IsActive;
                break;
        }

        PlayerGunController.IsActive = newState;
        Log($"Changed gun state to {(newState ? "active" : "disabled")}", "gun");
    }
}
