using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTitle : MonoBehaviour
{
    private bool firstPush = false;

    private bool isSubmit = false;          //決定ボタン押下中フラグ

    public void PressStart()
    {
        Debug.Log("Press STart!");
        if(!firstPush)
        {
            Debug.Log("Go Next Scene");
            //★ここに次のシーンへ良く命令を書く
            SceneManager.LoadScene("Stage1");
            //
            firstPush = true;
        }
    }
    void Start()
    {

    }
    void Update()
    {
        float submitKey = Input.GetAxis("Submit");
        float cancelKey = Input.GetAxis("Cancel");

        if (submitKey > 0 && (isSubmit == false))
        {
            //初回入力
            Debug.Log("決定キーを押下しました");
            isSubmit = true;
            PressStart();
        }
        else if (submitKey > 0 && (isSubmit == true))
        {
            //継続入力
            //Debug.Log("決定キーを押下中です");
            isSubmit = true;
        }
        else
        {
            isSubmit = false;
        }
    }
}
