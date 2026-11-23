# Fragments

A 2D shadow-platformer about a girl escaping a fortress where light is law.

Built in Unity 6000.3.7f1 with the Universal Render Pipeline and the new Input System.

## The story

Mira wakes in the brightest room of Halcyon with no shadow and no memory of losing it. Her shadow shattered into fragments when the Keep tried to take it. To escape, she has to collect the pieces — and decide what to do with the light that keeps the city obedient.

Read the full [backstory](docs/story/01-backstory.md).

## Status

Early development. The movement and ability framework are in place; the shadow ability set and level content are still being built.

- [x] Responsive movement: coyote time, jump buffer, variable jump height
- [x] Input System controls (keyboard + gamepad)
- [x] Unlockable ability framework with fragment pickups
- [x] Sample Dash and Double Jump abilities (locked by default)
- [ ] Shadow ability set: Meld, Echo, Nightfall, Eclipse
- [ ] Levels, gates, checkpoints, and camera polish

## Controls

| Action | Keyboard | Gamepad |
| --- | --- | --- |
| Move | A / D or arrow keys | Left stick / D-pad |
| Jump | Space | South button (A) |
| Dash | Left or right Shift | East button (B) |

Dash and Double Jump must be unlocked before they work.

## Getting started

1. Install Unity **6000.3.7f1** (the version in `ProjectSettings/ProjectVersion.txt`).
2. Clone the repository and open the project folder in Unity Hub.
3. Open `Assets/Scenes/SampleScene.unity`.
4. Press Play.

Required packages are declared in `Packages/manifest.json` and restore automatically.

## Project layout

```
Assets/Scripts/Player/       movement and input
Assets/Scripts/Abilities/    unlock framework and sample abilities
Assets/Scripts/Progression/  fragment pickups
Assets/Scenes/               playable scenes
docs/                        story, design notes, and reports
```

## Design documentation

Start at the [docs index](docs/README.md).

- [Backstory](docs/story/01-backstory.md)
- [Platformer game feel](docs/notes/01-platformer-game-feel.md)
- [Ability and progression design](docs/notes/02-ability-progression.md)
- [Shadow mechanics reference](docs/notes/03-shadow-mechanics-reference.md)
- [Shadow abilities for Fragments](docs/reports/01-shadow-abilities-for-fragments.md)
- [Implementation roadmap](docs/reports/02-implementation-roadmap.md)

## Versioning

Releases follow semantic versioning. Version tags look like `v0.1.0` and are recorded in [CHANGELOG.md](CHANGELOG.md).

## Topics

`unity` `unity2d` `platformer` `gamedev` `metroidvania` `shadow-mechanics` `game-design` `2d-platformer` `indie-game` `unity-urp`
