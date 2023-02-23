using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool isGameOver = false;
    public GameObject gameOverText;
    public GameObject hintText;
    public GameObject scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // ��Ϸ������, ����ؿ���Ϸ
        if (isGameOver && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // ��Ϸ�������UI����
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        hintText.SetActive(true);
    }

    // ��ӷ�������ʾ��UI����
    public void addScore(int score)
    {
        this.score += score;
        scoreText.GetComponent<Text>().text = String.Format("score: {0}", this.score);
    }
}
