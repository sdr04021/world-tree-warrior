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

    void GameOverClick() // ������ �����ϰ� Ÿ��Ʋ�� ���ư���
    {
        //GameManager ���� �ʱ�ȭ

        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
