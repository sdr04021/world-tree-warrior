using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : MonoBehaviour
{
    Rigidbody2D rigid2d;
    bool drag = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
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
                transform.localScale = new Vector2(4.0f, 4.0f);
            }
            else transform.localScale = new Vector2(2.0f, 2.0f);
        }
       else transform.localScale = new Vector2(2.0f, 2.0f);

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
            if (transform.position.y > -1)
            {
                rigid2d.position = new Vector2(0,-10); //효과적용
            }
            else rigid2d.position = new Vector2(0, -3.33f);
        }
    }

    void OnMouseDrag()
    {
        drag = true;
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        transform.position = point;
    }
}
