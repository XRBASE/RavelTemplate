# RavelTemplate
This template can be used to create assets for Ravel 

## Step 1 - Download
Download this project and it's corresponding unity version (2021.2.10f1) with Unity Hub. Also install the Webgl build support in this unity version at Installs->2021.2.10f1->Add Modules->WebGL Build Support.

## Step 2 - Open Scene
Open the projec and open up "RavelScene" under Assets/Scenes

## Step 3 - Create environment 
Create your environment, add prefabs of models under the "Level" gameobject. 

## Step 5 - Setup scene for NavMesh Generation
In order to be able to walk on a surface, you can check the "Generate colliders" checkbox in the model import settings. This will generate mesh colliders for all your meshes. Also make sure to enable the checkbox "Read/Write" in the model import. Alternatively, you can add colliders to the gameobjects you want to walk on.

## Step 4 - Optimise textures
To let your scene load fast, it is required that all your textures are in either the "RGB Compressed DXT1|BC1" format for textures without an alpha or the "RGBA Compressed DXT5|BC3" format for textures with an alpha. Don't forget that this also holds true for baked light.

## Step 5 - Build assetbundle
Save your scene (CTRL+S) and build your assetbundle by pressing Ravel->Build AssetBundles on the top navigation bar

## Step 6 - Upload assetbundle
Your assetbundle named ravelassetbundle is created in the StreamingAssets folder and is now ready to be uploaded

###### You can not add any scripts in your scene or the assetbundle will not load on Ravel