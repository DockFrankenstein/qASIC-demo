using System.Collections.Generic;
using qASIC.Demo;
using qASIC.Console.Commands;

public class AICommand : GameConsoleCommand
{
    public override string CommandName { get; } = "ai";
    public override string Description { get; } = "toggles AI";
    public override string Help { get; } = "Use ai; ai <state>";
    
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
                newState = !EnemyController.IsActive;
                break;
        }

        EnemyController.IsActive = newState;
        Log($"Changed AI state to {(newState ? "active" : "disabled")}", "ai");
    }
}
