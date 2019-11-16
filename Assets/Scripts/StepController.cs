using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepController : MonoBehaviour
{
   public GameObject StepPanel;
   public GameObject goal;
   public GameObject StepText;
   public GameObject InputField;
   private int num;

   [SerializeField]
   private InputField input;

   [SerializeField]
   private Text text;


   void Awake()
   {
      num = 1500;
      text.text = "Enter your today's step";
   }
   public void GetInput(string goal)
   {
      CompareStep(int.Parse(goal));
      input.text = "";
   }

   void CompareStep(int step)
   {
      if (step >= num) 
      {
         StepPanel.SetActive(false);
         //goal.SetActive(false);
         InputField.SetActive(false);
         StepText.SetActive(false);
      }

      else if (step < num)
      {
         text.text = "Please enter step more than 1500";
      }
   }
}