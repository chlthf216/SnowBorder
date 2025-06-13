using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [Header("Inspector���� �Ҵ�")]
    public ParticleSystem crashEffect; // Inspector���� ���� �Ҵ�
    [SerializeField]
    private float reloadDelay = 2f;
    [SerializeField] private AudioClip crashSound; // �浹 ���� Ŭ��

    private AudioSource audioSource;
    private PlayerController playerController; // PlayerController ��ũ��Ʈ ����

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {

            audioSource.PlayOneShot(crashSound); // �浹 ���� ���
            crashEffect.Play();                     // ����Ʈ ���
            playerController.GameOver();
            Debug.Log("�� ���Ӹ���");
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}