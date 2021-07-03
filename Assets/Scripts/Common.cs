using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    public static bool floatEqual(float x1, float x2, float margin)
    {
        return (x1 <= x2 + margin) && (x1 >= x2 - margin);
    }
}
