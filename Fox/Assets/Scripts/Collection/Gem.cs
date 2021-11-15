using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Collections
{
    protected override void Start()
    {
        base.Start();
    }
    public override int CountPlus()
    {
        return Score;
    }

    public override void Death()
    {
        base.Death();
    }
}
