using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [Header("Inspector에서 할당")]
    public ParticleSystem crashEffect; // Inspector에서 직접 할당
    [SerializeField]
    private float reloadDelay = 2f;
    [SerializeField] private AudioClip crashSound; // 충돌 사운드 클립

    private AudioSource audioSource;
    private PlayerController playerController; // PlayerController 스크립트 참조

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {

            audioSource.PlayOneShot(crashSound); // 충돌 사운드 재생
            crashEffect.Play();                     // 이펙트 재생
            playerController.GameOver();
            Debug.Log("오 내머리야");
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}