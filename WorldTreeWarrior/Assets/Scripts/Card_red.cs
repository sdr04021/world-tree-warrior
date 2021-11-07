using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_red : MonoBehaviour
{
    public int card_num = 0; // ī�� ��ȣ
    public int cost = 0;
    public int do_damage = 0;
    public float add_end_gauge = 0; // ��� ������ ������
    public int draw_num = 0; // �߰� ��ο� ��
    public float get_damge_percent = 0; // �޴� ������ ������
    public float increased_damage = 0; // �ִ� ������ ������
    public int reduced_maxcost = 0; // �ִ� �ڽ�Ʈ ���ҷ�
    public int turn = 0; // ī�� ȿ���� ����Ǵ� �� ��
    public GameObject select_button;


    // Start is called before the first frame update
    void Start()
    {
        select_button.SetActive(false);
        switch (card_num)
        {
            case 1:
                cost = 8;
                do_damage = 40;
                turn = 3;
                add_end_gauge = 5;
                // ���� �Ϻ��� 3�ϵ��� ��������� + 5
                break;
            case 2:
                cost = 10;
                do_damage = 60;
                add_end_gauge = 20;
                // �̹� �� green ī�� ���常 ��� ����
                break;
            case 3:
                cost = 5;
                do_damage = 16;  // +4 * int(���� ��������� / 10)
                add_end_gauge = 10;
                break;
            case 4:
                cost = 4;
                do_damage = 45;
                get_damge_percent = 0.5f;
                break;
            case 5:
                cost = 12;
                do_damage = 0; ;
                add_end_gauge = 20;
                get_damge_percent = 0.5f;
                // ���� ��� ī�� �ڽ�Ʈ 0����
                break;
            case 6:
                cost = 3;
                do_damage = 0;
                add_end_gauge = 2;
                // 1�� ������ 2�� ��ο�
                break;
            case 7:
                cost = 2;
                do_damage = 0;
                add_end_gauge = 10;
                increased_damage = 0.5f; // �̹��� ������ 50% ���� 
                turn = 1; // �����Ͽ�
                // ���� �� ��������� 50% �߰��� ���� 
                break;
            case 8:
                cost = 0;
                do_damage = 66;
                add_end_gauge = 25;
                turn = 1; // �����Ͽ� 
                reduced_maxcost = -5; // �ڽ�Ʈ���� 
                break;
            case 9:
                cost = 10;
                do_damage = 50;
                turn = 1; // �����Ͽ� 
                reduced_maxcost = -3; // �ڽ�Ʈ����
                break;
            case 10:
                cost = 1;
                add_end_gauge = 250;
                // ��� ī�� ȿ�� �ι�?
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }



}