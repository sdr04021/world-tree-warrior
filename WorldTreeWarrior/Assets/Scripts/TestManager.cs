using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    Animator resurAtackEffect;
    Animator curAttackEffect;
    Animator enemyMagicEffect;
    Animator attackedEffect;

    GameObject monster;

    Vector2 mobPos;
    bool tremble = false;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        resurAtackEffect = GameObject.Find("resur_attack_effect").GetComponent<Animator>();
        curAttackEffect = GameObject.Find("cur_attack_effect").GetComponent<Animator>();
        enemyMagicEffect = GameObject.Find("enemy_magic_effect").GetComponent<Animator>();
        attackedEffect = GameObject.Find("AttackedEffect").GetComponent<Animator>();
        monster = GameObject.Find("Enemy5");
        mobPos = monster.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            monsterAttacked();
        }
        if (Input.GetMouseButtonDown(1))
        {
            monsterAttacks();
        }

        if (tremble)
        {
            monster.transform.position = mobPos + (Random.insideUnitCircle * 0.1f);
        }
    }

    void monsterAttacked()
    {
        resurAtackEffect.SetTrigger("Trigger");
        //curAttackEffect.SetTrigger("Trigger");
        StartCoroutine(monsterAttackedEffect());
        StartCoroutine(DecreaseHP(20));
    }

    IEnumerator monsterAttackedEffect()
    {
        yield return new WaitForSeconds(0.75f);
        tremble = true;
        yield return new WaitForSeconds(0.5f);
        tremble = false;
        monster.transform.position = mobPos;
    }

    IEnumerator DecreaseHP(int amount)
    {
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.02f);
            //monster.GetComponent<Monster>().curHP--;
        }
    }

    void monsterAttacks()
    {
        enemyMagicEffect.SetTrigger("Trigger");
        StartCoroutine(monsterAttacksEffect());
        StartCoroutine(IncreaseGauge(20));
    }
    IEnumerator monsterAttacksEffect()
    {
        yield return new WaitForSeconds(1.0f);
        attackedEffect.SetTrigger("Trigger");
    }
    IEnumerator IncreaseGauge(int amount)
    {
        yield return new WaitForSeconds(1.6f);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.02f);
            GameManager.gm.destructionGauge++;
        }
    }
}
