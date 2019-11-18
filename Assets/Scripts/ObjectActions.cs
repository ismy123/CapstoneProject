using UnityEngine;
using UnityEngine.UI;

public class ObjectActions : MonoBehaviour
{
    private GameObject popup;
    private Text title, info, num1, num2, num3;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.Find("MarblePopUpView");
        title = GameObject.Find("marbleColorTxt").GetComponent<Text>();
        info = GameObject.Find("marbleInfo").GetComponent<Text>();
        num1 = GameObject.Find("text1").GetComponent<Text>();
        num2 = GameObject.Find("text2").GetComponent<Text>();
        num3 = GameObject.Find("text3").GetComponent<Text>();
        image = GameObject.Find("marbleImg").GetComponent<Image>();

        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {//Input.touchCount > 0 
        if (Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))               //오브젝트 터치 감지
            {
                if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {                    
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "marble01(Clone)":
                            //구슬++
                            SetMarble("파란", "user", Resources.Load<Sprite>("Images/blue"), 5, 10, 15);      //값 변경
                            popup.SetActive(true);
                            break;
                        case "marble02(Clone)":
                            //구슬++
                            SetMarble("노란", "user", Resources.Load<Sprite>("Images/yellow"), 5, 10, 15);
                            popup.SetActive(true);
                            break;
                        case "marble03(Clone)":
                            //구슬++
                            SetMarble("빨간", "user", Resources.Load<Sprite>("Images/red"), 5, 10, 15);
                            popup.SetActive(true);
                            break;
                        default:
                            break;
                    }
                    Destroy(raycastHit.collider.gameObject);            //구슬 삭제
                }
            }
        }
    }

    void SetMarble(string color, string name, Sprite img, int num1, int num2, int num3)
    {
        title.text = color + "색 구슬을 획득하셨습니다.";
        info.text = "현재 " + name + "님의 구슬수입니다.";
        image.sprite = img;
        this.num1.text = num1 + " 개";
        this.num2.text = num2 + " 개";
        this.num3.text = num3 + " 개";
    }

    public void OnClosedClicked()
    {
        popup.SetActive(false);
    }
}
