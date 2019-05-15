using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float maxHeight;

    Vector3 MOVEX = new Vector3(4, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 4, 0); // y軸方向に１マス移動するときの距離

    float step = 50f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;   // アニメーション

    //コンポーネントの取得
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        target = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        prevPos = target;
        
       

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();


        // ② 入力に応じて移動後の位置を算出
        void SetTargetPosition()
        {

            prevPos = target;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                target = transform.position + MOVEX;
                SetAnimationParam(1);
                return;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                target = transform.position - MOVEX;
                SetAnimationParam(2);
                return;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                target = transform.position + MOVEY;
                SetAnimationParam(3);
                return;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                target = transform.position - MOVEY;
                SetAnimationParam(0);
                return;
            }
        }

        // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
        void SetAnimationParam(int param)
        {
            animator.SetInteger("WalkParam", param);
        }

        // ③ 目的地へ移動する
        void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
        }

        /*
        int x = -28;
        int y = 0;
        for (int i = 0; i<=225; i++)
        {
            int masu[x][y] = i;
            x += 4
        }
        */
    }
}
