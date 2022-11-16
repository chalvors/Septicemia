
WHAT IS THE SHOP PREFAB?
This prefab is a simple way for anyone to implement the player shop into the game
anywhere they please. It allows the user to upgrade the player, spending the brains 
they collected during the game.

FEATURES
Sprite Renderer - you can set any sprite you wish in the inspector and it will be rendered as 
the visual for the shop.

Box Collider 2D - The box collider is used to make sure the player can't wlak straight through 
the shop.

Circle Collider 2D - The circle collider is used as a trigger to ensure that the player is close
enough to the shop when they try to interact with it.

Rigid Body 2D - used for physics

SCRIPT
PlayerShop.cs
- extends the Interactible class
- if player is colliding with the circle collider
- and presses the interact key
- open the shop menu

TROUBLESHOOTING TIPS
- Make sure everything is referenced in the inspector if you are getting Null Reference Errors
- Make sure the two colliders are set up correctly

