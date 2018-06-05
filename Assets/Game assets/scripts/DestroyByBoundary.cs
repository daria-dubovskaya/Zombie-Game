using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            gameController.RecieveDamage();

        Destroy(other.gameObject);
    }
}
