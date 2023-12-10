using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTextController : MonoBehaviour
{
    [SerializeField] public Text introText; 
    public float textSpeed = 0.05f; 
    public string introMessage = "Ho�geldin Zaman Yolcusu �pi�, bu kasaba... Nas�l desem, biraz Futurizm ak�m�n�n etkisinde ve uzun s�redir bunu ��zmeye �al���yoruz. " +
                                "Uzun s�redir �zerinde �al��t���m bir y�ntem var. Belki bunu kullanacak �ansl� ki�i sensindir. Kasaban�n bu ak�mdan kurtulmas� i�in �n�ndeki parkurlar� a�man gerekiyor. " +
                                "Sana verece�im bu y�ntem sayesinde bunu ba�arabilece�ini d���n�yorum. Her bir parkur asl�nda i� i�e ge�mi� futuristik bir parkur. " +
                                "Yani ayn� anda hem gelecek hem de ge�mi�i ya�aman gerekiyor. Bu s�rada bir ka� kez �lebilirsin ama bunu dert etme burada herkes �l�nce yeniden do�uyor. " +
                                "Parkuru ge�meye �al���rken atlayamayaca��n� fark etti�in bir platform olursa 'K' tu�una basmay� dene. " +
                                "E�er kar��na gelecek d��manlardan dolay� zaman yolculu�u yapman i�ine yaramazsa 'F' tu�una basarak onlardan kurtulmay� deneyebilirsin. " +
                                "Bu sana yard�mc� olacakt�r. Benim simdi gitmem gerek, sar� portala girmen gerekti�ini unutma. Bol �ans �pi�!"; 
    
    public string nextSceneName = "SampleScene"; 
    public static bool isIntroEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        if (introText != null && !isIntroEnd)
        {
            introText.text = "";
            StartCoroutine(FlowText());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlowText()
    {
        foreach (char letter in introMessage.ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isIntroEnd = true;
        yield return new WaitForSeconds(2f);
        introText.gameObject.SetActive(false);
        //SceneManager.LoadScene(nextSceneName);
    }
}
