using UnityEngine;
using UnityEngine.UI;

public class ResourceIndicator : MonoBehaviour
{
    [SerializeField] private Image loadingBar;

    void Start()
    {
        loadingBar.fillAmount = 0;
    }

    void Update()
    {
        loadingBar.fillAmount += 0.005f;

        if(loadingBar.fillAmount == 1)
        {
            loadingBar.fillAmount = 0;
        }
    }
}
