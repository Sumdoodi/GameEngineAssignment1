using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zUpScale : Command
{
    MyTransform theObj;
    public zUpScale(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.zUp(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.zDown(obj);
    }
}
