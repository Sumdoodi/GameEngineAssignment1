using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    void execute(GameObject obj);

    void undo(GameObject obj);
}
