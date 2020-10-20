using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xDownScale : Command
{
    MyTransform theObj;
    public xDownScale(MyTransform newObj)
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
