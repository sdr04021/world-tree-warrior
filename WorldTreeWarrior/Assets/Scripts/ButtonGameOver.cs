using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameOverClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOverClick() // 게임을 종료하고 타이틀로 돌아간다
    {
        //GameManager 변수 초기화

        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
