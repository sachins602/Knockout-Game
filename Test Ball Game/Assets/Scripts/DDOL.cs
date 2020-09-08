﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }

}
