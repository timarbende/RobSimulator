using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInText : MonoBehaviour
{
   public TextMeshPro text;

   public void ShowScoreInText(float score)
   {
      text.text = "Goal: " + score;


   }
}
