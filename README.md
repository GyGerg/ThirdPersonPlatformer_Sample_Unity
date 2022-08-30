# ThirdPersonPlatformer_Sample_Unity
A simple (aka barebones) third person Unity game, where the only objective is to jump on enemies to gain points, avoid an untimely death from regular contact with them and reach the end of the level, which is currently represented by a blue sphere.

Currently not pretty nor do the controls feel smooth, the only objective with this really really quick "draft" was to get to an "it just works" level.
Might come back to this project later, depending on free time.

## Using the following libraries:
- Input System 1.3
- UniRx (attempts at observable wrappers for "new" input events)
- UniTask (used in initialization of some UI objects depending on other classes)
- Cinemachine (Third person camera)

## Features:
- Physics-based movement for player and NPCs (a bit janky atm)
- Waypoint-based movement for NPCs
- Basic score system

### TODO:
- [ ] Sidescroller-like controller
- [ ] Movement system fine-tuning and improvements
- [ ] Pause menu
- [ ] Multiple levels
- [ ] Better enemy variety
- [ ] Weapon system for TPS sequences
- [ ] Spaghetti untangling
