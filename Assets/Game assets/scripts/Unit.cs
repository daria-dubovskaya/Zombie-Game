using UnityEngine;

public class Unit : MonoBehaviour
{
    private Animation anim;
    private bool alive = true;
    private CharacterController controller;
    private AudioSource audioSourse;
    protected GameController gameController;

    public GameObject smashingAnimation;

    public bool IsAlive
    {
        get { return alive; }
    }

    public AudioSource Audio
    {
        get { return audioSourse; }
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
        gameController = FindObjectOfType<GameController>();
        audioSourse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (alive)
            anim.Play("run", PlayMode.StopAll);
        else
            anim.Play("die", PlayMode.StopAll);            
    }

    private void OnMouseDown()
    {
        if (!gameController.IsGameOver)
        {
            audioSourse.Play();
            GetDamage();
        }
    }

    public virtual void GetDamage()
    {
        Vector3 smashingPosition = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);

        if (smashingAnimation != null && alive)
        {
            Instantiate(smashingAnimation, smashingPosition, transform.rotation);
        }

        controller.enabled = false;
        alive = false;
        Destroy(gameObject, 3.0f);
    }    
}
