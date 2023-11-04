# CSE3902-TheLegendOfZelda-Remake
Remake of NES The Legend of Zelda game

## Controls:
### Player controls
- Arrow and `wasd` keys should move Link and change his facing direction.
- The `z` and `n` key should cause Link to attack using his sword.
- Number keys (1, 2, 3, etc.) should be used to have Link use a different item (later this will be replaced with a menu system and `x` and `m` for the secondary item.

### Other controls
- Use `q` to quit and `r` to reset the program back to its initial state.

## Known Bugs:
- Occational run time error when loading textures. This is due to MGCB editor not generating xnb file in Project/bin/Debug/net6.0/Content locally.
- Link should be able to walk in front of a wall as long as his bottom half is below it, but right now his top half blocks him from walking in front
- Link sprite sometimes lingers in previous room when switching rooms.
- Link can only place bombs with 1 key and cannot use any other items
- Bombs dissappear instead of exploding when placed by Link
- When Link places a bomb it is sometimes placed too far away
- Stalfos sometimes gets stuck in wall
- Enemies dissappear instead of taking damage and blinking/flashing/taking knockback/exploding when hit with Link's sword
- The game crashes if Link attacks the wizard
- Some rooms have a yellow square instead of the left door
- Pushable blocks are not yet implemented
- Explodeable walls are not yet implemented
- Dodongo does not yet eat bombs

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

## Sprint Reflections:
See `Code Review/Sprint# Reflections.txt` for sprint reflections
