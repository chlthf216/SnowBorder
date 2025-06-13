using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("Inspector���� �Ҵ�")]
    public ParticleSystem finalEffect; // Inspector���� ���� �Ҵ�

    private AudioSource audioSource;
    private bool isFinished = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        
    }

    private void Awake()
    {
        //if (finalEffect != null)
            //finalEffect.gameObject.SetActive(false); // ���� �� ��Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            
            isFinished = true; // �Ϸ� ���·� ����
            finalEffect.Play();
            audioSource.Play(); // ����� ���
            Debug.Log("���� �߽��ϴ�");
            Invoke(nameof(ReloadScene), 2f);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}