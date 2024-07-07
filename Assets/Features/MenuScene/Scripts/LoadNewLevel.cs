using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public LevelSetup levelSetup;

    public TextMeshPro levelSelectHintText;
    public TextMeshPro difficultySelectHintText;

    private void Awake()
    {
        levelSetup.Level = -1;
        levelSetup.ScoreLimit = 0;
    }

    [ContextMenu("push")]
    public void OnPush()
    {
        levelSelectHintText.color = Color.black;
        difficultySelectHintText.color = Color.black;

        if (levelSetup == null)
        {
            return;
        }

        if(levelSetup.Level == -1)
        {
            levelSelectHintText.color = Color.red;
            return;
        }

        if(levelSetup.ScoreLimit == 0)
        {
            difficultySelectHintText.color = Color.red;
            return;
        }

        SceneManager.LoadScene(1);
    }
}