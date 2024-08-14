using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlatformManager platformManager;

    private void Awake()
    {
        player.Init();
        platformManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
