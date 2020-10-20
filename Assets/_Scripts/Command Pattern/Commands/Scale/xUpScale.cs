using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xUpScale : Command
{
    MyTransform theObj;
    public xUpScale(MyTransform newObj)
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
