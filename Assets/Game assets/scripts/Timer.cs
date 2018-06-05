using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image image;

    private float levelTime = 60.0f;
    private float leftTime;
    private Text text;
    private GameController gameController;
    private Bomb bomb;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        bomb = FindObjectOfType<Bomb>();
        gameController = FindObjectOfType<GameController>();    
    }

    private void Start()
    {
        leftTime = levelTime;
        TimeToString();
    }

    private void Update()
    {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            image.fillAmount = leftTime / levelTime;
            TimeToString();
        }
        else
        {
            leftTime = levelTime;
            gameController.Level++;
            bomb.SetBombsAmount();
        }
    }

    private void TimeToString()
    {
        string minutes = ((int)leftTime / 60).ToString();
        string seconds = (leftTime % 60).ToString("f0");

        text.text = minutes + ":" + seconds;
    }
}
