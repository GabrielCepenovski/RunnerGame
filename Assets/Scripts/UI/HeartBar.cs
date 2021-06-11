using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthCanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthCanged;
    }

    private void OnHealthCanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = _hearts.Count;
            for (int i = 0; i < value - createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deliteHealth = _hearts.Count;
            for (int i = 0; i < deliteHealth - value; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
