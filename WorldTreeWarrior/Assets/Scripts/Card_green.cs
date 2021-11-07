using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_green : MonoBehaviour
{
    public int card_num = 0; // 카드 번호
    public int cost = 0;
    public int do_damage = 0;
    public float reduced_end_gauge_percent = 0; // 다음 턴 멸망 게이지 감소량(퍼센트)
    public float reduced_end_gauge = 0; // 다음 턴 멸망 게이지 감소량
    public int draw_num = 0; // 다음 턴 추가 드로우 수
    public float reduced_damge_percent = 0; // 받는 데미지 감소량(퍼센트)
    public float reduced_damge = 0; // 다음 턴 받는 데미지 감소량
    public int increased_maxCost = 0; // 다음 턴 상승하는 코스트
    public int turn = 0; // 카드 효과가 적용되는 턴 수


    // Start is called before the first frame update
    void Start()
    {

        switch (card_num)
        {
            case 1:
                cost = 7;
                do_damage = 0;
                turn = 1; // 다음 턴에 
                reduced_end_gauge_percent = 0.5f; // 오르는 게이지 50% 감소
                break;
            case 2:
                cost = 6;
                do_damage = 10;
                reduced_damge_percent = 0.3f;
                break;
            case 3:
                cost = 3;
                //do_damage = 23 - int(현재 멸망 게이지/10)*2;
                break;
            case 4:
                cost = 1;
                do_damage = 5;
                break;
            case 5:
                cost = 5;
                do_damage = 25;
                reduced_damge = 3;
                // 멸망 게이지 자체를 -3
                break;
            case 6:
                cost = 7;
                do_damage = 10;
                draw_num = 1; // 다음턴에 한장 더 드로우
                break;
            case 7:
                cost = 4;
                do_damage = 0;
                reduced_end_gauge = 4;
                increased_maxCost = 4;
                break;
            case 8:
                cost = 7;
                do_damage = 0;
                reduced_end_gauge = 20;
                break;
            case 9:
                cost = 15;
                reduced_end_gauge_percent = 1; // 오르는 멸망게이지 100% 감소
                break;
            case 10:
                cost = 3;
                do_damage = 10;
                // 멸망게이지 -= 다음 턴에 사용하는 카드 장수 * 2
                break;

        }

    }

}
