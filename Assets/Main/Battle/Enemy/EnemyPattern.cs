using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    public List<GameObject> commands = new List<GameObject>();
    private int index = 0;

    public void runPatternedBattleCommand()
    {
        commands[index].GetComponent<EnemyBaseCommand>().runActionCommand();
        index = (index + 1) % commands.Count;
    }
}
