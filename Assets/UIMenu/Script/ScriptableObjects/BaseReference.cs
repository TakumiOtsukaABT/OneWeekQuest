using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReference <T> : ScriptableObject where T : BaseItemType
{
    public List<T> elements = new List<T>();
    public T GetElement(int id)
    {
        foreach (var i in elements)
        {
            if (i.id.Equals(id))
            {
                return i;
            }
        }
        return null;
    }
}
