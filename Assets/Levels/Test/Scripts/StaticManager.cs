using UnityEngine;

public static class StaticManager
{
    public static GameObject Switcher;

    public static GameObject Switcher1
    {
        get
        {
            return Switcher;
        }
        set
        {
            Switcher = GameObject.Find("Switch1");
        }
    }
}