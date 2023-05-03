# ArcGIS Location Viewer

ArcGIS Location Viewer is a Unity-based application that provides a platform to explore real-world locations and 3D objects with OSM metadata. The application utilizes the ArcGIS Maps SDK for Unity to enable users to access real-world maps and 3D content in ArcGIS. 

![Screenshot (12) (1)](https://user-images.githubusercontent.com/59786507/235827094-79686ed4-89fb-4fd6-af64-23399b1bc5dd.png)

## Getting Started

To get started with ArcGIS SDK for Unity, please refer to the following link: https://developers.arcgis.com/unity/get-started/.

## Features

1. Main menu UI interface, containing a combobox of predefined locations.
2. Load 3D maps of a selected location and enable the user to rotate, zoom, and move.
3. UI element slidebar to change the time of day and adjust the sun position.
4. UI element showing the longitude, latitude, altitude of the camera above the ground. The user can also manually input values for longitude and latitude.

### Currently developing
6. Allow the user to click on a building to display a popup containing building metadata from OSM.
7. Create a .json file containing a few examples of metadata ([BUILDING_ID, METADATA_TXT]), and if the user clicks on a building that is listed in this .json, the corresponding metadata is added to the popup containing OSM metadata.
8. Create a basic Python app that is streaming at 10Hz a sine function with a UDP server.
9. The Unity app connects to this Python app with a UDP client, receives the sine wave, and plots it with a graph updated at 10Hz in the metadata’s popup of all building (under previous metadata).
10. When a building is deselected, the popup should close.

## Installation

To clone this repository, run the following command:

```
git clone https://github.com/lahiru001/ArcGIS_Location_Viewer.git
```

## Usage

To use this application, you can open it in Unity and run the scene. You can select the location from the main menu, and the 3D map will be loaded. You can use the slidebar to change the time of day and adjust the sun position. 

## Contribution

Contributors are welcome to develop this application further. Please refer to the wireframe sketch mockup on https://www.figma.com/file/9xg9Yc0RrSQCprdmXhpVIv/ArcGIS-Map---wireframe?node-id=0%3A1&t=0jNVg0xBO6ENoKrx-1 for a better understanding of the project. 

## License

This project is distributed under the MIT License.

## Contact

For any inquiries or suggestions, please contact lahirudhananjaya10@gmail.com.
