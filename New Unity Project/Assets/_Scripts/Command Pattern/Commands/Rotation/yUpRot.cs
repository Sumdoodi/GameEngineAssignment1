using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yUpRot : Command
{
    MyTransform theObj;
    public yUpRot(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.yUp(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.yDown(obj);
    }
}
