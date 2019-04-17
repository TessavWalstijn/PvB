using UnityEngine;
using UnityEngine.UI;

public class LevelValues : MonoBehaviour
{
    [Header("Level Objects")]
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject _base;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _menuUIHolder;
    [SerializeField] private GameObject _inGameUIHolder;
    
    // voor demo
    public GameObject enemyholder;

    private Slider _rotationSlider;
    private Slider _scaleSlider;

    private float _sliderRotation;
    private float _sliderScale;


   private void Awake()
   {
        _level.SetActive(false);
        _inGameUIHolder.SetActive(false);

        _rotationSlider = GameObject.Find("RotationSlider").GetComponent<Slider>();
        _scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();

       _rotationSlider.onValueChanged.AddListener(SliderRotation);
       _scaleSlider.onValueChanged.AddListener(SliderScaling);

       _sliderRotation = _rotationSlider.value;
   }

   private void SliderRotation(float _value)
   {
       float delta = _value - _sliderRotation;
       _object.transform.Rotate(Vector3.up * delta * 360);

       _sliderRotation = _value;
   }

   private void SliderScaling(float _value)
   {
       float delta = _value - _sliderScale;
       _object.transform.localScale = new Vector3(1,1,1) * _value;

       _sliderScale = _value;
   }

    public void AcceptButton()
    {
        _level.SetActive(true);
        _base.SetActive(false);
        _menuUIHolder.SetActive(false);
        _inGameUIHolder.SetActive(true);

        Instantiate(enemyholder, transform.position, transform.rotation);
    }
}
