-== HOW TO USE ==-
This bullet will be spawned at the empty gameObject within the Pistol and Rifle enemies known as BulletPos. You can adjust the spawning location of the bullet by moving this gameObject.

The damage of the bullet will be passed in by the Pistol enemy. To change this value, change it in the PistolEnemy.cs file.

The bullet will always spawn moving in the direction of the target, even if the enemy that fires it is not facing the correct direction.

To change the speed of the bullet, you can edit the force variable in the inspector.

The bullet will also disappear after having existed for 5 seconds. You can edit this in FixedUpdate of EnemyBulletScript.cs.

The OnTriggerEnter2D is looking for a gameObject with the tag "PLAYER" in order to deal damage. You can change this if statement to deal damage to something else with health.
The OnTriggerEnter2D is looking for a gameObject with the tag "Impassable" or "Breakable" which will destroy the bullet upon impact. You can change the tags if you want it to break against other things.



-== SUPPORT ==-
If the bullet is spawning but not moving, verify that it is finding the target correctly.

Be sure to read the comments left in the code to fully understand how the bullet functions.

For other issues or feedback, send me an email at connermullins00@gmail.com



-== THANK YOU FOR DOWNLOADING! ==-
Feel free to leave a review in the Unity Asset Store!