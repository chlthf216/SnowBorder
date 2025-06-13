using UnityEngine;

// BoostTrail�� �÷��̾ �ν�Ʈ ������ ���� ��ƼŬ ����Ʈ�� ����մϴ�.
public class BoostTrail : MonoBehaviour
{
    // Ahyeon(�÷��̾�)�� �ڽ� ������Ʈ�� �ִ� Boost Effect ��ƼŬ�� Inspector���� �Ҵ��ϼ���.
    [SerializeField] private ParticleSystem boostParticleSystem;

    // PlayerController�� Inspector���� ���� �Ҵ��ϼ���.
    [SerializeField] private PlayerController playerController;

    // �� �����Ӹ��� �ν�Ʈ ���¸� Ȯ���ؼ� ��ƼŬ�� �Ѱų� ���ϴ�.
    private void Update()
    {
        if (playerController != null && boostParticleSystem != null)
        {
            if (playerController.isBoosting)
            {
                // �ν�Ʈ ���̸� ��ƼŬ ���
                if (!boostParticleSystem.isPlaying)
                    boostParticleSystem.Play();
            }
            else
            {
                // �ν�Ʈ�� �ƴϸ� ��ƼŬ ����
                if (boostParticleSystem.isPlaying)
                    boostParticleSystem.Stop();
            }
        }
    }
}
