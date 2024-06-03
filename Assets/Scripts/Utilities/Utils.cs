using UnityEngine;

public static class Utils
{
    public static bool IsNull(Object obj)
    {
        return obj != null;
    }

    public static bool IsNullForSound(Sound sound)
    {
        return (sound != null || sound.source != null);
    }
}
