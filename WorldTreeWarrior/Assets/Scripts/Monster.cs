using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    Image hpBar;
    TextMeshProUGUI hpText;
    public int maxHP;
    public int curHP;
    public int damage;
    public int initial_damage;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = transform.GetChild(0).transform.Find("HP_Current").GetComponent<Image>();
        hpText = transform.GetChild(0).transform.Find("HP_Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = (float)curHP / maxHP;
        hpText.SetText(curHP.ToString() + "/" + maxHP.ToString());

        if (curHP <= 0)
        {
            GameManager.gm.next_monster();
            Destroy(gameObject);
        }
    }

    public void Attacked(int damage)
    {
        curHP -= damage;
    }

    public void Attack()
    {
        Debug.Log("몬스터 턴");
        damage = initial_damage;
        if (GameManager.gm.used_corrup.Contains(4)) // corrup 4번
        {
            damage = (int)(damage * 1.5f);
            GameManager.gm.used_corrup.Remove(4);
            GameManager.gm.buff_list.Remove("몬스터에게 받는 데미지 50% 증가\n");
            GameManager.gm.refresh_buff_list();
        }

        if (GameManager.gm.used_corrup.Contains(5)) // corrup 5번
        {
            damage = (int)(damage * 1.5f);
            //GameManager.gm.used_corrup.Remove(5);
        }

        if (GameManager.gm.used_resurr.Contains(2)) // resurr 5번
        {
            damage = (int)(damage * 0.7f);
            GameManager.gm.used_resurr.Remove(2);
            GameManager.gm.buff_list.Remove("몬스터에게 받는 데미지를 30% 감소\n");
            GameManager.gm.refresh_buff_list();
        }
        Attack_pattern();

        //GameManager.gm.destructionGauge += damage;
        
    }

    public void Attack_pattern()
    {
        int random = Random.Range(1, 5); // 1~4중 랜덤
        switch (random)
        {
            case 1:
                GameManager.gm.destructionGauge += damage;
                Debug.Log("데미지: " + damage);
                break;
            case 2:
                GameManager.gm.debuff1 = true;
                Debug.Log("디버프1");
                break;
            case 3:
                GameManager.gm.debuff2 = true;
                Debug.Log("디버프2");
                break;
            case 4:
                GameManager.gm.destructionGauge += (damage+10);
                GameManager.gm.debuff3 = true;
                Debug.Log("데미지: " + (damage + 10));
                Debug.Log("디버프3");
                break;
        }
    }

    
}
