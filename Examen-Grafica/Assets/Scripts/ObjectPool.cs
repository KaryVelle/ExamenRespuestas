using System.Collections.Generic;
using UnityEngine;

// Pooling System entregado. No modificar.
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 5;

    private readonly Queue<GameObject> available = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < initialSize; i++)
            CreateInstance();
    }

    private GameObject CreateInstance()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        available.Enqueue(obj);
        return obj;
    }

    public GameObject Get(Vector3 position)
    {
        if (available.Count == 0)
            CreateInstance();

        GameObject obj = available.Dequeue();
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj)
    {
        if (!obj.activeSelf) return;
        obj.SetActive(false);
        available.Enqueue(obj);
    }
}