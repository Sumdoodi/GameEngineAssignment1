using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    Command theCommand;

    public CommandInvoker(Command newCommand)
    {
        theCommand = newCommand;
    }

    public void use(GameObject obj)
    {
        theCommand.execute(obj);
    }

    public void undo(GameObject obj)
    {
        theCommand.undo(obj);
    }
}
