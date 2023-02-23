using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public static CoinSpawn instance;
    public GameObject upperBound;
    public GameObject lowerBound;
    public GameObject rightBound;
    public GameObject coinPrefab;
    public int poolSize = 50;

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
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        // 开启协程
        StartCoroutine("Spawn");
    }

    // 利用协程, 延迟指定时间来生成金币
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject obj = pool.Dequeue();
            Vector3 ul = Vector3.Lerp(upperBound.transform.position, lowerBound.transform.position, Random.Range(0f, 1f));
            Vector3 ur = Vector3.Lerp(upperBound.transform.position, rightBound.transform.position, Random.Range(0f, 1f));
            obj.transform.position = Vector3.Lerp(ul, ur, Random.Range(0f, 1f));
            obj.SetActive(true);

            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    void Update()
    {
        // 游戏结束, 停止协程
        if (GameControl.instance.isGameOver)
        {
            StopCoroutine("Spawn");
        }    
    }

    // 提供回收指定对象到对象池的方法
    public void DestoryCoin(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
