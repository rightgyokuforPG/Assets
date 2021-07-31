using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フラグクラスの親クラス
/// EnemyFlagやItemFlag、ProgressParamFlagに派生する <-？何いってるか不明w
/// ->今回、子クラスではEnemy、Itemのフラグは一緒にする、変数で種類分けする
/// 
/// イメージ
/// RPGツクールのフラグ管理画面
/// bool型とint型とtext型が分けられている奴
/// 各ステージのEnemy倒したか/倒してないか
/// 各ステージのItem回収したかしてないかを管理する
/// あと、チュートリアルやったかどうかも。
/// 
/// 
/// ☆EnemyとItemで種類分けしないならわざわざ継承させる必要なくない？
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
