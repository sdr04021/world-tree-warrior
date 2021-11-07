using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_red : MonoBehaviour
{
    public int card_num = 0; // 카드 번호
    public int cost = 0;
    public int do_damage = 0;
    public int increase_Gauge = 0; // 멸망 게이지 증가량
    public int draw_num = 0; // 추가 드로우 수
    public float get_damge_percent = 0; // 받는 데미지 증가량
    public float increased_damage = 0; // 주는 데미지 증가량
    public int reduced_maxCost = 0; // 최대 코스트 감소량
    public int turn = 0; // 카드 효과가 적용되는 턴 수


    // Start is called before the first frame update
    void Start()
    {
        switch (card_num)
        {
            case 1:
                cost = 8;
                do_damage = 40;
                turn = 3;
                //increase_Gauge = 5;
                // 다음 턴부터 3턴동안 멸망게이지 + 5
                break;
            case 2:
                cost = 10;
                do_damage = 60;
                increase_Gauge = 20;
                // 이번 턴 green 카드 한장만 사용 가능
                break;
            case 3:
                cost = 5;
                do_damage = 16;  // +4 * int(현재 멸망게이지 / 10)
                increase_Gauge = 10;
                break;
            case 4:
                cost = 4;
                do_damage = 45;
                get_damge_percent = 0.5f;
                break;
            case 5:
                cost = 12;
                do_damage = 0; ;
                increase_Gauge = 20;
                get_damge_percent = 0.5f;
                // 패의 모든 카드 코스트 0으로
                break;
            case 6:
                cost = 3;
                do_damage = 0;
                increase_Gauge = 2;
                // 1장 버리고 2장 드로우
                break;
            case 7:
                cost = 2;
                do_damage = 0;
                increase_Gauge = 10;
                increased_damage = 0.5f; // 이번턴 데미지 50% 증가 
                turn = 1; // 다음턴에
                // 다음 턴 멸망게이지 50% 추가로 증가 
                break;
            case 8:
                cost = 0;
                do_damage = 66;
                increase_Gauge = 25;
                turn = 1; // 다음턴에 
                reduced_maxCost = 5; // 코스트감소 
                break;
            case 9:
                cost = 10;
                do_damage = 50;
                turn = 1; // 다음턴에 
                reduced_maxCost = 3; // 코스트감소
                break;
            case 10:
                cost = 1;
                increase_Gauge = 250;
                // 모든 카드 효과 두배?
                break;

        }

    }

}
