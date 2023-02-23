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
        // ��ʼ�������
        pool = new Queue<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        // ����Э��
        StartCoroutine("Spawn");
    }

    // ����Э��, �ӳ�ָ��ʱ�������ɽ��
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
        // ��Ϸ����, ֹͣЭ��
        if (GameControl.instance.isGameOver)
        {
            StopCoroutine("Spawn");
        }    
    }

    // �ṩ����ָ�����󵽶���صķ���
    public void DestoryCoin(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
