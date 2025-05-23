using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    private GameObject crashEffectObj;
    private ParticleSystem crashEffect;

    private void Awake()
    {
        // �ڽĿ��� "CrashEffect" ������Ʈ�� ParticleSystem ã��
        crashEffectObj = transform.Find("CrashEffect")?.gameObject;
        if (crashEffectObj != null)
        {
            crashEffect = crashEffectObj.GetComponent<ParticleSystem>();
            crashEffectObj.SetActive(false); // ���� �� ��Ȱ��ȭ
        }
    }

    [SerializeField]
    private float reloadDelay = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            if (crashEffectObj != null && crashEffect != null)
            {
                crashEffectObj.SetActive(true); // ������Ʈ Ȱ��ȭ
                crashEffect.Play();             // ����Ʈ ���
            }

            Debug.Log("�� ���Ӹ���");
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}