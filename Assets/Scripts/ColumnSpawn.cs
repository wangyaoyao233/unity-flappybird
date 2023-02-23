using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawn : MonoBehaviour
{
    public static ColumnSpawn instance;
    public GameObject upperBound; //上边界
    public GameObject lowerBound; //下边界
    public GameObject columnPrefab;
    public int poolSize = 100;
    public float interval = 4f;

    Queue<GameObject> pool;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // 初始化对象池
        pool = new Queue<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(columnPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        InvokeRepeating("Spawn", 0f, interval);
    }

    // 定时生成柱子
    void Spawn()
    {
        if (GameControl.instance.isGameOver) return;
        GameObject obj = pool.Dequeue();
        obj.transform.position = Vector3.Lerp(upperBound.transform.position, lowerBound.transform.position, Random.Range(0f, 1f));
        obj.SetActive(true);
    }

    // 提供回收指定对象到对象池的方法
    public void DestoryColumn(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
