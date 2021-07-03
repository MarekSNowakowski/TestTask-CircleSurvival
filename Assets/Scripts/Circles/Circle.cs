using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Circle : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameOverEvent;

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
}
