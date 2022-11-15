WHAT IS THE GENERIC BOSS PREFAB?

This prefab is an easy way for anyone to implement an enemy/boss object in their
game. Enemies are vital for most games, since without them there would not be 
much of a game to play.

FEATURES?

- A* Pathfinding
- Fully functioning upgrade system using a decorator pattern
- Sprite Renderer

FUNCTIONS/SCRIPTS

Bosses.cs
- This class is the parent for all of the other Boss Classes I will be using
/*
* OnCollisionEnter2D(Collision2D collider) - Deals damage to the player when Boss collides
* DamageCooldown() - Sets a delay so Boss can't do damage quickly
* TakeDamage(int playerAttack) - Called in the player scripts when Boss needs to take damage from an attack
* dropBrain() -  Drops a brain object to be picked up by the player
* GetHealth() - Returns the Boss's current Health
* GetDamage() - Returns the Boss's current Damage
*/
BaseBoss.cs
/*
* Main Part of my decorator patter
* Contains Multiple Classes to implement the pattern:
*   BossStats
*   BasicBossStats
*   BossStatsUpgrade
*   BossStatsUpgradeDamage
*   BossStatsUpgradeHealth
*   BaseBoss - Child of Bosses class in Bosses.cs
*/
BossStats
/*
* Contains base functions for initiating a boss
* GetDamage() - Sets base damage (virtual function)
* GetHealth() - Sets the base health (virtual funciton)
*/
BasicBossStats
/*
* This class is a child of BossStats and contains function to override BossStats funcions
* GetDamage() - Overrides and sets new base damage (override function)
* GetHealth() - Overrides and sets new base damage (override function)
*/
BossStatsUpgrade
/*
* This class is a child of BossStats and contains functions to set up a wrapee Object
* GetDamage() - Overrides and sets wrapee new base damage (override function)
* GetHealth() - Overrides and sets wrapee new base health (override function)
*/
BossStatsUpgradeDamage
/*
* This class is a child of BossStatsUpgrade and contains functions set this.wrapee = wrapee
* BossStatsUpgradeDamage(BossStats wrapee) - Constructor and sets the wrapee sent into the class
* GetDamage() - Returns wrapee's damage + some value and applies it to the boss, "decorating it" 
*/
BossStatsUpgradeHealth
/*
* This class is a child of BossStatsUpgrade and contains functions set this.wrapee = wrapee
* BossStatsUpgradeHealth(BossStats wrapee) - Constructor and sets the wrapee sent into the class
* GetDamage() - Returns wrapee's health + some value and applies it to the boss, "decorating it" 
*/

AIPath.cs
/*
* This sets the movement type for the Boss object (Speed, Rotation Speed, ETC)
*/
Seeker.cs
/*
* This handles path calls for a single object
*/
AIDestinationSetter.cs
/*
* This set the destination target for the Boss object to follow
* Make sure the reference is set in the inspector
*/

