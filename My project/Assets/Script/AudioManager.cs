using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip attackSE;
    public AudioClip hitSE;
    public AudioClip guardSE;
    public AudioClip parrySE;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackSE);
    }

    public void PlayHit()
    {
        audioSource.PlayOneShot(hitSE);
    }

    public void PlayGuard()
    {
        audioSource.PlayOneShot(guardSE);
    }

    public void PlayParry()
    {
        audioSource.PlayOneShot(parrySE);
    }
}
