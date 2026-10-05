using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action<Coin> OnCollected;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        OnCollected?.Invoke(this);
    }
}