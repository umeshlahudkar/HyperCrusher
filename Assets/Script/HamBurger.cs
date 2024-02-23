using UnityEngine;
using DG.Tweening;

public class HamBurger : MonoBehaviour, IConsumable
{
    private int consumePoint = 1;

    public int Consume()
    {
        AudioManager.Instance.PlayItemConsumeSound();
        transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => 
        {
            Destroy(gameObject);
        });

        return consumePoint;
    }
}
