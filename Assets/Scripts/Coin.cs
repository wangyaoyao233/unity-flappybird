using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // 生成时候, 避免和柱子或其他金币重复
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Column") || collision.CompareTag("Coin"))
        {
            CoinSpawn.instance.DestoryCoin(this.gameObject);
        }
    }
}
