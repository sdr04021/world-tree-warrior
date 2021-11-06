using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    Image hpBar;
    TextMeshProUGUI hpText;
    int maxHP;
    int curHP;
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = transform.GetChild(0).transform.Find("HP_Current").GetComponent<Image>();
        hpText = transform.GetChild(0).transform.Find("HP_Text").GetComponent<TextMeshProUGUI>();
        maxHP = 100;
        curHP = 100;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = (float)curHP / maxHP;
        hpText.SetText(curHP.ToString() + "/" + maxHP.ToString());
    }
}
