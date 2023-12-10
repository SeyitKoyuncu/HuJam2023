using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTextController : MonoBehaviour
{
    [SerializeField] public Text introText; 
    public float textSpeed = 0.05f; 
    public string introMessage = "Hoþgeldin Zaman Yolcusu Ýpiþ, bu kasaba... Nasýl desem, biraz Futurizm akýmýnýn etkisinde ve uzun süredir bunu çözmeye çalýþýyoruz. " +
                                "Uzun süredir üzerinde çalýþtýðým bir yöntem var. Belki bunu kullanacak þanslý kiþi sensindir. Kasabanýn bu akýmdan kurtulmasý için önündeki parkurlarý aþman gerekiyor. " +
                                "Sana vereceðim bu yöntem sayesinde bunu baþarabileceðini düþünüyorum. Her bir parkur aslýnda iç içe geçmiþ futuristik bir parkur. " +
                                "Yani ayný anda hem gelecek hem de geçmiþi yaþaman gerekiyor. Bu sýrada bir kaç kez ölebilirsin ama bunu dert etme burada herkes ölünce yeniden doðuyor. " +
                                "Parkuru geçmeye çalýþýrken atlayamayacaðýný fark ettiðin bir platform olursa 'K' tuþuna basmayý dene. " +
                                "Eðer karþýna gelecek düþmanlardan dolayý zaman yolculuðu yapman iþine yaramazsa 'F' tuþuna basarak onlardan kurtulmayý deneyebilirsin. " +
                                "Bu sana yardýmcý olacaktýr. Benim simdi gitmem gerek, sarý portala girmen gerektiðini unutma. Bol Þans Ýpiþ!"; 
    
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
