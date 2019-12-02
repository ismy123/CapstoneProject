/*
 * 사용자의 화면 터치를 매 프레임마다 감지하고
 * 구슬 혹은 아이템을 클릭했다면
 * 해당 구슬 또는 아이템을 얻었다는 창을 보여준다.
 * 
 * 화면의 상단에서 오브젝트를 클릭하면 더 걸으라는 메시지를 2초 동안 띄운다.
 * 구슬 삭제하기 전에 사용자에게 구슬을 지급한다.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectActions : MonoBehaviour
{
    private GameObject popup, current_marble, current_item;
    private Text title, info, num1, num2, num3, n1, n2;
    private Image image;
    private bool isMarble;                  //클릭한 오브젝트가 구슬인지 아이템인지 정보 저장

    private Image toastBackground;
    private Text text;

    private void Awake()
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

        toastBackground = GameObject.Find("toastBackground").GetComponent<Image>();
        text = GameObject.Find("toastMsg").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        current_marble.SetActive(false);
        current_item.SetActive(false);

        toastBackground.enabled = false;
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((current_item.activeSelf == false && current_marble.activeSelf == false) && Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지, 창이 열려있지 않을 때만 실행
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))                   //오브젝트 터치 감지
            {
                if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {
                    isMarble = true;

                    /*if (Input.GetTouch(0).position.y >= (Screen.height * 0.8))    //사용자가 화면의 4/5 아래 위치에서 터치할 때 동작
                    {
                        StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                    }*/
                    //else
                    //{
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

                        toastBackground.enabled = false;                        //아이템 창 나올 땐 토스트 메시지 안나오게 함
                        text.enabled = false;

                        popup.SetActive(true);
                        current_marble.SetActive(true);
                        Destroy(raycastHit.collider.gameObject);            //오브젝트 삭제
                    //}
                }
                else if (raycastHit.collider.CompareTag("item"))         //아이템 터치
                {
                    isMarble = false;

                    /*if (Input.GetTouch(0).position.y >= (Screen.height * 0.8))    //사용자가 화면의 4/5 아래 위치에서 터치할 때 동작
                    {
                        StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                    }
                    else
                    {*/
                        switch (raycastHit.collider.gameObject.name)
                        {
                            case "item01(Clone)":
                                //아이템++
                                SetObject("물약", "user", Resources.Load<Sprite>("Images/blue"), 5, 10);  //값 변경
                                break;
                            case "item02(Clone)":
                                //아이템++
                                SetObject("쉴드", "user", Resources.Load<Sprite>("Images/red"), 5, 10);
                                break;
                            default:
                                break;
                        }

                        toastBackground.enabled = false;                        //아이템 창 나올 땐 토스트 메시지 안나오게 함
                        text.enabled = false;

                        popup.SetActive(true);
                        current_item.SetActive(true);
                        Destroy(raycastHit.collider.gameObject);              //오브젝트 삭제
                    //}
                }
            }
        }
    }

    void SetObject(string color, string name, Sprite img, int num1, int num2, int num3)     //구슬 수정 창
    {
        title.text = color + "색 구슬을 획득했습니다.";
        info.text = "현재 " + name + "님의 구슬수입니다.";
        image.sprite = img;
        this.num1.text = num1 + " 개";
        this.num2.text = num2 + " 개";
        this.num3.text = num3 + " 개";
    }

    void SetObject(string item, string name, Sprite img, int n1, int n2)        //아이템 수정 창
    {
        if (item == "물약") { title.text = item + "을 획득했습니다."; }
        else { title.text = item + "를 획득했습니다."; }

        info.text = "현재 " + name + "님의 아이템 현황입니다.";
        image.sprite = img;
        this.n1.text = n1 + " 개";
        this.n2.text = n2 + " 개";
    }

    public void OnClosedClicked()           //확인 버튼 클릭했을 때, 구슬인지 아이템인지 확인하고 해당 창 닫기
    {   
        if (isMarble)
            current_marble.SetActive(false);
        else
            current_item.SetActive(false);

        popup.SetActive(false);
    }
    
    IEnumerator ShowToast(string msg, float duration)       //토스트 메시지
    {
        text.text = msg;
        text.enabled = true;
        toastBackground.enabled = true;
        Color background = new Color(toastBackground.color.r, toastBackground.color.g, toastBackground.color.b);

        yield return fadeInAndOut(text.color, background, true);      //0.5초 동안 페이드인

        float count = 0;
        while (count < duration)            //duration초 동안 메시지 보여줌
        {
            count += Time.deltaTime;
            yield return null;
        }

        yield return fadeInAndOut(text.color, background, false);     //0.5초 동안 페이드아웃

        text.enabled = false;
        toastBackground.enabled = false;
    }

    IEnumerator fadeInAndOut(Color text, Color background, bool fadeIn)        //페이드인 페이드아웃 효과
    {
        if(fadeIn)
        {
            for (float i = 0f; i <= 1; i+=0.3f)
            {
                text = new Color(1, 1, 1, i);
                background = new Color(background.r, background.g, background.b, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0f; i -= 0.3f)
            {
                text = new Color(1, 1, 1, i);
                background = new Color(background.r, background.g, background.b, i);
                yield return null;
            }
        }
    }
}