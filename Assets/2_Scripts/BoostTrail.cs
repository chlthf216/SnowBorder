using UnityEngine;

// BoostTrail은 플레이어가 부스트 상태일 때만 파티클 이펙트를 재생합니다.
public class BoostTrail : MonoBehaviour
{
    // Ahyeon(플레이어)의 자식 오브젝트에 있는 Boost Effect 파티클을 Inspector에서 할당하세요.
    [SerializeField] private ParticleSystem boostParticleSystem;

    // PlayerController를 Inspector에서 직접 할당하세요.
    [SerializeField] private PlayerController playerController;

    // 매 프레임마다 부스트 상태를 확인해서 파티클을 켜거나 끕니다.
    private void Update()
    {
        if (playerController != null && boostParticleSystem != null)
        {
            if (playerController.isBoosting)
            {
                // 부스트 중이면 파티클 재생
                if (!boostParticleSystem.isPlaying)
                    boostParticleSystem.Play();
            }
            else
            {
                // 부스트가 아니면 파티클 정지
                if (boostParticleSystem.isPlaying)
                    boostParticleSystem.Stop();
            }
        }
    }
}
