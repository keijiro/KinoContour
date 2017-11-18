KinoContour
===========

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

Contour supports three types of sources -- *Color*, *Depth* and *Normal*. 
Usually *Depth* is used to detect silhouettes of objects, but it's not good at
detecting boundaries between contacting objects (e.g. feet and ground).
*Normal* is useful for such cases, even though it's only available in deferred
shading mode.

License
-------

[MIT](LICENSE.txt)
