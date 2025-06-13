using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("Inspector에서 할당")]
    public ParticleSystem finalEffect; // Inspector에서 직접 할당

    private AudioSource audioSource;
    private bool isFinished = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        
    }

    private void Awake()
    {
        //if (finalEffect != null)
            //finalEffect.gameObject.SetActive(false); // 시작 시 비활성화
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            
            isFinished = true; // 완료 상태로 설정
            finalEffect.Play();
            audioSource.Play(); // 오디오 재생
            Debug.Log("완주 했습니다");
            Invoke(nameof(ReloadScene), 2f);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}