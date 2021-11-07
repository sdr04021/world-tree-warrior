using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_green : MonoBehaviour
{
    public int card_num = 0; // ī�� ��ȣ
    public int cost = 0;
    public int do_damage = 0;
    public float reduced_end_gauge_percent = 0; // ���� �� ��� ������ ���ҷ�(�ۼ�Ʈ)
    public float reduced_end_gauge = 0; // ���� �� ��� ������ ���ҷ�
    public int draw_num = 0; // ���� �� �߰� ��ο� ��
    public float reduced_damge_percent = 0; // �޴� ������ ���ҷ�(�ۼ�Ʈ)
    public float reduced_damge = 0; // ���� �� �޴� ������ ���ҷ�
    public int increased_maxCost = 0; // ���� �� ����ϴ� �ڽ�Ʈ
    public int turn = 0; // ī�� ȿ���� ����Ǵ� �� ��


    // Start is called before the first frame update
    void Start()
    {

        switch (card_num)
        {
            case 1:
                cost = 7;
                do_damage = 0;
                turn = 1; // ���� �Ͽ� 
                reduced_end_gauge_percent = 0.5f; // ������ ������ 50% ����
                break;
            case 2:
                cost = 6;
                do_damage = 10;
                reduced_damge_percent = 0.3f;
                break;
            case 3:
                cost = 3;
                //do_damage = 23 - int(���� ��� ������/10)*2;
                break;
            case 4:
                cost = 1;
                do_damage = 5;
                break;
            case 5:
                cost = 5;
                do_damage = 25;
                reduced_damge = 3;
                // ��� ������ ��ü�� -3
                break;
            case 6:
                cost = 7;
                do_damage = 10;
                draw_num = 1; // �����Ͽ� ���� �� ��ο�
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
                reduced_end_gauge_percent = 1; // ������ ��������� 100% ����
                break;
            case 10:
                cost = 3;
                do_damage = 10;
                // ��������� -= ���� �Ͽ� ����ϴ� ī�� ��� * 2
                break;

        }

    }

}
