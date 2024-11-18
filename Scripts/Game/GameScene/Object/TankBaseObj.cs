using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
   //砲身
    public Transform tankHead;


    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //タンクが潰される時に、プレイするエフェクト
    public GameObject destroyEff;



    public abstract void Fire();
    
    public virtual void Wound(TankBaseObj tank)
    {

        int dmg = tank.atk - def;
        if (dmg <= 0) { return; }
        if (hp - dmg > 0)
        {
            hp -= dmg;
        }
        else
        {
            hp = 0;
            Dead();
        }

    }
    /// <summary>
    ///　Hpが0以下になった場合、対象が死亡
    /// </summary>
    public virtual void Dead()
    {
        //ステージ上にあるオブジェクトをremove
        Destroy(this.gameObject);
        //死亡エフェクトを表示
        if(destroyEff!=null) 
        {
            GameObject effObj  = Instantiate(destroyEff,this.transform.position,this.transform.rotation); 

            //エフェクトに付属するSEを取る
            AudioSource audioScource= effObj.GetComponent<AudioSource>();
            //設定画面による制御
            audioScource.volume = GameDataMgr.Instance.musicData.soundValue;

            audioScource.mute = GameDataMgr.Instance.musicData.isOpenSound;

            audioScource.Play();
        }
    }








}
