using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Camera cam;
    public List<GameObject> Events;
    public GameObject Act_Event;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void setEvent(int _id)
    {
        foreach (var active in Events)
        {
            if (active.GetComponent<Event>().Id==_id)
            {
                Act_Event = active;
                break;
            }
        }
    }
}
