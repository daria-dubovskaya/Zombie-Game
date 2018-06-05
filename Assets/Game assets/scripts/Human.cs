using System.Collections;
using UnityEngine;

public class Human : Unit
{
    public override void GetDamage()
    {
        base.GetDamage();

        gameController.IsGameOver = true;

        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.8f);
        gameController.GameOver();
    }
}
