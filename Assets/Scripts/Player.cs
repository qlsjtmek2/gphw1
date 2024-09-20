using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Player : MonoBehaviour
{
    public int Level;                // 레벨
    public int Exp;                  // 경험치
    public int Gold;                 // 골드
    public int MaxExp;               // 최대 경험치
    public int MaxGold;              // 최대 골드

    public float MaxHealth;          // 체력
    public float AttackPower;        // 공격력
    public float AttackSpeed;        // 공격속도
    public float Defense;            // 방어력
    public float MoveSpeed;          // 이동속도
    public float JumpPower;          // 점프력

    void Start()
    {
        PrintInfo();
    }

    private void PrintInfo()
    {
        FieldInfo[] myFieldInfo = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        Debug.Log("Player Start");
        foreach (FieldInfo info in myFieldInfo)
        {
            Debug.Log(info.Name + " : " + info.GetValue(this));
        }
        Debug.Log("----------------------");
    }
}
