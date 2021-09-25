using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePopupTest : MonoBehaviour
{
    #region //インスペクターで設定する
    [Header("自HP")] public int pHP;
    [Header("自ATK")] public int pATK;
    [Header("自DEF")] public int pDEF;

    [Header("敵HP")] public int eHP;
    [Header("敵ATK")] public int eATK;
    [Header("敵DEF")] public int eDEF;
    #endregion

    #region //プライベート変数
    private bool isSubmit = false;          //決定ボタン押下中フラグ
    private bool isCancel = false;          //キャンセルボタン押下中フラグ
    private bool isPunching = false;        //バトル中フラグ
    private cData Player;                   //ステータス格納
    private cData Enemy;

    private GameObject PlayerStatus;
    private GameObject EnemyStatus;
    #endregion

    public class cData
    {
        public int sHP;
        public int sATK;
        public int sDEF;
    }

    // Start is called before the first frame update
    void Start()
    {
        //★ 後でステータスを取得する記述
        Player = new cData() { sHP = this.pHP, sATK = this.pATK, sDEF = this.pDEF};
        Enemy = new cData() { sHP = this.eHP, sATK = this.eATK, sDEF = this.eDEF };

        PlayerStatus = GameObject.Find("PlayerStatus");
        EnemyStatus = GameObject.Find("EnemyStatus");

        UpdateStatus();
    }

    void FixedUpdate()
    {
        if (isPunching == true)
        {
            //ここに入力する
            Punch(Player, Enemy);
            Punch(Enemy, Player);

            if( ( Player.sHP <= 0 ) || ( Enemy.sHP <= 0 ) )
            {
                //バトル終了判定
                isPunching = false;
                Debug.Log("バトル終了");
                UpdateStatus();
            }
            else
            {
                //Debug.Log("ステータス更新");
                UpdateStatus();
            }
        }


        //以下は戦闘中は入力不可にする

        float submitKey = Input.GetAxis("Submit");
        float cancelKey = Input.GetAxis("Cancel");

        if (submitKey > 0 && ( isSubmit == false ) )
        {
            //初回入力
            Debug.Log("決定キーを押下しました");
            isSubmit = true;
            isPunching = true;      //バトル開始

        }
        else if(submitKey > 0 && ( isSubmit ==true ) )
        {
            //継続入力
            //Debug.Log("決定キーを押下中です");
            isSubmit = true;
        }
        else
        {
            isSubmit = false;
        }
        if (cancelKey > 0 && ( isCancel == false ) )
        {
            //初回入力
            Debug.Log("キャンセルキーを押下しました");
            isCancel = true;
        }
        else if (cancelKey > 0 && ( isCancel == true ) )
        {
            //継続入力
            //Debug.Log("キャンセルキーを押下中です");
            isCancel = true;
        }
        else
        {
            isCancel = false;
        }

  
    }

    private void Punch(cData attack, cData defence)
    {
        defence.sHP -= attack.sATK - defence.sDEF;
        //Debug.Log("PlayerHP=" + Player.sHP + " & EnemyHP=" + Enemy.sHP);
    }

    private void UpdateStatus()
    {
        //Debug.Log(PlayerStatus.transform.GetChild(0).GetComponent<Text>().text);

        //Playerステータス更新
        PlayerStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Player.sHP;
        PlayerStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Player.sATK;
        PlayerStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Player.sDEF;

        //Playerステータス更新
        EnemyStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Enemy.sHP;
        EnemyStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Enemy.sATK;
        EnemyStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Enemy.sDEF;
    }
}
