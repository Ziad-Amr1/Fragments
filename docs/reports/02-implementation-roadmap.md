# 02 — Implementation roadmap

Phases for turning the current base into the game described in [01 — Shadow abilities for Fragments](01-shadow-abilities-for-fragments.md).

## Phase 0 — Base (done)

- `PlayerMovment.cs` — run, jump, variable height, coyote 0.1 s, buffer 0.12 s, dash and air-jump hooks.
- `PlayerInput.cs` — Input System actions for move, jump, dash.
- `AbilityManager`, `PlayerAbility`, `IAirJumpProvider` — unlock/progression framework.
- `DashAbility`, `DoubleJumpAbility` — locked by default.
- `FragmentCollectible` — trigger unlocks.

## Phase 1 — Movement juice and camera

Files: `PlayerMovment.cs` (extend), new `PlayerFeedback.cs`, new `CameraFollow.cs`.

- Split ground and air acceleration; add fall-gravity multiplier and terminal velocity.
- Add apex hang and corner correction.
- Camera deadzone and lookahead; decaying shake with a user slider.
- Squash/stretch on takeoff and landing; dust particles; separate jump/land sounds.
- Acceptance: tap vs hold gives clearly different jump height; late and early jumps succeed; camera does not jitter when the player lands.

## Phase 2 — Shadow foundation

Files: `ShadeEnergy.cs`, `ShadowEnvironment.cs`, `ShadowZone.cs`, `LightZone.cs`, `ShadowAbility.cs`, `ShadowGate.cs`; extend `AbilityManager.cs`, `AbilityId.cs`.

- Three-pip Shade meter, drained by light and refilled by darkness.
- Zone triggers update a single authoritative `CurrentIsDark` query.
- `ShadowAbility` adds cost/darkness requirements without abilities referencing each other.
- `ShadowGate` blocks until a specific ability is unlocked; give gates unique art.
- Rename displayed ability names to Shadow Step and Shade Jump (code ids stay `Dash`/`DoubleJump`).
- Acceptance: a light room visibly drains the cloak indicator; a Shadow Gate opens only after the fragment is collected; no ability can spend Shade it does not have.

## Phase 3 — Meld

Files: `MeldAbility.cs`, shadow-surface collider layer, light-intersection check.

- Merge into marked shadow surfaces; hide from light enemies, pass grates, refill Shade.
- End on light exposure or empty meter, with clear warning state.
- Acceptance: a barred passage is passable only while Melded; standing under a sweeping lamp forces the player out.

## Phase 4 — Echo

Files: `EchoAbility.cs`, `ShadowClone.cs`, `RecordingBuffer.cs`.

- Record ~3 s of input/position; replay a ghost that obeys the same physics.
- Clone can hold switches and be stood on; it can die.
- Acceptance: a twin-switch door can only be solved with the clone; the clone's death resets the puzzle without soft-locking.

## Phase 5 — Late powers

Files: `NightfallAbility.cs`, `LightSource.cs`, `EclipseAbility.cs`.

- Nightfall disables marked light sources in a radius on a long cooldown.
- Eclipse gives temporary invulnerability and phasing, with a slow recharge.
- Acceptance: a light barrier opens only during Nightfall; Eclipse cannot be used before its fragment.

## Phase 6 — Content and teaching

Files: scenes and prefabs under `Assets/Scenes`, `Assets/Prefabs`.

- Tutorial room per ability; practice room chain after each teaching beat.
- One visible landmark gate placed before its ability exists, then a paying backtrack.
- Checkpoints and instant reset (`R`).
- Acceptance: every mandatory gate has a negative proof; every revisit offers a shortcut, secret, or new route; a new player can finish using only environmental cues.

## Cross-cutting checks

- Ability list split into mandatory and optional; main path depends only on mandatory abilities.
- No two abilities share an input with hidden different cooldowns.
- Screen shake, flashes, and slow motion have reduce/off settings.
- Important events have both audio and visual feedback.
