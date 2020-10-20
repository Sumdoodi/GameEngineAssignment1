using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xUpTrans : Command
{
    MyTransform theObj;
    public xUpTrans(MyTransform newObj)
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
