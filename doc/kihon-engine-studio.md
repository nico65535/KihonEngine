# Kihon Engine Studio

Kihon Engine Studio helps for building maps

The actual basic features are the following

Some generic features 
* Save and load maps from files based on a json format
* Predefined set of textures and skyboxes. 
* Use your owns textures or skyboxes by setting custom content sources
* Possibility to change map global properties like map name, respawn player camera (position and direction)
* Source viewer for the currently edited map, in order to visualize the json format
* Game state viewer to analyse game state at any time
* Possibility to switch between edit mode and game mode in order to vizualise how map is rendered at play time

## Texture support
You can now create maps using your own textures and skyboxes. 
![Screenshot - Edit 3D map](kihonEngine-studio-editMap-texture-003.png)

### Manage content sources
Use the content source manager in `Tools > Manage Content Sources...`. 

A Content Source scans the following subfolders:
* textures : for locating textures
* skyboxes : for locating skyboxes

By defaut, when Kihon Engine Studio starts, the following content sources are available.

| Sources | Description |
| ----------| ------------| 
| Embedded resources of KihonEngine.dll | Contains skybox 1 and very few textures
| Embedded resources of KihonEngine.SampleMaps.dll |Contains some textures from Quake3 file `PAK0.PK3`. And contains few skyboxes 
| Folder `Content/Images` of execution directory | you can put some files here if you want

You can add the following content source types. 
| Sources types | Description |
| ----------| ------------| 
| Zip files or PK3 files | only subfolders `textures` and `syboxes` will be scanned
| Folder | only subfolders `textures` and `syboxes` will be scanned

Content sources manage an internal cache. So, if you make changes on texture files or skyboxe files, you will not get the new version of file. You will get the cached version. To clear cache, just remove content source and register it again by using the content source manager.

### Extract content of current map
You can extract textures and skyboxes used in current map by using `File > Save Map Content As...`

### Register your content source in your game source code
`KihonEngine.Engine` provides the following methods to register your custom content source at startup:

| Methods | Description |
| ----------| ------------| 
| RegisterContentFromAssembly | Register embedded content of a custom assemlby
| RegisterContentFromFolder | Register content from a directory
| RegisterContentFromFile | Register content from a Zip file, or a PK3 file

## Maze generator
The maze generator available in `File > New > Maze...` can be used as a starter for quickly create maps

![Screenshot - Maze editor](kihonEngine-studio-mazeEditor-02.png)

## Play mode
Play mode allows to test the map directly into the editor, in order to verify if gameplay is as expected

![Screenshot - Play on 3D map](kihonEngine-studio-playMap-003.png)

## Edit mode
Edit mode is the default mode of the editor
![Screenshot - Edit 3D map](kihonEngine-studio-editMap-003.png)

### Adding 3D models to maps

Diferent kinds of 3D models can be added to a map

| Mode type | Description |
| ----------| ------------| 
| Floor     | 
| Ceiling   | 
| Wall      | 
| Volume    | Like cube, rectangles 
| Light     | To make the viewport3D scene visible
| Skyboxe   | Actually, four predefined skyboxes are availables

### Possibility to edit the 3D models
* By dimentions
* By colors
* By textures

### Possibility to move 3D models on the map
* By rotation on axis X, Y and Z
* By translation on axis X, Y and Z

Go back to [ documentation home page](../README.md)