using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scripts that should be applied to all scripts that can recieve a signal
/// </summary>
public interface IReciever
{
    /// <summary>
    /// Signal stuff. Im sorry i really am not up to writing comments at this time 4/17/23 12:10 AM. You can yell at that version of me later
    /// </summary>
    /// <param name="target"></param>
    void GetSignal(GameObject target) { }
    void GetSignal(Vector2 target) { }
}
