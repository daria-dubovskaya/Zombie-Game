using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private float lifeTime;
    private ParticleSystem particleSys;

    private void Awake()
    {
        particleSys = GetComponent<ParticleSystem>();
    }

    private void Start ()
    {
        lifeTime = particleSys.main.duration;
        Destroy(gameObject, lifeTime);
	}	
}
