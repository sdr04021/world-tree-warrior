using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : MonoBehaviour
{
    Rigidbody2D rigid2d;
    bool drag = false;
    Vector2 originPos;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        originPos = rigid2d.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!Input.GetMouseButtonDown(0))&&!drag)
        {
            
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log(gameObject.name);
                hit.transform.localScale = new Vector2(3.0f, 3.0f);
            }
            else transform.localScale = new Vector2(2.0f, 2.0f);
        }
       else transform.localScale = new Vector2(2.0f, 2.0f);
        /*
        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
            if (transform.position.y > -1)
            {
                rigid2d.position = new Vector2(0,-10); //효과적용
            }
            //else rigid2d.position = new Vector2(0, -3.33f);
        }
        */
    }

    void OnMouseDrag()
    {
        drag = true;
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        transform.position = point;
    }

    private void OnMouseUp()
    {
        drag = false;
        if (transform.position.y > -1)
        {
            int damage = 0;
            int num = 0;
            int cost = 0;
            bool isCorrupt = false;

            if (gameObject.name.Contains("red")) // red
            {
                isCorrupt = true;
                damage = GetComponent<Card_red>().do_damage; 
                num = GetComponent<Card_red>().card_num;
                cost = GetComponent<Card_red>().cost;
                if(cost> GameManager.gm.currentCost && !GameManager.gm.cost_zero) // 코스트가 모자란 경우 
                {
                    rigid2d.position = originPos;
                    Debug.Log("코스트 부족");
                    return;
                }

                GameManager.gm.used_corrup.Add(num); // 사용한 카드 목록에 추가 

                if (num == 1)
                {
                    GameManager.gm.buff_list.Add("3턴동안 멸망 게이지 5씩 증가\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 3)
                {
                    damage += 4 * (GameManager.gm.destructionGauge / 10);
                }
                else if (num == 4)
                {
                    GameManager.gm.buff_list.Add("몬스터에게 받는 데미지 50% 증가\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 5)
                {
                    GameManager.gm.buff_list.Add("몬스터에게 받는 데미지 50% 증가\n모든 카드의 코스트 0\n");
                    GameManager.gm.refresh_buff_list();
                    GameManager.gm.currentCost -= 12;
                    GameManager.gm.cost_zero = true;
                    // 모든 코스트 0
                }
                else if (num == 7)
                {
                    GameManager.gm.buff_list.Add("카드의 데미지 50% 증가\n다음 턴 멸망게이지 50% 증가\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 8)
                {
                    GameManager.gm.buff_list.Add("다음 턴 최대 코스트 -5\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 9)
                {
                    GameManager.gm.buff_list.Add("다음 턴 최대 코스트 -3\n");
                    GameManager.gm.refresh_buff_list();
                }
                //GameManager.gm.use_count++; // 사용한 카드 개수 증가 
            }
            else // green
            {
                isCorrupt = false;
                damage = GetComponent<Card_green>().do_damage;
                num = GetComponent<Card_green>().card_num;
                cost = GetComponent<Card_green>().cost;
                if (cost > GameManager.gm.currentCost && !GameManager.gm.cost_zero) // 코스트가 모자란 경우 
                {
                    rigid2d.position = originPos;
                    Debug.Log("코스트 부족");
                    return;
                }
                GameManager.gm.used_resurr.Add(num); // 사용한 카드 목록에 추가 
                //GameManager.gm.use_count++; // 사용한 카드 개수 증가 
                if (num == 1)
                {
                    GameManager.gm.buff_list.Add("다음 턴에 증가하는 멸망 게이지 50% 감소\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 2)
                {
                    GameManager.gm.buff_list.Add("몬스터에게 받는 데미지를 50% 감소\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 3) // resurr 3번 
                {
                    damage -= (GameManager.gm.destructionGauge / 10) * 2;
                    if (damage <= 0) damage = 0;
                    //Debug.Log(damage);
                    GameManager.gm.used_resurr.Remove(3);
                }
                else if (num == 4) // resurr 4번
                {
                    GameManager.gm.used_resurr.Remove(4);
                }
                else if (num == 7)
                {
                    GameManager.gm.buff_list.Add("다음 턴 최대 코스트 +4\n");
                    GameManager.gm.refresh_buff_list();
                }
                else if (num == 9)
                {
                    GameManager.gm.buff_list.Add("다음턴 증가되는 멸망 게이지 전부 0\n");
                    GameManager.gm.resurr9 = true;
                    GameManager.gm.refresh_buff_list();
                }
            }

           if (GameManager.gm.used_corrup.Contains(7))
           {
                // 이번턴 데미지 1.5배
                damage = (int)(damage * 1.5f);
           }

            if (GameManager.gm.debuff1) // 디버프 1
            {
                //GameManager.gm.destructionGauge += 5;
                StartCoroutine(GameManager.gm.IncreaseGauge(5, 0));
                
            }
            else if (GameManager.gm.debuff2) // 디버프 2
            {
                damage /= 2;
            }

            // 몬스터한테 데미지 입히기
            GameObject.FindWithTag("monster").GetComponent<Monster>().Attacked(damage, isCorrupt);


            // 코스트 감소
            if (GameManager.gm.cost_zero) cost = 0;

            GameManager.gm.currentCost -= cost;


            // 게이지 감소 
            if (GameManager.gm.used_resurr.Contains(5)) // resurr 5번
            {
                //GameManager.gm.destructionGauge -= 3;
                StartCoroutine(GameManager.gm.DecreaseGauge(10, 0));
                if (GameManager.gm.destructionGauge < 0) GameManager.gm.destructionGauge = 0;
                GameManager.gm.used_resurr.Remove(5);
            }

            if (GameManager.gm.used_resurr.Contains(7)) // resurr 7번
            {
                //GameManager.gm.destructionGauge -= 4;
                GameManager.gm.resurr7++;
                Debug.Log(GameManager.gm.resurr7);
                if (GameManager.gm.resurr7 == 1)
                {
                    StartCoroutine(GameManager.gm.DecreaseGauge(10, 0));
                    if (GameManager.gm.destructionGauge < 0) GameManager.gm.destructionGauge = 0;
                }
             
            }

            if (GameManager.gm.used_resurr.Contains(8)) // resurr 8번
            {
                //GameManager.gm.destructionGauge -= 5;
                StartCoroutine(GameManager.gm.DecreaseGauge(20, 0));
                if (GameManager.gm.destructionGauge < 0) GameManager.gm.destructionGauge = 0;
                GameManager.gm.used_resurr.Remove(8); 
            }

            Destroy(gameObject); // 사용한 카드 파괴
        }
    }
}
