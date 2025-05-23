using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    private GameObject crashEffectObj;
    private ParticleSystem crashEffect;

    private void Awake()
    {
        // 자식에서 "CrashEffect" 오브젝트와 ParticleSystem 찾기
        crashEffectObj = transform.Find("CrashEffect")?.gameObject;
        if (crashEffectObj != null)
        {
            crashEffect = crashEffectObj.GetComponent<ParticleSystem>();
            crashEffectObj.SetActive(false); // 시작 시 비활성화
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
                crashEffectObj.SetActive(true); // 오브젝트 활성화
                crashEffect.Play();             // 이펙트 재생
            }

            Debug.Log("오 내머리야");
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}