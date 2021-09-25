using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    #endregion
    //プライベート変数
    private Animator anim = null;       //アニメーション制御時に必要
    private Rigidbody2D rb = null;
    private string enemyTag = "Enemy";
    private string itemTag = "Item";    //アイテムと接触した時にアイテムを回収する用

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //キー入力されたら行動する
        float verticalKey = Input.GetAxis("Vertical");
        float xSpeed = GetXSpeed();
        float ySpeed = 0.0f;

        //移動
        if (verticalKey > 0)
        {
            ySpeed = speed;
        }
        else if (verticalKey < 0)
        {
            ySpeed = -speed;
        }
        else
        {
            ySpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    /// <summary> 
    /// X成分で必要な計算をし、速度を返す。 
    /// </summary> 
    /// <returns>X軸の速さ</returns> 
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);    //画像の向き
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);   //画像の向き反転
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
        }
        return xSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == itemTag)
        {
            Debug.Log("アイテムと接触した！");
            //ここで、SaveDataに

            //★アイテムが消えるという動作はアイテム自身にやってもらう
            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();

            if(o != null)
            {
                //★臨時
                //saveDataに直接記入する
                GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP += 100;

                //アイテム削除指示
                o.playerTouchOn = true;

                //
                GameObject.FindWithTag("GameManager").GetComponent<SceneStage1>().Reload();
            }
            else
            {
                Debug.Log("アイテムに触れてるけど、ObjectCollisionが存在しない");
            }
        }
    }
}
