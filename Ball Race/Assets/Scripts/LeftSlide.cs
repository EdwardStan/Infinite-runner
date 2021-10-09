using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftSlide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool ispressed = false;

    [SerializeField] GameObject player;

    [SerializeField] private float movementSpeed = 0.02f;

    private void Start()
    {
        ispressed = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(ispressed)
        {
            // left control
            player.transform.Translate(-movementSpeed, 0, 0);
        }
       
    }

    
   
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
