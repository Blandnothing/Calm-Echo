using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Player player;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

}
