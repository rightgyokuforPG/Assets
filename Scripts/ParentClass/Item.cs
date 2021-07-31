using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムクラスの親クラス
/// Itemsクラスに派生する
/// </summary>
[System.Serializable]
public class Item
{
    // 列挙型：種類を列挙する
    public enum Type
    {
        MaxHPUP,    //最大HPの上限を上昇させるアイテム
        HealHP,    //HPを回復させるアイテム
        ATKUP,  //ATKを増加させるアイテム
        DEFUP,   //DEFを増加させるアイテム
        MONEYUP,    //MONEYを増加させるアイテム
        Other,      //その他 鍵や帰還アイテム、重要アイテムなど
    }

    public Type type;       //アイテムの種類
    public Sprite sprite;   //Slotに表示する画像

    [SerializeField]
    int ItemID;             //アイテム図鑑と連携させる為のID
    [SerializeField]
    float Value;            //効果値 HPだったら50回復するとか。

    /// <summary>
    /// アイテム生成しない方
    /// </summary>
    public Item()
    {

    }

    /// <summary>
    /// アイテム生成時必ずTypeとspriteを取得する
    /// </summary>
    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }

    //★いずれ、各変数のGetter,Setter作る

}