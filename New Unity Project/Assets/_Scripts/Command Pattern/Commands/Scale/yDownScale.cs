using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yDownScale : Command
{
    MyTransform theObj;
    public yDownScale(MyTransform newObj)
    {
        theObj = newObj;
    }

    public void execute(GameObject obj)
    {
        theObj.yDown(obj);
    }

    public void undo(GameObject obj)
    {
        theObj.yUp(obj);
    }
}
