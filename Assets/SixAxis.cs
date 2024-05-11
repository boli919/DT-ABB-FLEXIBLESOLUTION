using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public static class ABB_IRB120_Joint_range
{
    // ����ÿ���ؽڵ���С���������Χ����λΪ��
    public static float Joint1Min = -165f;  // �ؽ�1����С������Χ
    public static float Joint1Max = 165f;   // �ؽ�1���������Χ

    public static float Joint2Min = -110f;  // �ؽ�2����С������Χ
    public static float Joint2Max = 110f;   // �ؽ�2���������Χ

    public static float Joint3Min = -90f;   // �ؽ�3����С������Χ
    public static float Joint3Max = 70f;    // �ؽ�3���������Χ

    public static float Joint4Min = -160f;  // �ؽ�4����С������Χ
    public static float Joint4Max = 160f;   // �ؽ�4���������Χ

    public static float Joint5Min = -120f;  // �ؽ�5����С������Χ
    public static float Joint5Max = 120f;   // �ؽ�5���������Χ

    public static float Joint6Min = -400f;  // �ؽ�6����С������Χ
    public static float Joint6Max = 400f;   // �ؽ�6���������Χ
}


public class SixAxis : MonoBehaviour
{
    [SerializeField] JointUnit[] jointUnits;

    float[] jointsValue = new float[6];

    main_ui_control main;

    private void Awake()
    {
        main = GetComponentInParent<main_ui_control>();

        for (int i = 0; i < jointUnits.Length; i++) 
        {
            jointUnits[i].index = i;
            jointUnits[i].SetLabel($"J{i+1}");
            jointUnits[i].JointValueChanged.AddListener(OnJointValueChanged);   
        }


    }

    void OnJointValueChanged() 
    {
        for (int i = 0; i < jointUnits.Length; i++)
        {
            jointsValue[i] = jointUnits[i].value.Value;
        }

        main.SendNewTargetCommand(jointsValue);
    }
}
