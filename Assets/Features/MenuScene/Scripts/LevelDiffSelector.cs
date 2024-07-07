
using TMPro;
using UnityEngine;

public class LevelDiffSelector : MonoBehaviour
{
    public LevelSetup setup;
    public TextMeshPro text;

    private string defaultText = "Put a bag on the area";

    private void Awake()
    {
        text.text = defaultText;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelDifficulty"))
        { 
            LevelDifficulty difficultyComponent = other.gameObject.GetComponent<LevelDifficulty>();
            if (difficultyComponent != null)
            {
                text.text = $"I'll bring the {difficultyComponent.difficultyName}. I'll fill it with ${difficultyComponent.scoreLimit}";
                setup.SetScoreLimit(difficultyComponent.scoreLimit);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LevelDifficulty"))
        {
            LevelDifficulty difficultyComponent = other.gameObject.GetComponent<LevelDifficulty>();
            if (difficultyComponent != null)
            {
                text.text = defaultText;
                setup.SetScoreLimit(0);
            }
        }
    }  
}
