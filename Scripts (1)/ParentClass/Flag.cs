using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フラグクラスの親クラス
/// EnemyFlagやItemFlag、ProgressParamFlagに派生する <-？何いってるか不明w
/// </summary>
[System.Serializable]
public class Flag 
{
    // 列挙型：種類を列挙する
    public enum Type
    {
        _bool,    //bool型のフラグ
        _int,    //int型のフラグ
        _string,  //string型のフラグ

    }

    public Type type;       //種類

    bool _boolFlag;
    int _intFlag;
    string _stringFlag;

    /// <summary>
    /// アイテム生成しない方
    /// </summary>
    public Flag()
    {

    }

    /// <summary>
    /// アイテム生成時必ずTypeを取得する
    /// </summary>
    public Flag(Type type)
    {
        this.type = type;
    }
}


//Flag.csは、ただのクラス設計図
//インスタンス生成時にTypeによって変数の型を変更したい
//※おそらく、データget,set時にどの変数に格納するかをtypeで分ければ行けるはず