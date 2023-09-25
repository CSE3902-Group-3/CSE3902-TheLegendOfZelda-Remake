# CSE3902-TheLegendOfZelda-Remake
Remake of NES The Legend of Zelda game

## Controls:
### Player controls
- Arrow and "wasd" keys should move Link and change his facing direction.
- The 'z' and 'n' key should cause Link to attack using his sword.
- Number keys (1, 2, 3, etc.) should be used to have Link use a different item (later this will be replaced with a menu system and 'x' and 'm' for the secondary item.
- Use 'e' to cause Link to become damaged.
### Block/obstacle controls
- Use keys "t" and "y" to cycle between which block is currently being shown (i.e. think of the obstacles as being in a list where the game's current obstacle is being drawn, "t" switches to the previous item and "y" switches to the next)
all blocks should be stationary and should not interact with any other objects
### Item controls
- Use keys "u" and "i" to cycle between which item is currently being shown (i.e. think of the items as being in a list where the game's current item is being drawn, "u" switches to the previous item and "i" switches to the next)
- Items should move and animate as they do in the final game, but should not interact with any other objects
### Enemy/NPC (other character) controls
- Use keys "o" and "p" to cycle between which enemy or npc is currently being shown (i.e. think of these characters as being in a list where the game's current character is being drawn, "o" switches to the previous item and "p" switches to the next)
characters should move, animate, fire projectiles, etc. as they do in the final game, but should not interact with any other objects
### Other controls
- Use 'q' to quit and 'r' to reset the program back to its initial state.

## Known Bugs:
-

## Tools:
- We had an implementation which used HLSL shaders to color sprites more accurately, but due to bugs in Monogame on Mac, we were forced to remove this

## Code Metrics:
- 9/21:
-   Maintainability: 88
-   Cyclomatic Complexity: 221
-   Depth of Inheritance: 2
-   Class Coupling: 52
-   Lines of Code: 1611
-   Lines of Executable Code: 360

Code Reviews:
- Michael Herring reviewed Gabe DiFiore's code for quality in pull request #63
- Gabriel DiFiore reviewed MengQi Lei's code for quality in pull request #73
- Michael Herring reviewed Ethan Glenwright's code for readability in pull request #84
- Gabriel DiFiore (will) reviewed Zhenyi Hu's code for readability in pull request #68
