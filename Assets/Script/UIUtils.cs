using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public static class UIUtils
{
    public static void Activate(this GameObject obj, float duration = 0.2f, MovementType movementType = MovementType.LeftToRight, UnityAction callback = null)
    {
        Vector3 position = obj.transform.position;


        switch(movementType)
        {
            case MovementType.LeftToRight:
                //Vector3 destination = 
                obj.transform.localPosition = new Vector3(position.x - Screen.width, position.y, position.z);
                obj.SetActive(true);
                obj.transform.DOLocalMove(Vector3.zero, duration).OnComplete( ()=> callback.Invoke());
                break;

            case MovementType.RightToLeft:
                obj.transform.localPosition = new Vector3(position.x + Screen.width, position.y, position.z);
                obj.SetActive(true);
                obj.transform.DOLocalMove(Vector3.zero, duration).OnComplete(() => callback.Invoke());
                break;

            case MovementType.UpToDown:
                Rect rect = obj.GetComponent<RectTransform>().rect;
                Vector3 destination = obj.transform.position; 
                obj.transform.position = new Vector3(position.x, (Screen.height) + (rect.height/2), position.z); 
                obj.SetActive(true);
                obj.transform.DOMove(destination, duration).OnComplete(() => callback.Invoke());
                break;

                //case MovementType.DownToUp:
                //    obj.transform.localPosition = new Vector3(position.x - Screen.width, position.y, position.z);
                //    obj.SetActive(true);
                //    obj.transform.DOLocalMove(Vector3.zero, duration).OnComplete(() => callback.Invoke());
                //    break;
        }

    }

    public static void Deactivate(this GameObject obj, float duration = 0.2f, MovementType movementType = MovementType.LeftToRight, UnityAction callback = null)
    {
        Vector3 position = obj.transform.position;
        Vector3 destination;

        switch (movementType)
        {
            case MovementType.LeftToRight:
                destination = new Vector3(position.x + Screen.width, position.y, position.z);
                obj.transform.DOLocalMove(destination, duration).OnComplete(() =>
                {
                    obj.SetActive(false);
                    callback.Invoke();
                });
                break;

            case MovementType.RightToLeft:
                destination = new Vector3(position.x - Screen.width, position.y, position.z);
                obj.transform.DOLocalMove(destination, duration).OnComplete(() =>
                {
                    obj.SetActive(false);
                    callback.Invoke();
                });
                break;

            case MovementType.DownToUp:
                Rect rect = obj.GetComponent<RectTransform>().rect;
                Vector3 originalPosition = obj.transform.position;
                destination = new Vector3(originalPosition.x, ((Screen.height) + (rect.height/2)) ,originalPosition.z);

                obj.transform.DOMove(destination, duration).OnComplete(()=>
                {
                    obj.SetActive(false);
                    obj.transform.position = originalPosition;
                    callback.Invoke();
                });
                break;
        }
    }
}

public enum MovementType
{
    LeftToRight,
    RightToLeft,
    UpToDown,
    DownToUp
}
