Contour
=======

**Contour** is a contour line (edge detection) filter for Unity.

![screenshot](http://i.imgur.com/lJIuddA.png)

Installation
------------

Download one of the unitypackage files from the [Releases] page and import it
to the project.

[Releases]: https://github.com/keijiro/KinoContour/releases

How to Use
----------

Add the Contour component to a camera. Done.

Not only the colors but also opacities of contour lines and background can be
changed by setting the alpha channel values of **Line Color** and **Background
Color**.

Contour supports three types of sources -- **Color**, **Depth** and **Normal**. 
The Normal source is only available in the deferred shading path.

Usually Depth is used to detect silhouettes of objects, but it's not good at
detecting boundaries between contacting objects (e.g. feet and ground).
Normal is useful for such cases.

License
-------

[MIT](LICENSE.txt)
