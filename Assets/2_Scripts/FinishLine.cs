using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private GameObject finalEffectObj;
    private ParticleSystem finalEffect;

    private void Awake()
    {
        // �ڽĿ��� "FinalEffect" ������Ʈ�� ParticleSystem ã��
        finalEffectObj = transform.Find("FinalEffect")?.gameObject;
        if (finalEffectObj != null)
        {
            finalEffect = finalEffectObj.GetComponent<ParticleSystem>();
            finalEffectObj.SetActive(false); // ���� �� ��Ȱ��ȭ
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (finalEffectObj != null && finalEffect != null)
            {
                finalEffectObj.SetActive(true); // ������Ʈ Ȱ��ȭ
                finalEffect.Play();             // ����Ʈ ���
            }

            Debug.Log("���� �߽��ϴ�");
            Invoke(nameof(ReloadScene), 2f);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}