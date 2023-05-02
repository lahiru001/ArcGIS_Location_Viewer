using Esri.ArcGISMapsSDK.Components;
using Esri.ArcGISMapsSDK.Samples.Components;
using Esri.ArcGISMapsSDK.Utils.GeoCoord;
using Esri.GameEngine.Extent;
using Esri.GameEngine.Geometry;
using Esri.Unity;
using Unity.Mathematics;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System;
//[ExecuteAlways]
public class MapCreator : MonoBehaviour
{
    public Location[] locations = new Location[4];
    public double latitude;
    public double longitude;
    public double altitude;
    public double yAxisRotation;
    public double xAxisRotation;

    public string APIKey = "AAPK59d70ee5fef243ac8dc55bddcd1c6c102QACX9PdlppIgai-sIJjqdyvNl3VcqrAl833srreHxlfzF3pgONA9Iq1Z_DwqcZd";
    private ArcGISMapComponent arcGISMapComponent;
    private ArcGISPoint geographicCoordinates = new ArcGISPoint(-74.054921, 40.691242, 300, ArcGISSpatialReference.WGS84());
    private ArcGISCameraComponent cameraComponent;
    public ArcGISLocationComponent cameraLocationComponent;
    private MapController mapController;

    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
        CreateArcGISMapComponent();
        CreateArcGISCamera();
        //CreateSkyComponent();
        CreateArcGISMap();
    }

    private void Update()
    {
        CheckGeoPositionChanges();
    }
    private void CreateArcGISMapComponent()
    {
        arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();

        if (!arcGISMapComponent)
        {
            var arcGISMapGameObject = new GameObject("ArcGISMap");
            arcGISMapComponent = arcGISMapGameObject.AddComponent<ArcGISMapComponent>();
        }

        arcGISMapComponent.OriginPosition = geographicCoordinates;
        arcGISMapComponent.MapType = Esri.GameEngine.Map.ArcGISMapType.Local;

        arcGISMapComponent.MapTypeChanged += new ArcGISMapComponent.MapTypeChangedEventHandler(CreateArcGISMap);
    }

    public void CreateArcGISMap()
    {
        var arcGISMap = new Esri.GameEngine.Map.ArcGISMap(arcGISMapComponent.MapType);
        arcGISMap.Basemap = new Esri.GameEngine.Map.ArcGISBasemap(Esri.GameEngine.Map.ArcGISBasemapStyle.ArcGISImagery, APIKey);

        arcGISMap.Elevation = new Esri.GameEngine.Map.ArcGISMapElevation(new Esri.GameEngine.Elevation.ArcGISImageElevationSource("https://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer", "Terrain 3D", ""));
        // Create ArcGIS layers and add them to the map
        var layer_1 = new Esri.GameEngine.Layers.ArcGISImageLayer("https://tiles.arcgis.com/tiles/nGt4QxSblgDfeJn9/arcgis/rest/services/UrbanObservatory_NYC_TransitFrequency/MapServer", "MyLayer_1", 1.0f, true, "");
        arcGISMap.Layers.Add(layer_1);

        var layer_2 = new Esri.GameEngine.Layers.ArcGISImageLayer("https://tiles.arcgis.com/tiles/nGt4QxSblgDfeJn9/arcgis/rest/services/New_York_Industrial/MapServer", "MyLayer_2", 1.0f, true, "");
        arcGISMap.Layers.Add(layer_2);

        var layer_3 = new Esri.GameEngine.Layers.ArcGISImageLayer("https://tiles.arcgis.com/tiles/4yjifSiIG17X0gW4/arcgis/rest/services/NewYorkCity_PopDensity/MapServer", "MyLayer_3", 1.0f, true, "");
        arcGISMap.Layers.Add(layer_3);

        var buildingLayer = new Esri.GameEngine.Layers.ArcGIS3DObjectSceneLayer("https://tiles.arcgis.com/tiles/P3ePLMYs2RVChkJx/arcgis/rest/services/Buildings_NewYork_17/SceneServer", "Building Layer", 1.0f, true, "");
        arcGISMap.Layers.Add(buildingLayer);

        arcGISMapComponent.View.Map = arcGISMap;
    }

    private void CreateArcGISCamera()
    {
        cameraComponent = Camera.main.gameObject.GetComponent<ArcGISCameraComponent>();

        if (!cameraComponent)
        {
            var cameraGameObject = Camera.main.gameObject;

            cameraGameObject.transform.SetParent(arcGISMapComponent.transform, false);

            cameraComponent = cameraGameObject.AddComponent<ArcGISCameraComponent>();

            cameraGameObject.AddComponent<ArcGISCameraControllerComponent>();

            cameraGameObject.AddComponent<ArcGISRebaseComponent>();
        }

            cameraLocationComponent = cameraComponent.GetComponent<ArcGISLocationComponent>();
        if (!cameraLocationComponent)
        {
            cameraLocationComponent = cameraComponent.gameObject.AddComponent<ArcGISLocationComponent>();

            cameraLocationComponent.Position = geographicCoordinates;
            cameraLocationComponent.Rotation = new ArcGISRotation(65, 68, 0);
        }
    }
    public void SetGeoPosition(double longitude, double latitude, double altitude)//Set Geo position according to the user inputs
    {
        ArcGISPoint geographicCoordinates = new ArcGISPoint(longitude, latitude, altitude, ArcGISSpatialReference.WGS84());
        cameraLocationComponent.Position = geographicCoordinates;
        Debug.Log("##MAPCREATOR FUNCTION>> Altitude :" + altitude + "Longitude :" + longitude + "Latitude :" + latitude);
    }
    public void CheckGeoPositionChanges()
    {//Check whether there are any changes of location by a user action(move the map).
    //If there are any changes, then update those changes on displaying values(latitude,longitude,altitude) on headbar.

        if (((cameraLocationComponent.Position.X != longitude)||(cameraLocationComponent.Position.Y != latitude))|| (cameraLocationComponent.Position.Z != altitude))//(cameraLocationComponent.Position.Y != latitude) || (cameraLocationComponent.Position.Z != longitude)
        {
            double longitudeLocal = cameraLocationComponent.Position.X;
            double latitudeLocal = cameraLocationComponent.Position.Y;
            double altitudeLocal = cameraLocationComponent.Position.Z;
            bool t = (cameraLocationComponent.Position.X != longitude);
            mapController.UpdateGeoPosition(MapController.DataUpdater.MapCreator, longitudeLocal, latitudeLocal, altitudeLocal);
           
            longitude = cameraLocationComponent.Position.X;
            latitude = cameraLocationComponent.Position.Y;
            altitude = cameraLocationComponent.Position.Z;

            
        }
    }


    
    
}
