using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Singleton // 모든 곳에서 사용할 수 있게 하는 스크립트
{
   private static Singleton instance = null;

   public static Singleton Instance
   {
       get
       {
           if (instance == null)
           {
               instance = new Singleton();
           }
           return instance;
       }
   }

   private Singleton()
   {
    
   }
    // 다른 씬이나 다른 스크립트에서 변수 선언을 안해도 쓸 수 있음   
    public int range;       //목표 걸음 수
    public int step;        //현재 걸음 수
}
