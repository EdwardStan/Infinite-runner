using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightSlide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;

    public GameObject player;
    public GameObject playerSkin;

    [SerializeField] float movementSpeed = 0.02f;

    

    private void Start()
    {
        ispressed = false;
    }
    void Update()
    {
        if (ispressed)
        {
            player.transform.Translate(movementSpeed, 0, 0);
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
