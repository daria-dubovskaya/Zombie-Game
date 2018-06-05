using System.Collections;
using UnityEngine;

public class MoveManeuvering : Move
{
    private float screenEdgeX = 2.7f;
    private float bodyRotation = 20.0f;

    private Vector2 maneuverWait = new Vector2(2.5f, 10.0f);

    private void Start()
    {
        StartCoroutine(Maneuver());
    }

    private IEnumerator Maneuver()
    {
        yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));

        velocity.x = -Mathf.Sign(transform.position.x);
        transform.rotation = Quaternion.Euler(0.0f, bodyRotation * velocity.x, 0.0f);
    }

    protected override void FixedUpdate()
    {
        if (unit.IsAlive)
        {
            if (Mathf.Abs(transform.position.x) >= screenEdgeX)
            {
                velocity = Vector3.forward;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            controller.Move(velocity * Time.deltaTime * speed);
        }
    }
}
