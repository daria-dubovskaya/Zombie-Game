using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    public int scoreValue;

    public override void GetDamage()
    {
        base.GetDamage();

        gameController.Score += scoreValue;
    }
}
