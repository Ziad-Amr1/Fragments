# Changelog

All notable changes to this project are documented here.

The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-11-24

### Added

- Unity 6000.3.7f1 URP 2D project with the new Input System.
- Player movement with coyote time, jump buffering, variable jump height, and ground-check gizmo.
- `PlayerInput` with keyboard and gamepad bindings for move, jump, and dash.
- Ability framework: `AbilityId`, `PlayerAbility`, `IAirJumpProvider`, and `AbilityManager`.
- `DashAbility` and `DoubleJumpAbility`, both locked until unlocked by progression.
- `FragmentCollectible` trigger that unlocks abilities on pickup, with optional PlayerPrefs persistence.
- Backstory, design notes, shadow ability proposal, and implementation roadmap under `docs/`.
- Repository README and changelog.

[0.1.0]: https://github.com/Ziad-Amr1/Fragments/releases/tag/v0.1.0
