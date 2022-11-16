-== HOW TO USE ==-
WARNING: THIS PREFAB EXPECTS YOU TO HAVE A* PATHFINDING ALREADY IMPLEMENTED IN YOUR PROJECT!!
If you do not have it, you can download it here: https://arongranberg.com/astar/download

For a video tutorial on how to set up A* Pathfinding:
https://youtu.be/jvtFUfJ6CP8?t=108

Watch from the point that the video starts to 7:33 in order to see how to set up the pathfinding grid, as well as how to change the settings for the rifle enemy pathfinding behavior.

If you wish to implement your own method of enemy pathfinding and movement, feel free to remove the following components from the prefab: Seeker, AIPath, AIDestinationSetter.
If you already have A* set up and a node-based graph on the scene, you will not need to set up the graph as shown in the video.
Instead, you can set the AIDestinationSetter Target to be whatever you want the enemy to pathfind to.

To change the health or damage of the enemy, change the values stored in the getDamage or getHealth function in BaseEnemy.cs

The takeDamage function in Enemy.cs is meant to be called by your player, who passes in their damage to reduce the enemy health.
The OnCollisionStay2D function in Enemy.cs is set up to find the takeDamage function within the player of your game. 
The damageCooldown function in Enemy.cs allows you to edit how often you want the target to take damage while colliding with the enemy. This can be changed by changing the value passed to WaitForSeconds.

********** IF YOU ARE USING THIS RIFLE ENEMY WITH THE BULLET PREFAB THAT I HAVE ALSO MADE **********
Be sure to make a bullet variant prefab and change line 49 in the code to the following:
	enemy = GameObject.FindGameObjectWithTag("RifleEnemy");

It currently is getting the damage from the PistolEnemy because in my game those two types of enemies did the same damage, so it did not matter.



-== SUPPORT ==-
If the enemy is getting stuck on corners of obstacles, you can try a number of different fixes:
	*Reduce the size of the nodes on your graph for more accurate outlines of obstacles
	*Reduce the variable in AI Path known as Pick Next Waypoint Dist
	*Increase the diameter in your to add more padding around obstacles

I highly recommend changing these three variables to find something that works for your game. There is no single solution to this problem.

If you are getting null references when attempting to try to find the player, make sure that the tag is the same as what is on the player.
You will not need to have the variable counter unless you intend to count how many enemies are remaining in a scene. If you decide to remove this, be sure to remove it in the Enemy.cs script as well

Be sure to read the comments left in the code to fully understand how the rifle enemy functions.

For other issues or feedback, send me an email at connermullins00@gmail.com



-== THANK YOU FOR DOWNLOADING! ==-
Feel free to leave a review in the Unity Asset Store!