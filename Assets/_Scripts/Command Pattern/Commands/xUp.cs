using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xUp : Command
{
    MyTransform theObj;
    public xUp(MyTransform newObj)
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
