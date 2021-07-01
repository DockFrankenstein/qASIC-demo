using System.Collections.Generic;
using qASIC.Console.Commands;

public class SpeedCommand : GameConsoleCommand
{
    public override string CommandName { get; } = "speed";
    public override string Description { get; } = "controlls the speed of the player";
    public override string Help { get; } = "Use speed <amount>";
    
    public override void Run(List<string> args)
    {
        if (!CheckForArgumentCount(args, 1)) return;
        
        if(!float.TryParse(args[1], out float value))
        {
            ParseException(args[1], "float");
            return;
        }

        qASIC.Demo.PlayerController.SpeedMultiplier = value;
    }
}
