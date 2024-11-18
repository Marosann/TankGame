using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{


    public GameObject bullet;

    public Transform[] shootPos;
    //砲身を所有するタンク
    public TankBaseObj fatherTank;

    //砲身所有タンクを設置
    public void SetFather(TankBaseObj obj)
    {
        fatherTank = obj;   
    }



    public void Fire()
    {
        //発砲するところに、砲弾のインスタンスを作る。
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);

            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherTank); 
        }
    }


}
