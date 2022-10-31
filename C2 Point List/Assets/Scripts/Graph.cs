using UnityEngine;
using static System.MathF;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPreFab;
    [SerializeField] private Transform parent;

    [SerializeField, Range(10, 100)] private int resolution = 10;
    [SerializeField, Range(2, 10)] private int size = 2;
    private int resolutionOld, sizeOld;

    private Transform[] pointPool;

    private void Awake()
    {
        resolutionOld = resolution;
        sizeOld = size;

        pointPool = new Transform[resolution];
        float step = 1f * size / resolution;

        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPreFab);
            Vector3 position = Vector3.zero;
            position.x = step * (i + 0.5f) - size / 2f;
            position.y = Sin(position.x);
            point.localPosition = position;
            point.localScale = Vector3.one * step;
            point.SetParent(parent, false);
            pointPool[i] = point;
        }
    }

    void Clean()
    {
        for (int i = 0; i < pointPool.Length ; i++)
        {
            Destroy(pointPool[i].gameObject);
        }
    }

    void Update()
    {
        if ((resolutionOld != resolution) | (sizeOld != size))
        {
            Clean();
            Awake();
        }
        
        for (int i = 0; i < pointPool.Length; i++)
        {
            Vector3 position = pointPool[i].localPosition; 
            float x = position.x;
            float y = Sin(x + Time.time);
            position.x = x;
            position.y = y;
            pointPool[i].localPosition = position;
        }
    }
}