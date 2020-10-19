using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zDownScale : Command
{
    MyTransform theObj;
    public zDownScale(MyTransform newObj)
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
