using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zDownTrans : Command
{
    MyTransform theObj;
    public zDownTrans(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.zDown(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.zUp(obj);
    }
}
