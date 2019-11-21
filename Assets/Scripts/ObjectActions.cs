/*
 * 사용자의 화면 터치를 매 프레임마다 감지하고
 * 구슬 혹은 아이템을 클릭했다면
 * 해당 구슬 또는 아이템을 얻었다는 창을 보여준다.
 */ 
using UnityEngine;
using UnityEngine.UI;

public class ObjectActions : MonoBehaviour
{
    private GameObject popup, current_marble, current_item;
    private Text title, info, num1, num2, num3, n1, n2;
    private Image image;
    private bool isMarble;                  //클릭한 오브젝트가 구슬인지 아이템인지 정보 저장

    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.Find("ObjectPopUpView");                             //팝업창
        current_marble = GameObject.Find("marbleImg");
        current_item = GameObject.Find("itemImg");

        title = GameObject.Find("objectTitle").GetComponent<Text>();            //획득 알림 텍스트
        image = GameObject.Find("earnedObjectImg").GetComponent<Image>();       //획득 오브젝트 이미지
        info = GameObject.Find("currentInfo").GetComponent<Text>();             //사용자 이름(인벤토리 현황)

        num1 = GameObject.Find("text1").GetComponent<Text>();
        num2 = GameObject.Find("text2").GetComponent<Text>();
        num3 = GameObject.Find("text3").GetComponent<Text>();

        n1 = GameObject.Find("txt1").GetComponent<Text>();
        n2 = GameObject.Find("txt2").GetComponent<Text>();

        popup.SetActive(false);
        current_marble.SetActive(false);
        current_item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {//Input.touchCount > 0 
        if ((current_item.activeSelf == false && current_marble.activeSelf == false) && Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지, 창이 열려있지 않을 때만 실행
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))               //오브젝트 터치 감지
            {
                if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {
                    isMarble = true;
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "marble01(Clone)":
                            //구슬++
                            SetObject("파란", "user", Resources.Load<Sprite>("Images/blue"), 5, 10, 15);      //값 변경
                            break;
                        case "marble02(Clone)":
                            //구슬++
                            SetObject("노란", "user", Resources.Load<Sprite>("Images/yellow"), 5, 10, 15);
                            break;
                        case "marble03(Clone)":
                            //구슬++
                            SetObject("빨간", "user", Resources.Load<Sprite>("Images/red"), 5, 10, 15);
                            break;
                        default:
                            break;
                    }
                    popup.SetActive(true);
                    current_marble.SetActive(true);
                    Destroy(raycastHit.collider.gameObject);            //오브젝트 삭제
                }
                else if(raycastHit.collider.CompareTag("item"))         //아이템 터치
                {
                    isMarble = false;
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "item01(Clone)":
                            //아이템++
                            SetObject("물약", "user", Resources.Load<Sprite>("Images/blue"), 5, 10);      //값 변경
                            break;
                        case "item02(Clone)":
                            //아이템++
                            SetObject("쉴드", "user", Resources.Load<Sprite>("Images/red"), 5, 10);
                            break;
                        default:
                            break;
                    }
                    popup.SetActive(true);
                    current_item.SetActive(true);
                    Destroy(raycastHit.collider.gameObject);            //오브젝트 삭제
                }
            }
        }
    }

    void SetObject(string color, string name, Sprite img, int num1, int num2, int num3)
    {
        title.text = color + "색 구슬을 획득했습니다.";
        info.text = "현재 " + name + "님의 구슬수입니다.";
        image.sprite = img;
        this.num1.text = num1 + " 개";
        this.num2.text = num2 + " 개";
        this.num3.text = num3 + " 개";
    }

    void SetObject(string item, string name, Sprite img, int n1, int n2)
    {
        if(item == "물약")
            title.text = item + "을 획득했습니다.";
        else
            title.text = item + "를 획득했습니다.";

        info.text = "현재 " + name + "님의 아이템 현황입니다.";
        image.sprite = img;
        this.n1.text = n1 + " 개";
        this.n2.text = n2 + " 개";
    }
    
    public void OnClosedClicked()
    {
        if (isMarble)
            current_marble.SetActive(false);
        else
            current_item.SetActive(false);

        popup.SetActive(false);
    }
}
