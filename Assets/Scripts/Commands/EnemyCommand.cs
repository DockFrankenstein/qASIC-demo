using UnityEngine;
using System.Collections.Generic;
using qASIC;
using qASIC.Console.Commands;

public class EnemyCommand : GameConsoleCommand
{
    public override string CommandName { get; } = "enemy";
    public override string Description { get; } = "creates enemy";
    public override string Help { get; } = "Use enemy; enemy <position>";

    public override void Run(List<string> args)
    {
        if (!CheckForArgumentCount(args, 0, 1)) return;
        Vector2 newPosition;
        switch(args.Count)
        {
            case 2:
                if (VectorText.TryToVector2(args[1], out newPosition)) break;
                ParseException(args[1], "vector2");
                return;
            default:
                newPosition = qASIC.Demo.PlayerInstance.singleton.transform.position;
                break;
        }

        Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), newPosition, Quaternion.identity);
        Log($"Created Enemy at {VectorText.ToText(newPosition)}", "spawn");
    }
}
