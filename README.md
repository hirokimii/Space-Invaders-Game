# Space Invaders Game

Space Invaders game in C# with an mBed game controller. The controller communicates with the game through a USB virtual COM port. This is an ECE 4180 final project by Hiroki Mii and Ali Rizvi.

## C# game

The Space Invaders game was developed using MOO ICT's [tutorial](https://www.mooict.com/c-tutorial-create-a-full-space-invaders-game-using-visual-studio/#google_vignette) as a starting template.

When starting the game, there are 3 game modes: Easy, Medium, Hard. The difference between the modes is the rate at which the spader invaders appear on the screen. There are designated bottons on the mBed Controller which allow the mode to be selected.

Once the game initializes, it runs through ```mainGameTimerEvent```, a function that runs every 20 ms. In ```mainGameTimerEvent```, it opens a serial port and reads controls from the mBed controller, such as the analog joystick and shooting button. Simulatenously, ```makeInvaders``` generates invaders on to the screen, as well as ```makeBullet("InvaderBullet")``` which shoots bullets at the spaceship.

The game can be won by eliminating all the invaders before using up all 5 lives. The objective is to protect Earth and each invader let past costs a life. In the current code, you would encounter 10 invaders.

## mBed Controller

<img src="https://github.com/hirokimii/Space-Invaders-Game/assets/145586445/46568481-3964-44da-af38-3b045f8fd810" width="504" height="378">

The components on the controller include an analog joystick, push button for shooting, 3 push bottons to select game mode, 3 LEDS to represent the game modes, and a speaker with a class D audio amp.


