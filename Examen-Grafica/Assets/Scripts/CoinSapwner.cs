using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    [SerializeField] private int initialCoins = 3;

    [Header("Área de juego (coordenadas del mundo)")]
    [SerializeField] private Vector2 minXZ = new Vector2(-10f, -10f);
    [SerializeField] private Vector2 maxXZ = new Vector2(10f, 10f);
    [SerializeField] private float spawnHeight = 1f;

    void OnEnable()
    {
        Coin.OnCollected += HandleCoinCollected;
    }

    void OnDisable()
    {
        Coin.OnCollected -= HandleCoinCollected;
    }

    void Start()
    {
        for (int i = 0; i < initialCoins; i++)
            SpawnCoin();
    }

    private void HandleCoinCollected(Coin coin)
    {
        pool.Return(coin.gameObject);
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        pool.Get(RandomPointInArea());
    }

    private Vector3 RandomPointInArea()
    {
        return new Vector3(
            Random.Range(minXZ.x, maxXZ.x),
            spawnHeight,
            Random.Range(minXZ.y, maxXZ.y));
    }

    // Dibuja el área en la Scene view al seleccionar el objeto
    void OnDrawGizmosSelected()
    {
        Vector3 center = new Vector3((minXZ.x + maxXZ.x) / 2f, spawnHeight, (minXZ.y + maxXZ.y) / 2f);
        Vector3 size = new Vector3(maxXZ.x - minXZ.x, 0.1f, maxXZ.y - minXZ.y);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
}