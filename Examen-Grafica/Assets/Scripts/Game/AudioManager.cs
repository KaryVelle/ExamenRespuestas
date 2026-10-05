using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinClip;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Coin.OnCollected += PlayCoinSound;
    }

    void OnDisable()
    {
        Coin.OnCollected -= PlayCoinSound;
    }

    private void PlayCoinSound(Coin coin)
    {
        source.PlayOneShot(coinClip);
    }
}