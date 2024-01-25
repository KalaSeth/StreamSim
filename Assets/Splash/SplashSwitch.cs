using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashSwitch : MonoBehaviour
{
    public Slider ProgSlider;
    public GameObject SplashObj;
    float Tt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Tt = 0;
        Invoke("SwitchSpla", 10);
        ProgSlider.maxValue = 10;
    }

    private void Update()
    {
        if (Tt <= 10)
        {
            Tt += Time.deltaTime;
            if (Tt >= 3)
            {
                SplashObj.SetActive(true);
            }
            ProgSlider.value = Tt;
        }
    }

    // Update is called once per frame
    void SwitchSpla()
    {
        SceneManager.LoadScene(3);
    }
}
