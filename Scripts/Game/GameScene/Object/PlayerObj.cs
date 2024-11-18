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

        //WS���`��ǰ�M�����ˤ�����
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*moveSpeed*Time.deltaTime);
        //AD���`�ǻ�ܞ������
        this.transform.Rotate(Input.GetAxis("Horizontal")* Vector3.up * roundSpeed * Time.deltaTime);

        //�ޥ����ǳh��λ�ܞ������
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);

        //����
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
    /// �h����
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject obj)
    {

        //��֤ĳh�������
        if (nowWeapon!= null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //�h����
        GameObject weaponObj = Instantiate(obj,weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
