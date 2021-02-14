



# Photon MultiPlayer

link to the Photon website and reference document: https://doc-api.photonengine.com/en/pun/v2/

Complete document by Photon on the photonEngine: https://doc.photonengine.com/en-us/pun/v2/getting-started/pun-intro 

Photon is a real-time multiplayer game development framework that is fast, lean and flexible. Photon consists of a server and multiple client SDKs for major platforms including Unity (Photon Unity Network, PUN). 

There are demos available  in the PUN package itself and a [PUN Basics Tutorial](https://doc.photonengine.com/en-us/pun/v2/demos-and-tutorials/pun-basics-tutorial/intro) online



Photon provides services for many platforms including Unity, and there are also Voice, Video, and chats available throughout the game experience. 

![Screen Shot 2021-02-14 at 11.26.27 PM](/Users/sherizhang/Desktop/Screen Shot 2021-02-14 at 11.26.27 PM.png)

The Photon Realtime API is the client-side software which will be directly used by games and apps. With it your apps `Connect`, `JoinRandomRoom` and `RaiseEvent` for example.

It is also available in various languages for most of the popular platforms and engines ([SDK Download Page](https://www.photonengine.com/en-us/sdks)) and pretty much all clients can interact with each other, no matter if iOS, Android, web, console or standalone.

All Photon Realtime clients connect to a sequence of dedicated servers, split by three distinct tasks: Authentication and regional distribution (Name Server), matchmaking (Master Server) and gameplay (Game Server). As those servers are handled by the Realtime API, you don't have to worry about them but it's good to have some background.

As for VRoam, we will be creating our own Photon servers and using Photon Cloud as a medium to connect our players from all places. 



### To Set Up: 

1. Create Unity Project (Unity version equal or higher than 2017.4 (beta versions are not recommended))

2. Open the Asset Store and locate the PUN 2 asset and download/install it. Install ALL assets. 

3. You will see "PUN Wizard", follow the instructions to set up a new (free) subscription to Photon

4. Save you AppId, you can log in with that ID in the future

   

Always include "namespace Com.MyCompany.MyGame" before your public class, it activates your Photon  

```c#
namespace Com.MyCompany.MyGame
{
    public class Game_Manager : MonoBehaviourPunCallbacks
    {
    }
}
```



![Screen Shot 2021-02-14 at 11.12.34 PM](/Users/sherizhang/Desktop/Screen Shot 2021-02-14 at 11.12.34 PM.png)

​		^^ your scene would look very pathetic and empty without an UI done, but it can be easily replaced 			 with the our VRoam UI, remember this is just the basic of Photon

```c#
using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class AnimatorManager : MonoBehaviourPun
    {
        #region Private Fields
        [SerializeField]
        private float directionDampTime = .25f;
        private Animator animator;
        #endregion

        #region MonoBehaviour Callbacks
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }

            if (!animator)
            {
                return;
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);

            // deal with Jumping
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            // only allow jumping if we are running.
            if (stateInfo.IsName("Base Layer.Run"))
            {
                // When using trigger parameter
                if (Input.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("Jump");
                }
            }
        }
        #endregion
    }
}
```

​	^^ this is most likely how your code would look like if you are using Photon

### Tips: 

- to start by doing the tutorial, it makes you life much easier
- Always check the documentation if something goes wrong
- remember to check the import and MonoBehaviours if your code keeps calling for errors( ex."this type of ___ cannot be found" )

