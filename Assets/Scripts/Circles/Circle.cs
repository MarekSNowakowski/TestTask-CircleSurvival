using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Circle : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameOverEvent;

    [SerializeField]
    private GameObject explodeEffect;
    [SerializeField]
    protected const float EFFECT_TIME = 1.5f;

    public abstract void OnCircleClicked();

    protected void EndGame()
    {
        if(gameOverEvent)
        {
            gameOverEvent.Raise();
        }
        else
        {
            Debug.LogWarning("Circle lacks game over event");
        }
    }

    protected void PlayExplodeEffect()
    {
        var effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(effect, EFFECT_TIME);
    }
}
