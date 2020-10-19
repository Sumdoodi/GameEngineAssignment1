using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MyTransform
{
    Vector3 selectedObjectVec;

    public void xUp(GameObject obj)
    {
        selectedObjectVec = new Vector3(1.0f, 0.0f, 0.0f);
        obj.transform.localScale += selectedObjectVec;
    }
    public void xDown(GameObject obj)
    {
        selectedObjectVec = new Vector3(-1.0f, 0.0f, 0.0f);
        obj.transform.localScale += selectedObjectVec;
    }

    public void yUp(GameObject obj)
    {
        selectedObjectVec = new Vector3(0.0f, 1.0f, 0.0f);
        obj.transform.localScale += selectedObjectVec;
    }
    public void yDown(GameObject obj)
    {
        selectedObjectVec = new Vector3(0.0f, -1.0f, 0.0f);
        obj.transform.localScale += selectedObjectVec;
    }

    public void zUp(GameObject obj)
    {
        selectedObjectVec = new Vector3(0.0f, 0.0f, 1.0f);
        obj.transform.localScale += selectedObjectVec;
    }
    public void zDown(GameObject obj)
    {
        selectedObjectVec = new Vector3(0.0f, 0.0f, -1.0f);
        obj.transform.localScale += selectedObjectVec;
    }
}
