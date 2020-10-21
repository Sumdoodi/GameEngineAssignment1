using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zUp : Command
{
    MyTransform theObj;
    public zUp(MyTransform newObj)
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
