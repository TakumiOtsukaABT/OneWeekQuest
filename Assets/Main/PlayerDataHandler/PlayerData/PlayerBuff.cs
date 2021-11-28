using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    public List<int> buff_list = new List<int>();
    public int GetElement(int id)
    {
        foreach (var i in buff_list)
        {
            if (i.Equals(id))
            {
                return i;
            }
        }
        return 99;
    }
}
