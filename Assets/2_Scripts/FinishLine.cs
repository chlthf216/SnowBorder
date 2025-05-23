using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private GameObject finalEffectObj;
    private ParticleSystem finalEffect;

    private void Awake()
    {
        // 자식에서 "FinalEffect" 오브젝트와 ParticleSystem 찾기
        finalEffectObj = transform.Find("FinalEffect")?.gameObject;
        if (finalEffectObj != null)
        {
            finalEffect = finalEffectObj.GetComponent<ParticleSystem>();
            finalEffectObj.SetActive(false); // 시작 시 비활성화
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (finalEffectObj != null && finalEffect != null)
            {
                finalEffectObj.SetActive(true); // 오브젝트 활성화
                finalEffect.Play();             // 이펙트 재생
            }

            Debug.Log("완주 했습니다");
            Invoke(nameof(ReloadScene), 2f);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}