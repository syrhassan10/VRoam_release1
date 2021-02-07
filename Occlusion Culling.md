# Occlusion Culling

Occlusion Culling is an optimization feature built directly into the Unity Editor that allows for selective rendering of Game Objects based on the orientation of the main camera. By default, Unity Cameras come with frustum culling, which excludes all Game Objects that fall outside the Camera's view frustum. The issue with this is that it does not take in if an object has been occluded by another, which is where Occlusion Culling comes in. The reason for this is to prevent Unity from wasting operations, sometimes doubling or even tripling framerates depending on the environment. 

![](C:\Users\richa\Downloads\giphy.gif)

## Our Use Case

Our project is targeted towards mobile platforms such as Android/iOS. Developing for a mobile platform comes with inherent challenges, including weak hardware and less freedom when adding features to our game. In order to overcome these problems, we had to implement many optimization features, a major one being Occlusion Culling.

## How to use

In order to use Occlusion Culling, you first must create a scene and place some Game Objects. Then, you can go to Window>Rendering>Occlusion Culling in the editor and a tab should appear next to the inspector tab. Click on it and then you should see a few options, Object, Bake, and Visualization. Go to Bake, and click Bake at the bottom right of the window. Wait a few seconds (depending on the size of your scene), and it should be done. When playing your scene now, you should notice a significant performance jump regardless of the hardware you are using. Note, Occlusion Culling works best in densely packed scenes. If you have a wide open scene with few Game Objects, you should look into Billboarding.

