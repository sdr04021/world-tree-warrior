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
    bool tremble = false;
    Vector2 mobPos;

    // Start is called before the first frame update
    void Start()
    {
        mobPos = transform.position;
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

        if (tremble)
        {
            transform.position = mobPos + (Random.insideUnitCircle * 0.1f);
        }
    }

    public void Attacked(int damage, bool isCorrupt)
    {
        if(isCorrupt) GameManager.gm.curAttackEffect.SetTrigger("Trigger");
        else GameManager.gm.resurAtackEffect.SetTrigger("Trigger");
        //curHP -= damage;
        StartCoroutine(monsterAttackedEffect());
        StartCoroutine(DecreaseHP(damage));
    }

    public void Attack()
    {
        Debug.Log("���� ��");
        damage = initial_damage;
        if (GameManager.gm.used_corrup.Contains(4)) // corrup 4��
        {
            damage = (int)(damage * 1.5f);
            GameManager.gm.used_corrup.Remove(4);
            GameManager.gm.buff_list.Remove("���Ϳ��� �޴� ������ 50% ����\n");
            GameManager.gm.refresh_buff_list();
        }

        if (GameManager.gm.used_corrup.Contains(5)) // corrup 5��
        {
            damage = (int)(damage * 1.5f);
            //GameManager.gm.used_corrup.Remove(5);
        }

        if (GameManager.gm.used_resurr.Contains(2)) // resurr 2��
        {
            damage = (int)(damage * 0.5f);
            GameManager.gm.used_resurr.Remove(2);
            GameManager.gm.buff_list.Remove("���Ϳ��� �޴� �������� 50% ����\n");
            GameManager.gm.refresh_buff_list();
        }
        if (GameManager.gm.resurr9) damage = 0;
        Attack_pattern();

        //GameManager.gm.destructionGauge += damage;
        
    }

    public void Attack_pattern()
    {
        int random = Random.Range(1, 5); // 1~4�� ����
        GameManager.gm.enemyMagicEffect.SetTrigger("Trigger");
        switch (random)
        {
            case 1:
                StartCoroutine(GameManager.gm.monsterAttacksEffect());
                //GameManager.gm.destructionGauge += damage;
                StartCoroutine(GameManager.gm.IncreaseGauge(damage, 2.0f));
                Debug.Log("������: " + damage);
                break;
            case 2:
                GameManager.gm.debuff1 = true;
                GameManager.gm.buff_list.Add("�÷��̾ ������ ������ ��� ������+5\n");
                GameManager.gm.refresh_buff_list();
                Debug.Log("�����1");
                break;
            case 3:
                GameManager.gm.debuff2 = true;
                GameManager.gm.buff_list.Add("�÷��̾ �ִ� ������ 50% ����\n");
                GameManager.gm.refresh_buff_list();
                Debug.Log("�����2");
                break;
            case 4:
                StartCoroutine(GameManager.gm.monsterAttacksEffect());
                StartCoroutine(GameManager.gm.IncreaseGauge((int)(damage*1.2f), 2.0f));
                //GameManager.gm.destructionGauge += (damage+10);
                GameManager.gm.debuff3 = true;
                GameManager.gm.buff_list.Add("ī�� ��ο� �� 1 ����\n");
                GameManager.gm.refresh_buff_list();
                Debug.Log("������: " + (damage + 10));
                Debug.Log("�����3");
                break;
        }
    }

    IEnumerator monsterAttackedEffect()
    {
        yield return new WaitForSeconds(0.75f);
        tremble = true;
        yield return new WaitForSeconds(0.5f);
        tremble = false;
        transform.position = mobPos;
    }

    IEnumerator DecreaseHP(int amount)
    {
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.02f);
            curHP--;
        }
    }
}
