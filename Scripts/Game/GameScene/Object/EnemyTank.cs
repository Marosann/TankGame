using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBaseObj
{


    
    //今向かっている目標地点
    private Transform targetPos;
    //ランダムで使う目標地点
    public Transform[] randomPos;


    public Transform lookAtTarget;

    public Transform[] shootPos;
    public GameObject bullets;

    public Texture maxHP;
    public Texture nowHP;

    private Rect maxHPRect;
    private Rect nowHPRect;
    //HPゲージの表示時間
    private float showTime;
   
    //発砲範囲
    public float fireDis = 5;

    public float offsetTime = 1;

    private float nowTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 2箇所の間に行き来する処理
        //目標地点にフォーカス
        this.transform.LookAt(targetPos);
        //目標地点に向かう
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(this.transform.position,targetPos.position) < 0.05f)
        {
            RandomPos();
        }

        #endregion

        #region プレイヤーにフォーカスする処理


        if (lookAtTarget!= null)
        {
            tankHead.LookAt(lookAtTarget);
            //攻撃範囲に入ってきたプレイヤーを時間間隔のある攻撃をする処理
            if (Vector3.Distance(this.transform.position,lookAtTarget.position)<= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime > offsetTime)
                {
                    nowTime = 0;

                    Fire();


                }


            }



        }



        #endregion

    }

    private void RandomPos()
    {
        if (randomPos.Length == 0) 
        {
            return;
        }

        targetPos = randomPos[Random.Range(0,randomPos.Length)];
    }
    public override void Fire()
    {

        for (int i = 0; i < shootPos.Length; i++)
        {
                GameObject obj = Instantiate(bullets,shootPos[i].position,shootPos[i].rotation);
                BulletObj bulletObj = obj.GetComponent<BulletObj>();
                
                bulletObj.SetFather(this);

        }

    }

    public override void Dead()
    {
        //enemy倒した後で点数を上げる処理
        GamePanel.Instance.AddScore(10);
        base.Dead();

    }

    // HPゲージの描画処理
    private void OnGUI()
    {
        if (showTime >0)
        {
            showTime -= Time.deltaTime;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            maxHPRect.x = screenPos.x - 50;
            maxHPRect.y = screenPos.y - 50;
            maxHPRect.width = 100;
            maxHPRect.height = 15;
            GUI.DrawTexture(maxHPRect, maxHP);

            nowHPRect.x = screenPos.x - 50;
            nowHPRect.y = screenPos.y - 50;
            nowHPRect.width = (float)hp / maxHp * 100f;
            nowHPRect.height = 15;
            GUI.DrawTexture(nowHPRect, nowHP);


        }



    }

    public override void Wound(TankBaseObj tank)
    {
        base.Wound(tank);
        showTime = 5;
    }

}
