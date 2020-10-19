using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xUpRot : Command
{
    MyTransform theObj;
    public xUpRot(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.xUp(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.xDown(obj);
    }
}
