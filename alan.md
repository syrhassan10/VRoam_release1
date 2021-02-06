# Path Planning using Bezier



![image-20210206093735762](image-20210206093735762.png)



#### How it works:

Create a new empty object and the component script 'Path Creator' - Choose Bezier Path

<img src="C:\Users\jojo\AppData\Roaming\Typora\typora-user-images\image-20210206094133530.png" alt="image-20210206094133530" style="zoom:55%;" />

To create a path hold **shift** and **Left Click **to add a new vertex that connects with the last one.

#### Code Snippet: (make an object follow that path)

###### Import Library:

`using PathCreation;`

`public PathCreator path;` 

`  public EndOfPathInstruction end; `

`public float speed;`

`float dstTravelled;`

###### Inside void Update():

`dstTravelled += speed * Time.deltaTime; `

`transform.position = path_c.path.GetPointAtDistance(dstTravelled, end);`

#### Issues you might run into:

Rotation of the object might not be what you want when it is following the path. You must play around and `transform.rotation` 

![image-20210206095304259](C:\Users\jojo\AppData\Roaming\Typora\typora-user-images\image-20210206095304259.png)

### Full Documentation of class is found here:

https://docs.google.com/document/d/1-FInNfD2GC-fVXO6KyeTSp9OSKst5AzLxDaBRb69b-Y/edit


