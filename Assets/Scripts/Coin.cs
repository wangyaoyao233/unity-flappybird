using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // ����ʱ��, ��������ӻ���������ظ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Column") || collision.CompareTag("Coin"))
        {
            CoinSpawn.instance.DestoryCoin(this.gameObject);
        }
    }
}
