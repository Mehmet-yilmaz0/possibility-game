using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
public enum NumberState
{
    start,
    left,
    number,
    right,
    end
}

public class NumberCreat : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject end;
    public GameObject start;
    public GameObject Number;
    public NumberState NumberState;

    public GameObject Create(Vector3 position, NumberState state, int value = 0)
    {
        GameObject NewObj = null; // Baþlangýçta null olarak tanýmla

        switch (state)
        {
            case NumberState.start:
                NewObj = Instantiate(start);
                break;
            case NumberState.left:
                NewObj = Instantiate(left);
                break;
            case NumberState.number:
                NewObj = Create(position, value); // Sonsuz döngü riskine dikkat et!
                break;
            case NumberState.right:
                NewObj = Instantiate(right);
                break;
            case NumberState.end:
                NewObj = Instantiate(end);
                break;
            default:
                Debug.LogError("Bilinmeyen NumberState deðeri: " + state);
                return null;
        }

        if (NewObj == null)
        {
            Debug.LogError("NewObj oluþturulamadý! State: " + state);
            return null;
        }

        NewObj.transform.position = position;
        return NewObj;
    }
    public GameObject Create(Vector2 position, int value)
    {
        GameObject NewObj;
        NewObj = Instantiate(Number);
        Debug.Log(NewObj.GetComponent<Number>().selectNum(value));
        NewObj.GetComponent<Number>().selectNum(value);

        NewObj.transform.SetLocalPositionAndRotation(position,this.transform.rotation);
        return NewObj;
    }
    public GameObject Create(Vector2 position, string value)
    {
        GameObject NewObj;
        NewObj = Instantiate(Number);
        
        Debug.Log(NewObj.GetComponent<Number>().selectNum(value));
        NewObj.GetComponent<Number>().selectNum(value);
        NewObj.transform.SetLocalPositionAndRotation(position, this.transform.rotation);
        return NewObj;
    }   
    
    public List<GameObject> WriteNum(double Value,Vector3 StartPosition,float ObjectWeight=0.16f)
    {
        List<GameObject> NewNum = new List<GameObject>();
        string _value = double.Parse(Value.ToString()).ToString();
        Debug.Log(_value);
        NewNum.Add(Create(StartPosition,NumberState.start));
        StartPosition = AddDistance(StartPosition);
        foreach(char i in Value.ToString())
        {
            Debug.Log(i);

            NewNum.Add(Create(StartPosition, i.ToString()));
            StartPosition = AddDistance(StartPosition);
            NewNum.Add(Create(StartPosition, NumberState.left));
            StartPosition = AddDistance(StartPosition);
            Debug.Log(i);
        }
        NewNum.Add(Create(StartPosition,NumberState.end));
        return NewNum;
        
    }
    public List<GameObject> WriteNull(Vector3 StartPosition)
    {
        List<GameObject> NewNum = new List<GameObject>();
        NewNum.Add(Create(StartPosition, NumberState.start));
        StartPosition = AddDistance(StartPosition);
        NewNum.Add(Create(StartPosition, NumberState.left));
        StartPosition = AddDistance(StartPosition);
        NewNum.Add(Create(StartPosition, NumberState.left));
        StartPosition = AddDistance(StartPosition);
        NewNum.Add(Create(StartPosition, NumberState.left));
        StartPosition = AddDistance(StartPosition);
        NewNum.Add(Create(StartPosition, NumberState.end));
        return NewNum;
    }
    public Vector3 AddDistance(Vector3 position,float ObjectWeight=0.16f)
    {
        position = new Vector3(position.x+ObjectWeight,position.y,position.z);
        return position;
    }
}
