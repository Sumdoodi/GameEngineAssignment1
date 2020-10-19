using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xDownRot : Command
{
    MyTransform theObj;
    public xDownRot(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.xDown(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.xUp(obj);
    }
}
