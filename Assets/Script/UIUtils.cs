using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public static class UIUtils
{
    public static void Activate(this GameObject obj, float duration = 0.2f, MovementType movementType = MovementType.LeftToRight, UnityAction callback = null)
    {
        Vector3 destination = obj.transform.position;
        RectTransform thisTransform = obj.GetComponent<RectTransform>();
        Rect rect = thisTransform.rect;


        switch (movementType)
        {
            case MovementType.LeftToRight:
                thisTransform.position = new Vector3(-(rect.width/2), destination.y, destination.z);
                obj.SetActive(true);
                thisTransform.DOMove(destination, duration).OnComplete( ()=> callback.Invoke());
                break;

            case MovementType.UpToDown:
                thisTransform.position = new Vector3(destination.x, (Screen.height) + (rect.height/2), destination.z); 
                obj.SetActive(true);
                thisTransform.DOMove(destination, duration).OnComplete(() => callback.Invoke());
                break;
        }

    }

    public static void Deactivate(this GameObject obj, float duration = 0.2f, MovementType movementType = MovementType.LeftToRight, UnityAction callback = null)
    {
        RectTransform thisTransform = obj.GetComponent<RectTransform>();
        Vector3 initialPosition = thisTransform.position;
        Rect rect = thisTransform.rect;
        Vector3 destination;

        switch (movementType)
        {
            case MovementType.RightToLeft:
                destination = new Vector3(Screen.width + (rect.width/2), initialPosition.y, initialPosition.z);

                thisTransform.DOMove(destination, duration).OnComplete(() =>
                {
                    obj.SetActive(false);
                    thisTransform.position = initialPosition;
                    callback.Invoke();
                });
                break;

            case MovementType.DownToUp:
                destination = new Vector3(initialPosition.x, ((Screen.height) + (rect.height/2)) , initialPosition.z);

                thisTransform.DOMove(destination, duration).OnComplete(()=>
                {
                    obj.SetActive(false);
                    thisTransform.position = initialPosition;
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
