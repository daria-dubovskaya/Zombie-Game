using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3];
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();

        for (int i = 0; i < hearts.Length; i++)
            hearts[i] = transform.GetChild(i);
    }

    public void UpdateBar()
    {
        for (int i = hearts.Length - 1; i>= 0; i--)
        {
            if (gameController.Lives - 1 < i)
                hearts[i].gameObject.SetActive(false);
            else hearts[i].gameObject.SetActive(true);
        }
    }
}
