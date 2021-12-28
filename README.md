# mocap shadow
project to determine shadow and make a intensity mask from mocap(motion capture) with the help of AI(Artificial neural network)
This is a fork from ThreeDPoseUnityBarracuda (https://github.com/digital-standard/ThreeDPoseUnityBarracuda)

Created with Unity ver 2020.3.24f1.
Uses Barracuda 2.4.0 to load onnx.

Note: This README file is not complete and will change in the future.

## Install
See the image "Install.png" for a visuall explanation on how to install this.
0. download Unity ver 2020.3.24f1 and this project
1. open Unity ver 2020.3.24f1, then open this project(mocap shadow) in Unity.
2. download  barracuda release 2.4.0-preview and unzip it. Then add it to the unity project with the help of package manager. Link to download barracuda release 2.4.0-preview: https://github.com/Unity-Technologies/barracuda-release/archive/refs/tags/2.4.0-preview.zip
3. Download this onnx file: https://digital-standard.com/threedpose/models/Resnet34_3inputs_448x448_20200609.onnx
and put it in the folder: \mocap shadow\Assets\Scripts\Model\

For more information see the README.md in the project ThreeDPoseUnityBarracuda under the section "Install and Tutorial". (https://github.com/digital-standard/ThreeDPoseUnityBarracuda#readme)

## Tutorial
In unity editor, the file "MainTexrure", there exist option to use "Use Web Cam". You can use this option, or you can add a video file to the file "Video Player" option "Video Clip".

When the program is running, you can use the key 1 to remove the character and only show the shadow. Or you can use the key 2 to take a screenshot of the shadow the character is casting. It will save the file at "mocap shadow\Assets\SimulatedShadow.png".

For more information see the README.md in the project ThreeDPoseUnityBarracuda under the section "Install and Tutorial" and the section "Other Option". (https://github.com/digital-standard/ThreeDPoseUnityBarracuda#readme)

## Hardware
This program has been successfully tested with the GPU RTX 2070 super.
This project may not work with CPU, have not tested yet though.

## License
### Non-commercial use</br>

### Commercial use</br>
 * Non-commercial use only.</br>

### Unitychan</br>
We follow the Unity-Chan License Terms.</br>
https://unity-chan.com/contents/license_en/</br>
![Light_Frame.png](Assets/StreamingAssets/ScreenShots/Light_Frame.png)</br></br>

### [3D] STICKMAN CHARACTER
This project is also using the model "[3D] STICKMAN CHARACTER" by Voogie
Link to the model: https://sketchfab.com/3d-models/3d-stickman-character-cfd15a930b4b4df8a9eece0eeb566fcf




