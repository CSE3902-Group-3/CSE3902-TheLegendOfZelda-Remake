# CSE3902-TheLegendOfZelda-Remake
Remake of NES The Legend of Zelda game

## Controls:
### Player controls
- Arrow and `wasd` keys should move Link and change his facing direction.
- The `z` and `n` key should cause Link to attack using his sword.
- `b` for Link to use his secondary item

### Other controls
- Use `q` to quit and `r` to gameover and reset the program back to its initial state.
- Use `space` to pause and resume the game.
- Use right/left click to cycle rooms

## Major Known Bugs:
- All menus (including HUD) exept game over are not currently functional at all
- The inventory system is not currently functional at all
-   Link can not use any items
-   Picking up items does nothing (collision response is incomplete)

- Dodongo takes damage from sword and player, does not eat bombs
- Closed doors which open based on triggers (as opposed to locked doors) can never be opened

## Minor Known Bugs:
- Occational run time error when loading textures. This is due to MGCB editor not generating xnb file in Project/bin/Debug/net6.0/Content locally.
- Link teleports when traveling through a door instead of walking through
- Link does not receive invincibility frames when he collides with a slime
- Enemies drop items when exiting a room
- Goriya sometimes walks through certain walls
- Link does not spin when he dies
- Sword beam does not spawn in the correct position
- The starting room is not the entrance of the dungeon
- The pause overlay does not affect Link's sprite
- Sprites still animate when the game is paused
- Fireballs are missing from the wizard room
- Wizard takes damage
- Main menu has green line on the left
- Screen size is a square as opposed to a rectangle in the original
- Pushable blocks do not reset upon reentry to a room

## Intentional Differences From Source Game:
- Interaction with Wizard and spawning text is not implemented
- The exit of the dungeon is closed
- Right and left clicking to switch between rooms
- One room contains an instance of every item
- There is an extra room with no doors to house Dodongo
- Item spawn rates are drastically increased
- Shader related effects look different from the original game
- Game over menu is simplified since options like saving are not available in this game
- Enemy movement patterns may vary slightly
- The time it takes to push the pushable blocks may vary slightly

## Tools:
- We had an implementation which used HLSL shaders to color sprites more accurately, but due to bugs in Monogame on Mac, we were forced to remove this

## Code Metrics:
-   Maintainability, Cyclomatic Complexity, Depth of Inheritance, Class Coupling, Lines of Code, Lines of Executable Code:
-   9/21: 88, 221, 2, 52, 1611, 360
-   9/25: 85, 569, 2, 72, 3807, 925
-   10/2: 85, 732, 2, 135, 5151, 1399
-   10/15: 84, 1127, 2, 187, 7443, 2032
-   10/20: 83, 1277, 2, 186, 8167, 2317
-   10/23: 83, 1318, 2, 196, 8402, 2391
-   11/6: 82, 1664, 2, 221, 9975, 2805

## Code Reviews:
When possible, we tried to do our code reviews as part of pull requests, which are listed below. In cases where that was impossible (no PR's ready for review), we wrote them in text files.

#### Sprint2:
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
- Zhengyi Hu reviewed Gabriel DiFiore's code for readability (See `Code Review/Sprint 2`)


#### Sprint 3
- Gabriel DiFiore reviewed Ethan Glenwright's code for quality in pull request #177
- MengQi Lei reviewed Michael Herring's code for readability (See `Code Review/Sprint 3`)
- Zhengyi Hu reviewed Mengqi Lei's code for quality in pull request #129
- Zhengyi Hu reviewed Ethan Glenwright's code for readability (See `Code Review/Sprint 3`)
- MengQi Lei reviewed Gabe DiFiore's code for code quality (See `Code Review/Sprint 3`)
- Michael Herring reviewed Menqi Lei's code for readability (See `Code Review/Sprint 3`)
- Michael Herring reviewed Matt Curie's code for quality (See `Code Review/Sprint 3`)
- Gabriel DiFiore reviewed Michael Herring's code for readability in pull request #189
- Ethan Glenwright reviewed Matt Curie's code for quality in pull request #191
- Ethan Glenwright reviewed ZhengYi Hu's code for readability in pull request #190
- Matt Curie reviewed Michael Herring's code for quality in pull requests #142, #150, #151 and #158
- Matt Curie reviewed Michael Herring's code for reusability in pull requests #159

#### Sprint 4
- Michael Herring reviewed Zhengyi Hu's code for quality in pull request #257
- Michael Herring reviewed Matt Curie's code for readability in pull request #260
- Ethan Glenwright reviewed MengQi Lei's code for quality in pull request #280
- MengQi Lei reviewed Ethan Glenwright's code for readability in pull request #301

## Sprint Reflections:
See `Code Review/Sprint# Reflections.txt` for sprint reflections

#### Sprint 5 Topic Ideas:
- Michael Herring: Reinvestigate HLSL shaders from sprint 2
