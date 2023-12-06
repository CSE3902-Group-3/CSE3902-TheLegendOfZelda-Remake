# CSE3902-TheLegendOfZelda-Remake
Remake of NES The Legend of Zelda game

## Controls:
### Player controls
- Arrow and `wasd` keys should move Link and change his facing direction.
- The `z` and `n` key should cause Link to attack using his sword.
- `x` for Link to use his secondary item

### Other controls
- Use `Enter` to start the game from the starting menu
- Use `q` to quit
- Use `r` to gameover and reset the program back to its initial state.
- Use `space` to pause or resume the game.
- Use right/left click to cycle rooms
- After Link dies, use `Shift` to switch between options in game over menu. Use `Enter` to select the option.
- Use `k` and `l` to cycle through different color palletts (when controlling Link or on the main menu)

### Cheat codes
- Use `C`+`P` to get 5 rupees.
- Use `C`+`J` to get a key.
- Use `C`+`T` to get a Bomb.
- Use `C`+`H` to heal Link to max HP.
- Use `C`+`O` to kill all enemies in current room.

### Config file: `config.ini`
- Edit this file to modify game constants related to Link speed/HP, game difficulty, start level, etc.

## Major Known Bugs:
- Dodongo does not eat bombs
- Compass item does nothing
- Map item does nothing
- Clock item does nothing
- Clicking to the bonus enemy room in dungeon 1 crashes the game
- Link's health does not update
- Rope sometimes goes through walls

## Minor Known Bugs:
- If an enemy damages Link and pushes him into a wall, and then happens to move closer, "smashing" Link into the wall, it can cause a variety of effects such as:
- Link dies instantly
- Link becomes permanently invincible to enemies
- Link bounces around wildly, then dies, and upon continuing his sprite remains where he died like a dead body
- The minimap in the item menu is missing the rightmost room in the row three up from the bottom
- Link cannot throw boomerang diagonally

## Plans for work during finals week:
- We plan to fix all of the major known bugs before our final presentation and any of the minor known bugs that we can get to.

## Intentional Differences From Source Game:
- Interaction with Wizard and spawning text is not implemented
- The exit of the dungeon is closed
- Right and left clicking to switch between rooms
- One room in dungeon 1 contains an instance of every item (room 19)
- One room in dungeon 1 contains enemies not in any other room, such as Dodongo (room 20)
- Item spawn rates are drastically increased
- Shader related effects look different from the original game
- "Save" option in Game Over Menu is replaced by "Quit" option
- Options to play dungeon 1, 2 and quit the game are given after winning, instead of automatically exit the dungeon
- The intro sequence is different from the original
- Enemy movement patterns may vary slightly
- The time it takes to push the pushable blocks may vary slightly

## Tools:
- We used HLSL to write shaders for the game
- We used MS paint to modify sprite assets taken from https://www.spriters-resource.com/nes/legendofzelda/

## Code Metrics:
-   Maintainability, Cyclomatic Complexity, Depth of Inheritance, Class Coupling, Lines of Code, Lines of Executable Code:
-   9/21: 88, 221, 2, 52, 1611, 360
-   9/25: 85, 569, 2, 72, 3807, 925
-   10/2: 85, 732, 2, 135, 5151, 1399
-   10/15: 84, 1127, 2, 187, 7443, 2032
-   10/20: 83, 1277, 2, 186, 8167, 2317
-   10/23: 83, 1318, 2, 196, 8402, 2391
-   11/6: 82, 1664, 2, 221, 9975, 2805
-   11/13: 82, 1831, 2, 231, 11001, 3103
-   11/29: 83, 2513, 2, 298, 15164, 4203
-   12/6: 83, 2981, 2, 317, 16346, 4643

## Code Analysis:
-  11/13: 1 warning: CS0219 (variable assigned but never used)
-  11/29: 8 warnings for fields assigned but never used
-  12/6: No warnings!

## Code Reviews:
When possible, we tried to do our code reviews as part of pull requests, which are listed below. In cases where that was impossible (no PR's ready for review), we wrote them in text files.

#### Sprint2:
- Michael Herring reviewed Gabe DiFiore's code for quality in pull request #63
- Gabriel DiFiore reviewed MengQi Lei's code for quality in pull request #73
- Michael Herring reviewed Ethan Glenwright's code for readability in pull request #84
- Gabriel DiFiore reviewed Zhenyi Hu's code for readability (See `Code Review/Sprint 2`)
- Ethan Glenwright reviewed Matt Curie's code for quality in pull request #87
- Ethan Glenwright reviewed Matt Curie`s code for readability in pull request #101
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
- Ethan Glenwright reviewd MenQi Lei's code for readability in pull request #335
- MengQi Lei reviewed Ethan Glenwright's code for readability in pull request #301
- MengQi Lei reviewed ZhengYi Hu's code for quality in pull request #284
- Gabriel DiFiore reviewed Ethan Glenwright's code for readability in PR #295
- Gabriel DiFiore reviewed Matt Curie's code for quality in PR #279

#### Sprint 5
- Michael Herring reviewed Zhengyi Hu's code for readability in pull request #432
- Gabriel DiFiore reviewed Zhengyi Hu's code for readability in PR #405
- Ethan Glenwright reviewed Gabriel DiFiore's code for quality in PR #430
- Michael Herring reviewed Matt Curie's code for quality in PR #428
- Gabriel DiFiore reviewed Matt Curie's code for quality in PR #468
- Ethan Glenwright reviewed MengQi Lei's code for readability in PR #473
- MengQi Lei reviewed Michael Herring's code for quality (See `Code Review/Sprint 5`)
- MengQi Lei reviewed Matt Curie's code for readability (See `Code Review/Sprint 5`)

## Sprint Reflections:
See `Code Review/Sprint# Reflections.txt` for sprint reflections

## Sprint 5 Topic Ideas:
- Michael Herring: Reinvestigate HLSL shaders from sprint 2
- Gabriel DiFiore: Config game with `.ini` file, load in custom Link health, enemy damage/difficulty, etc
- Ethan Glenwright: Create the second level and add a cool new level transition screen
- Matt Curie: Refactoring enemy code to better fit software engineering standards, more accurate enemy behaviors
