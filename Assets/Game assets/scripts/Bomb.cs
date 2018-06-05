using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    private AudioSource audioSource;
    private GameController gameController;
    private Vector3 explosoinPosition;
    private Quaternion explosionRotation;
    private float explosionRadius = 7.0f;
    private int bombInitAmount = 3;
    private int bombAmount;
    private Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        audioSource = GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        explosoinPosition = new Vector3(0, 1, -5);
        explosionRotation = Quaternion.identity;
        bombAmount = bombInitAmount;
        SetBombText();
    }

    private void SetBombText()
    {
        text.text = bombAmount.ToString();
    }

    public void SetBombsAmount()
    {
        bombAmount = bombInitAmount;
        SetBombText();
    }   

    public void UseBomb(GameObject explosion)
    {
        if (bombAmount > 0 && !gameController.IsGameOver)
        {
            audioSource.Play();
            Instantiate(explosion, explosoinPosition, explosionRotation);
            bombAmount--;
            SetBombText();

            Collider[] colliders = Physics.OverlapSphere(explosoinPosition, explosionRadius);

            for (int i = colliders.Length - 1; i >= 0; i--)
            {
                if (colliders[i].gameObject.tag == "Enemy")
                {
                    Unit unit = colliders[i].GetComponent<Unit>();
                    if (unit)
                        unit.GetDamage();
                }                    
            }
        }
    }
}
