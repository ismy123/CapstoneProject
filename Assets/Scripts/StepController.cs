using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepController : MonoBehaviour
{
   public GameObject StepPanel;
   public GameObject StepText;
   public GameObject InputField;
   private int num;
   private int countGuess;

   [SerializeField]
   private InputField input;

   [SerializeField]
   private Text text;

   void Awake()
   {
      // input = GameObject.Find("InputField").GetComponent<InputField>();
      num = 1500;
      text.text = "Enter your today's step";
   }
   public void GetInput(string step)
   {
      CompareStep(int.Parse(step));
      input.text = "";
   }

   void CompareStep(int step)
   {
      if (step >= num) 
      {
         StepPanel.SetActive(false);
         StepText.SetActive(false);
         InputField.SetActive(false);
      }

      else if (step < num)
      {
         text.text = "Please enter step more than 1500";
      }
   }
}
