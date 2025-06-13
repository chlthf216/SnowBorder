using UnityEngine;
using UnityEngine.Audio;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustParticleSystem; // Reference to the particle system for dust
    [SerializeField] private AudioClip snowSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(snowSound); // Play sound effect on collision with ground
            dustParticleSystem.Play();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            
                dustParticleSystem.Stop();
            
        }
    }
}
