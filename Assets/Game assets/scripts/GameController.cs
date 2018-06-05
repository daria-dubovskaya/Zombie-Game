using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Unit[] units;
    public Vector3 spawnPosition;

    public Text scoreText;
    public Text leveltext;

    private LivesBar livesBar;

    // spawning support
    private float startWait = 0.7f;
    private float spawnWait = 0.6f;
    private float waveWait = 5.0f;
    private int unitCount = 7;

    private int lives;
    private int score;
    private int level = 1;

    private bool gameOver;

    #region Properties

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Lives
    {
        get { return lives; }
    }

    public bool IsGameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    #endregion 

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
    }

    private void Start()
    {
        lives = 3;
        score = 0;
        gameOver = false;

        livesBar.UpdateBar();

        StartCoroutine(SpawnWaves());
    }    

    private void Update()
    {
        UpdateGameInfo();

        if (!gameOver)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        Unit unit = hit.collider.gameObject.GetComponent<Unit>();
                        if (unit)
                        {
                            unit.Audio.Play();
                            unit.GetDamage();
                        }
                    }
                }
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < unitCount; i++)
            {
                Unit unit = units[Random.Range(0, units.Length)];
                Vector3 position = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
                Quaternion unitRotation = Quaternion.identity;
                Instantiate(unit, position, unitRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    private void UpdateGameInfo()
    {
        scoreText.text = "Score: "  + score;
        leveltext.text = "Level: " + level;
    }

    public void RecieveDamage()
    {
        lives--;
        livesBar.UpdateBar();

        if (lives < 1)
            GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }   
}
