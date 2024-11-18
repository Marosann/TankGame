using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    
    public WeaponObj nowWeapon;

    public Transform weaponPos;

    void Update()
    {

        //WSキーで前進と後退を制御
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*moveSpeed*Time.deltaTime);
        //ADキーで回転を制御
        this.transform.Rotate(Input.GetAxis("Horizontal")* Vector3.up * roundSpeed * Time.deltaTime);

        //マウスで砲身の回転を制御
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);

        //攻撃
        if(Input.GetMouseButtonDown(0))  
        {
            Fire();
        }

    }

    public override void Fire()
    {
        if (nowWeapon!=null)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        Time.timeScale = 0;
        DeadPanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj tank)
    {
        base.Wound(tank);
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }

    /// <summary>
    /// 砲身変更
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject obj)
    {

        //今持つ砲身を削除
        if (nowWeapon!= null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //砲身変更
        GameObject weaponObj = Instantiate(obj,weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
