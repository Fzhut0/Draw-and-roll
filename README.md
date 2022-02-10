# Draw&Roll

<b>Draw&Roll</b> is a game where you try to save the ball by guiding it with line drawing. It has to fall into matching color exit.

Basic concept of game is about drawing/erasing lines to safely guide the ball to the destination point without touching anything beside same color line.

At first I wanted to create somekind of puzzle game based on physics where you have to get safely from point A to B. 
Later on I decided to make core of game based on quick decision making along with color matching and working with limited drawing/erasing tries.

Currently 4 levels with basic obstacles are available, and maximum of 3 balls to guide. With possibility of creating levels quicker than I anticipated, in future I intend to add
even more levels with more sophisticated traps/obstacles than just static objects and even more balls to guide per level.

Also with that simple controls I decided to create UI suited for mobile version so I could release mobile version of game in future.

# Core mechanics
<b>Free falling ball</b> - After set amount of time ball just falls down and you have to guide it with lines. Timer is shown above each ball.

<b>Color matching</b> - Colliding objects must be in the same color othwerise game is lost. Only exception is when player activates erase mode and highlights certain line.

<b>Line drawing/erasing</b> - Only way to actually give direction to a ball. You have to choose a color to draw with so it matches with ball color. 

Erasing is done only in erase mode which is activated after clicking rubber icon button. After that player can click on line to erase it. 

In both cases player has limited amount of lines to draw/erase. Both amount varies depending on current level.

<b>Traps/obstacles/world</b> - If ball touches anything beside same color line or exit platform player loses.



# How to play

https://play.unity.com/mg/other/draw-roll

WebGL version so you don't have to download it.

<b>Controls:</b> Every interaction is done with left mouse button.

In order to draw line you just hold left mouse button and simply draw on map.

PC Build is available in releases. You have to download and extract files then use .exe file.

# Screenshots

![Alt text](https://github.com/Fzhut0/Draw-and-roll/blob/master/Assets/dr1.png?raw=true "Start Menu")
![Alt text](https://github.com/Fzhut0/Draw-and-roll/blob/master/Assets/dr2.png?raw=true "Gameplay")
![Alt text](https://github.com/Fzhut0/Draw-and-roll/blob/master/Assets/dr3.png?raw=true "Gameplay")
![Alt text](https://github.com/Fzhut0/Draw-and-roll/blob/master/Assets/dr4.png?raw=true "Gameplay")
![Alt text](https://github.com/Fzhut0/Draw-and-roll/blob/master/Assets/dr5.png?raw=true "Gameplay")

