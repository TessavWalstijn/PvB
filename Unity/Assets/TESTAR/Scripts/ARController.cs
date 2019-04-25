using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{
    //List met gedetecteerde planes.
    private List<DetectedPlane> _detectedPlanes = new List<DetectedPlane>();

    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private GameObject _level;

    private const float _modelRotation = 180.0f;

    private bool _levelIsActive;
    
    private void Start()
    {
        _levelIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check ARCore session status.
        if(Session.Status != SessionStatus.Tracking)
        {
            return;         // stopt update als niks getracked wordt door ARCore.
        }

        //deze functie vult _trackedPlanes aan met planes die ARCore gedetecteerd heeft.
        Session.GetTrackables<DetectedPlane>(_detectedPlanes, TrackableQueryFilter.New);

        //Instantiate een Grid voor elke DetectedPlane in _trackedPlane
        for(int i = 0; i < _detectedPlanes.Count; i++)
        {
            GameObject _grid = Instantiate(_gridPrefab, Vector3.zero, Quaternion.identity, transform);

            _grid.GetComponent<GridVisualizer>().Initialize(_detectedPlanes[i]);
        }

        //check of speler scherm aanraakt
        Touch _touch;
        if(Input.touchCount < 1 || (_touch = Input.GetTouch(0)).phase != TouchPhase.Began || _levelIsActive)
        {
            return;
        }

        //check of de speler een detectedplane aanraakt.
        TrackableHit hit;
        if(Frame.Raycast(_touch.position.x, _touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            //place gameobject

            //enable level
            _level.SetActive(true);

            //maak een anchor
            Anchor _anchor = hit.Trackable.CreateAnchor(hit.Pose);

            //maak positie van level hetzelfde als hit positie
            _level.transform.position = hit.Pose.position;
            _level.transform.Rotate(0, _modelRotation, 0, Space.Self);

            /*
            //Zorgt dat het level naar de camera draait wanneer het actief wordt gemaakt
            Vector3 cameraPosition = Camera.main.transform.position;
            cameraPosition.y = hit.Pose.position.y;
            _level.transform.LookAt(cameraPosition, _level.transform.up);
            */

            //zet het level vast aan het anchor positie
            _level.transform.parent = _anchor.transform;

            _levelIsActive = true;
        }
    }

    public void DisableGrid()
    {
        _gridPrefab.SetActive(false);
    }
}
