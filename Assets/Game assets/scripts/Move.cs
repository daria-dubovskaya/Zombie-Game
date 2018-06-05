using UnityEngine;

public class Move : MonoBehaviour
{
    protected Unit unit;
    protected float speed = 2.0f;
    protected Vector3 velocity;
    protected CharacterController controller;


    private void Awake()
    {
        unit = GetComponent<Unit>();
        velocity = Vector3.forward;
        controller = GetComponent<CharacterController>();
    }

    protected virtual void FixedUpdate()
    {
        if(unit.IsAlive)
            controller.Move(velocity * Time.deltaTime * speed);
    }
}
