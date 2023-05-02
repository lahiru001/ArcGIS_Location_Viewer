using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.FilePathAttribute;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Button menuButton;
    [SerializeField] private TMP_InputField latitudeInput;
    [SerializeField] private TMP_InputField longitudeInput;
    [SerializeField] private TMP_InputField altitudeInput;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Slider timeMovingSlider;
    [SerializeField] private GameObject timeMovingSliderPanel;
    [SerializeField] private TMP_Text timeDisplayingText;

    private bool isPopMenuOpen;
    private MapController mapController;
    private List<Location> locations;

    private float timer = 0f;
    private bool timerStarted = false;
    private float updateAfterSeconds = 5f;
        
    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
        locations = FindObjectOfType<DataManager>().locations;
        DropDownInitializer();

        timeMovingSlider.onValueChanged.AddListener((value) => { //This is for notice any changes of slider
            MoveAndDisplayTimeWithSun(value);
            StartTimer();
        });

        longitudeInput.text = "-74.054921";
        latitudeInput.text = "40.691242";
        altitudeInput.text = "120";
        
    }

    private void Update()
    {
        SliderOnOffTimerExecution();
    }

    //////////  GEO VALUES GET AND SET  ////////// 
    public void ReadValuesFromInput()
    {   //Read input and call UpdateLatitude function;

        mapController.UpdateGeoPosition(MapController.DataUpdater.UI, double.Parse(longitudeInput.text), double.Parse(latitudeInput.text), double.Parse(altitudeInput.text));
    }
    public void SetGeoValues(double longitude, double latitude, double altitude)
    {
        longitudeInput.text = longitude.ToString();
        latitudeInput.text = latitude.ToString();
        altitudeInput.text = altitude.ToString();
    }


    //////////  DROPDOWNMENU(COMBOBOX) OPERATIONS  ////////// 
    void DropDownInitializer() //make dropdown menu and set location names as the options
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (Location location in locations)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(location.locationName);
            options.Add(option);
        }

        dropdown.AddOptions(options);
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }
    private void OnDropdownValueChanged(int index) //Execute when any changes of dropdown menu
    {
        Location selectedLocation = locations[index];
        double longitude = selectedLocation.longitude;
        double latitude = selectedLocation.latitude;
        mapController.UpdateGeoPosition(MapController.DataUpdater.UI, longitude, latitude, double.Parse(altitudeInput.text));
    }


    //////////  TIME AND SUN MOVING SLIDER OPERATIONS  ////////// 
    private void SliderOnOffTimerExecution()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            if (timer >= updateAfterSeconds)//After 5 seconds the timer is off and slider is deactive
            {
                //reset timer
                timer = 0;
                timeMovingSliderPanel.SetActive(false);
            }
        }
    }
    public void StartTimer()//Reset and start timer
    {
        timerStarted = true;
        timer = 0f;
    }
    public void MoveAndDisplayTimeWithSun(float sliderValue) 
    {
        //move and display the time
        float displayTimeInSec = sliderValue * 86400; //Here 86400 comes from >> 24 x 60 x 60 which is 24hours in seconds
        TimeSpan timeSpan = TimeSpan.FromSeconds(displayTimeInSec);
        String formattedTime = timeSpan.ToString(@"hh\:mm\:ss");
        timeDisplayingText.text = formattedTime; // display the time on headbar

        //move the sun
        mapController.SunTransform(displayTimeInSec);
    }

}
