using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int destructionGauge = 0;
    public int maxDestructionGauge = 100;
    public int maxCost = 20;
    public int currentCost = 20;
    public int draw_num = 4;
    int total_increase_gauge = 0;

    List<int> resurrectionDeck = new List<int>();
    int resurrectionUsed;
    List<int> corruptionDeck = new List<int>();
    int corruptionUsed;

    List<int> myResurrection = new List<int>();
    List<int> myCorruption = new List<int>();

    public List<GameObject> corruptionDeck_object = new List<GameObject>();
    public List<GameObject> resurrectionDeck_object = new List<GameObject>();

    GameObject card1;
    GameObject card2;
    GameObject card3;
    GameObject card4;
    GameObject card5;
    GameObject card6;

    public List<int> used_corrup = new List<int>();
    public List<int> used_resurr = new List<int>();

    int turn_check_1 = 0;
    public bool cost_zero = false;
    //public int turn_check_10 = 0;
    public int used_count = 0;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;
    int stage = 1;

    public bool debuff1 = false;
    public bool debuff2 = false;
    public bool debuff3 = false;

    public List<string> buff_list = new List<string>();
    public TextMeshProUGUI buff_text;

    public Animator resurAtackEffect;
    public Animator curAttackEffect;
    public Animator enemyMagicEffect;
    public Animator attackedEffect;

    private void Awake()
    {
        gm = this;
        resurAtackEffect = GameObject.Find("resur_attack_effect").GetComponent<Animator>();
        curAttackEffect = GameObject.Find("cur_attack_effect").GetComponent<Animator>();
        enemyMagicEffect = GameObject.Find("enemy_magic_effect").GetComponent<Animator>();
        attackedEffect = GameObject.Find("AttackedEffect").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDeckLIst(resurrectionDeck, ref resurrectionUsed);
        InitializeDeckLIst(corruptionDeck, ref corruptionUsed);

        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);

        card1 = Instantiate(resurrectionDeck_object[myResurrection[0]], new Vector2(-4, -3),Quaternion.identity);
        card2 = Instantiate(resurrectionDeck_object[myResurrection[1]], new Vector2(-1.5f, -3), Quaternion.identity);
        card3 = Instantiate(corruptionDeck_object[myCorruption[0]], new Vector2(1.5f, -3), Quaternion.identity);
        card4 = Instantiate(corruptionDeck_object[myCorruption[1]], new Vector2(4, -3), Quaternion.identity);
    }

    void InitializeDeckLIst(List<int> deck, ref int used)
    {
        deck.Clear();
        for (int i = 0; i < 10; i++)
            deck.Add(i);
        used = 0;
    }

    void PickCard(List<int> deck, List<int> myCards, ref int used)
    {
        int pick = Random.Range(0, 10 - used);
        myCards.Add(deck[pick]);
        deck[pick] = deck[9 - used];
        used++;
    }

    public void turn_end()
    {
        // 플레이어 턴 종료 
        // 쓰지 않은 카드들 파괴
        Destroy(card1);
        Destroy(card2);
        Destroy(card3);
        Destroy(card4);
        debuff1 = false;
        debuff2 = false;
        cost_zero = false;
        buff_list.Remove("플레이어가 공격할 때마다 멸망 게이지+5\n");
        buff_list.Remove("플레이어가 주는 데미지 50% 감소\n");
        buff_list.Remove("카드 드로우 수 1 감소\n");
        refresh_buff_list();

        // 몬스터 공격

        GameObject.FindWithTag("monster").GetComponent<Monster>().Attack();

        // 몬스터 턴 종료

        // 플레이어 턴 시작
        //turn_start(); 
        StartCoroutine(PlayerTurnStartAfterDelay());

    }

    void cost_change()
    {
        // 코스트 회복
        maxCost = 20;

        // 최대 코스트 조정
        if (used_corrup.Contains(8)) // corrup 8번
        {
            maxCost -= 5;
        }

        if (used_corrup.Contains(9)) // corrup 9번
        {
            maxCost -= 3;
            used_corrup.Remove(9);
            buff_list.Remove("다음 턴 최대 코스트 -3\n");
            refresh_buff_list();
        }

        if (used_resurr.Contains(7)) // resurr 7번
        {
            maxCost += 4;
            used_resurr.Remove(7);
            buff_list.Remove("다음 턴 최대 코스트 +4\n");
            refresh_buff_list();
        }

        currentCost = maxCost;
    }

    void gauge_change()
    {
        total_increase_gauge = 0;

        // 게이지 증가 
        if (used_corrup.Contains(1))
        {
            total_increase_gauge += 5;
            turn_check_1++;
            if (turn_check_1 == 3)
            {
                used_corrup.Remove(1);
                buff_list.Remove("3턴동안 멸망 게이지 5씩 증가\n");
                refresh_buff_list();
                turn_check_1 = 0;
            }
        }

        if (used_corrup.Contains(2))
        {
            total_increase_gauge += 20;
            used_corrup.Remove(2);
        }
        if (used_corrup.Contains(3))
        {
            total_increase_gauge += 10;
            used_corrup.Remove(3);
        }
        if (used_corrup.Contains(5))
        {
            total_increase_gauge += 20;
            used_corrup.Remove(5);
            buff_list.Remove("몬스터에게 받는 데미지 50% 증가\n모든 카드의 코스트 0\n");
            refresh_buff_list();

        }
        if (used_corrup.Contains(6))
        {
            total_increase_gauge += 2;
            used_corrup.Remove(6);
        }
        
        if (used_corrup.Contains(8))
        {
            total_increase_gauge += 25;
            used_corrup.Remove(8);
            buff_list.Remove("다음 턴 최대 코스트 -5\n");
            refresh_buff_list();
        }
        if (used_corrup.Contains(10))
        {
            total_increase_gauge += 250;
            used_corrup.Remove(10);
        }
        if (used_corrup.Contains(7))
        {
            total_increase_gauge += 10;
            total_increase_gauge = (int)(total_increase_gauge * 1.5f);
            used_corrup.Remove(7);
            buff_list.Remove("카드의 데미지 50% 증가\n다음 턴 멸망게이지 50% 증가\n");
            refresh_buff_list();
        }

        if (used_resurr.Contains(1)) // 게이지 증가량 반으로 감소 
        {
            total_increase_gauge /= 2;
            used_resurr.Remove(1);
            buff_list.Remove("다음 턴에 증가하는 멸망 게이지 50% 감소\n");
            refresh_buff_list();
        }

        if (used_resurr.Contains(9))
        {
            total_increase_gauge = 0;
            used_resurr.Remove(9);
            buff_list.Remove("다음턴 소모되는 멸망 게이지 전부 0\n");
            refresh_buff_list();
        }

        destructionGauge += total_increase_gauge;
    }

    public void turn_start()
    {
        // 플레이어 턴 시작
        used_count = 0;

        // draw

        InitializeDeckLIst(resurrectionDeck, ref resurrectionUsed);
        InitializeDeckLIst(corruptionDeck, ref corruptionUsed);
        myResurrection.Clear();
        myCorruption.Clear();

        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);

        card1 = Instantiate(resurrectionDeck_object[myResurrection[0]], new Vector2(-4, -3), Quaternion.identity);
        card2 = Instantiate(resurrectionDeck_object[myResurrection[1]], new Vector2(-1.5f, -3), Quaternion.identity);
        card3 = Instantiate(corruptionDeck_object[myCorruption[0]], new Vector2(1.5f, -3), Quaternion.identity);
        card4 = Instantiate(corruptionDeck_object[myCorruption[1]], new Vector2(4, -3), Quaternion.identity);

        if (debuff3) // 카드 한장 덜 뽑게
        {
            int random = Random.Range(0, 4);
            if (random == 0) Destroy(card1);
            else if (random == 1) Destroy(card2);
            else if (random == 2) Destroy(card3);
            else Destroy(card4);
            debuff3 = false;
        }

        cost_change();
        gauge_change();
    }

    public void next_monster()
    {
        used_corrup.Clear();
        used_resurr.Clear();
        StartCoroutine("next_delay");
    }

    IEnumerator next_delay()
    {
        Debug.Log("다음 몬스터");
        stage++;

        yield return new WaitForSeconds(2.0f);

        switch (stage)
        {
            case 2:
                Instantiate(monster2, new Vector2(0, 1.3f), Quaternion.identity);
                break;
            case 3:
                Instantiate(monster3, new Vector2(0, 1.3f), Quaternion.identity);
                break;
            case 4:
                Instantiate(monster4, new Vector2(0, 1.3f), Quaternion.identity);
                break;
            case 5:
                Instantiate(monster5, new Vector2(0, 1.3f), Quaternion.identity);
                break;

        }

        Destroy(card1);
        Destroy(card2);
        Destroy(card3);
        Destroy(card4);
        buff_list.Clear();
        refresh_buff_list();
        turn_start();

    }

    public void refresh_buff_list()
    {
        buff_text.text = "";
        for (int i = 0; i < buff_list.Count; i++)
        {
            buff_text.text += buff_list[i];
        }
        
    }

    public IEnumerator monsterAttacksEffect()
    {
        yield return new WaitForSeconds(1.0f);
        attackedEffect.SetTrigger("Trigger");
    }
    public IEnumerator IncreaseGauge(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.02f);
            if (destructionGauge < 100) destructionGauge++;
        }
    }
    public IEnumerator DecreaseGauge(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.02f);
            if (destructionGauge > 0) destructionGauge--;
        }
    }
    IEnumerator PlayerTurnStartAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        turn_start();
    }
}


