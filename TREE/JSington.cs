using UnityEngine;
using System.Collections;

public class JSington<T> where T : class ,new()
{
    private static T ins;
    public static T Ins
    {
        get
        {
            if (ins == null)
            {
                ins = new T();
            }
            return ins;
        }
    }
}
