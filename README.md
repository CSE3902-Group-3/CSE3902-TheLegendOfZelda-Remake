# CSE3902-TheLegendOfZelda-Remake
Remake of NES The Legend of Zelda game

## Controls:
### Player controls
- Arrow and `wasd` keys should move Link and change his facing direction.
- The `z` and `n` key should cause Link to attack using his sword.
- Number keys (1, 2, 3, etc.) should be used to have Link use a different item (later this will be replaced with a menu system and `x` and `m` for the secondary item.
- Use `e` to cause Link to become damaged.
### Block/obstacle controls
- Use keys `t` and `y` to cycle between which block is currently being shown (i.e. think of the obstacles as being in a list where the game's current obstacle is being drawn, `t` switches to the previous item and `y` switches to the next)
all blocks should be stationary and should not interact with any other objects
### Item controls
- Use keys `u` and `i` to cycle between which item is currently being shown (i.e. think of the items as being in a list where the game's current item is being drawn, `u` switches to the previous item and `i` switches to the next)
- Items should move and animate as they do in the final game, but should not interact with any other objects
### Enemy/NPC (other character) controls
- Use keys `o` and `p` to cycle between which enemy or npc is currently being shown (i.e. think of these characters as being in a list where the game's current character is being drawn, `o` switches to the previous item and `p` switches to the next)
characters should move, animate, fire projectiles, etc. as they do in the final game, but should not interact with any other objects
### Other controls
- Use `q` to quit and `r` to reset the program back to its initial state.

## Known Bugs:
- Sometimes pressing `e` to enter hurt link state does not apply until another command is processed
- Attacking does not block Link from walking and Link's sprite does not change back to idle after attacking
- Occational run time error when loading textures. This is due to MGCB editor not generating xnb file in Project/bin/Debug/net6.0/Content locally.

## Tools:
- We had an implementation which used HLSL shaders to color sprites more accurately, but due to bugs in Monogame on Mac, we were forced to remove this

## Code Metrics:
-   Maintainability, Cyclomatic Complexity, Depth of Inheritance, Class Coupling, Lines of Code, Lines of Executable Code:
-   9/21: 88, 221, 2, 52, 1611, 360
-   9/25: 85, 569, 2, 72, 3807, 925
-   10/2: 85, 732, 2, 135, 5151, 1399

## Code Reviews:
- Michael Herring reviewed Gabe DiFiore's code for quality in pull request #63
- Gabriel DiFiore reviewed MengQi Lei's code for quality in pull request #73
- Michael Herring reviewed Ethan Glenwright's code for readability in pull request #84
- Gabriel DiFiore reviewed Zhenyi Hu's code for readability (See `Code Review/Sprint 2`)
- Ethan Glenwright reviewed Matt Curie's code for quality in pull request #87
- Ethan Glenwright reviewed Matt Curie`s code for quality in pull request #101
- MengQi Lei reviewed Gabe DiFiore`s code for readability in pull request #102
- MengQi Lei reviewed ZhengYi Hu's code for quality in pull request #104
- Matthew Curie reviewed Michael's code for quality in pull request #72, #85, #94,
- Zhengyi Hu reviewed Mengqi Lei's code for quality in pull request # 103
- Zhengyi Hu reviewed Gabriel DiFiore's code for readability (See 'Code Review/Sprint 2')

## Sprint Reflections:
See `Code Review/Sprint# Reflections.txt` for sprint reflections
