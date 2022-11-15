WHAT IS THE GENERIC BOSS PREFAB?

This prefab is an easy way for anyone to implement an enemy/boss object in their
game. Enemies/Bosses are vital for most games, since without them there would not be 
much of a game to play.

FEATURES?---------------------------------------------------------------------------------------------------

A* Pathfinding
- Allows the Boss object to avoid obsticles while tracking the player or whatever you set the reference to

Fully functioning upgrade system using a decorator pattern
- Upgrades for health and damage are already implemented

Item drops
- Allows you to put a prefab of an item that you want dropped on the Boss's death

Sprite Renderer
- Allows you to put a sprite onto the Boss object

FUNCTIONS/SCRIPTS/HOW TO USE?-------------------------------------------------------------------------------

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
BaseBoss
/*
* This class is a child of Bosses and contains functions to set the stats of a boss to what the wrapee has 
* WrapDamage() - Updates the damage for the boss
* WrapHealth() - Updates the health for the boss
* Start() - Initializes bases stats
* FixedUpdate() - Updates Boss's stats, scales with round number
* GetDamage() - Gets the Boss's current damage
* GetHealth() - Gets the Boss's current health
*/

AIPath.cs
/*
* Sets all of the movement setting for the Boss
*/
Seeker.cs
/*
* Sets the path calls for a single Boss object
*/
AIDestinationSetter.cs
/*
* Sets the destination for the Boss object
*/

TROUBLESHOOTING TIPS?-------------------------------------------------------------------------------------------
- Make sure everything is referenced in the inspector if you are getting Null Reference Errors


