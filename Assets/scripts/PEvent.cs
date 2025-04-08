using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PEvent : MonoBehaviour
{
    public GameObject MyEvent;
    public GameObject MyProcess;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MyEvent.SetActive(true);
            MyProcess.SetActive(true);
        }
    }

}
