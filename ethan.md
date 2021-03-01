# Treasure Hunt Minigame

###### By: Ethan



## Scene

For the environment, I used a low-poly city from the Unity Asset Store which is found in the Sample Scene. When changing the environment, you must put a kinematic rigid body component on all of the game objects in the new environment because the script that avoids presents from spawning inside objects from the environment relies on it. 

## Spawning

The arbitrary spawning position boundaries can be changed within the "Spawning" script. Also, the spawning of regular or special presents are randomized as well, where special presents have a 10% chance of spawning.

## Hint System

The hint system can be found inside the "Hint" script. The hint system allows the player to use a bird-eye view camera to find presents from above. Once the player presses the custom hint hotkey, it also switches a global bool which activates an X mark on top of the present (Red X is for regular presents and Yellow X is for special presents). The amount of available hints, the hotkey and the amount of time for each hint can be customized. However, if you wish to change the amount of points per present, (originally 1 point for a normal present and 5 points for a special present) you must access the Present and/or Special script(s) and change the points added when right clicked manually. 

## Game Over System

The Game Over system is basically a timer which enables Text once the timer is up. The time can be changed to anything, but it must be in seconds because it will be automatically converted into a 00:00 format when the script is run. Once the timer is up, the script will enable a UI text showing you how many points you have gotten and how much in-game currency you earned based from those points. The rate of money per present can be customized within the script. 