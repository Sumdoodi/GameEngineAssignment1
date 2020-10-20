using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yUpScale : Command
{
    MyTransform theObj;
    public yUpScale(MyTransform newObj)
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
