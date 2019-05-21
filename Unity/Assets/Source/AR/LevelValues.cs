using UnityEngine;
using UnityEngine.UI;

public class LevelValues : MonoBehaviour
{
    // Referenties naar gameobjecten in de scene
    [Header("Level Objects")]       
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject _base;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _menuUIHolder;
    [SerializeField] private GameObject _inGameUIHolder;
    
    // voor demo
    //public GameObject enemyholder;

    private Slider _rotationSlider;
    private Slider _scaleSlider;

    // Variabelen om op te slaan hoeveel het speelveld geroteerd is. De scale variabele is public om elk gespawnde gameobject aan te passen aan de schaal van het level.
    private float _sliderRotation;
    public float sliderScale;


   private void Awake()
   {
        // Verbergt het level en de UI van de game
        _level.SetActive(false);
        _inGameUIHolder.SetActive(false);

        // Zoekt naar de UI sliders
        _rotationSlider = GameObject.Find("RotationSlider").GetComponent<Slider>();
        _scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();

        // Zet de juiste functies op de sliders
        _rotationSlider.onValueChanged.AddListener(SliderRotation);
        _scaleSlider.onValueChanged.AddListener(SliderScaling);

        // Zet de begin rotatie als het spel opstart
        _sliderRotation = _rotationSlider.value;
   }

   private void SliderRotation(float _value)    // Functie om het gameobject te draaien met behulp van de slider
   {
       float delta = _value - _sliderRotation;
       _object.transform.Rotate(Vector3.up * delta * 360);

       _sliderRotation = _value;
   }

   private void SliderScaling(float _value)     // Functie om het gameobject te schalen met behulp van de slider
   {
       float delta = _value - sliderScale;
       _object.transform.localScale = new Vector3(1,1,1) * _value;

       sliderScale = _value;
   }

    public void AcceptButton()      // Functie om de slider UI weg te halen en het level met UI te activeren.
    {
        _level.SetActive(true);
        _base.SetActive(false);
        _menuUIHolder.SetActive(false);
        _inGameUIHolder.SetActive(true);

        //GameObject.Find("ARCoreCamera").GetComponent<ProjectingCursor>().scaleModifier = _scaleSlider.value;

        //Instantiate(enemyholder, transform.position, transform.rotation);
    }
}
