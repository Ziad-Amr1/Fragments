# 01 — Platformer game feel

Goal: the player should feel that a failure was their decision, not the engine's mistake.

## The forgiveness core

These four techniques are cheap to implement and have an outsized effect. Celeste's designers publicly listed jump buffering, corner correction, and momentum storage among the "game-feel things" that make the game forgiving without making it easy.

| Technique | What it does | Typical value |
| --- | --- | --- |
| Coyote time | Jump still works briefly after walking off a ledge | 0.08–0.12 s (5–7 frames @ 60fps) |
| Jump buffer | A jump pressed just before landing is remembered | 0.10–0.15 s |
| Variable jump height | Releasing jump early cuts upward speed | multiply upward velocity by 0.4–0.5 |
| Corner correction | Nudge a jump past a ceiling corner clipped by a few pixels | up to ~4 px sideways |

Additions worth having: apex hang (reduce gravity near the top), heavier fall (fall gravity 1.5–2x rise gravity), terminal velocity, separate ground/air acceleration, and camera deadzone.

## Tune by outcome, not raw numbers

Pick the feel first, derive the constants:

- Jump height: 3–4 tiles.
- Time to apex: 0.30–0.40 s.
- Fall gravity: 1.5–2x rise gravity.
- Ground acceleration: reach top speed in 0.05–0.1 s.

Then solve for velocity and gravity instead of guessing. Playtest and adjust until it feels right; the exact value (0.10 vs 0.12) matters less than how it feels to real players.

## Feedback stack

Every action should confirm itself through multiple channels at once. Celeste's dash is the reference case:

| Channel | Dash example |
| --- | --- |
| Visual | sprite blur, afterimages, hair colour change |
| Audio | distinct whoosh + impact |
| Animation | squash/stretch, body angle |
| Screen | brief shake, freeze frame on direction change |
| UI | hair colour shows whether dash is available |

The order matters: fix the movement first, then add juice. Particle effects cannot rescue a bad jump.

## Lessons from specific games

- **Celeste** — dash is direction-aimed, 8-way, ~0.15 s, one per airborne period, refreshed on ground/wall. Commitment (no mid-dash cancel) plus clear availability creates tension and makes deaths feel earned. Momentum preservation at the end of a dash produces advanced techniques the community discovered; do not bolt on special moves, let constants interact.
- **Mega Man / Celese jump** — gravity increases at apex or on release, whichever comes first. This gives the player control over jump height and lets levels be tight without being unfair.
- **Super Meat Boy** — strong air correction because levels demand precision. Heavier platformers should preserve more momentum.
- **Ori and the Will of the Wisps** — ground movement is discrete (instant stop), air movement is relative (momentum carries). The contrast makes surfaces feel safe and air feel risky. Fast moves require a surface or refresh on touching one.
- **Hollow Knight** — every movement ability is also a combat tool. The pogo refreshes dash and double jump, so one input is damage + height + survival.
- **Ori (launch) / powers** — the most powerful movement ability comes last. Giving it early removes the variety of everything else.

## Accessibility

Screen shake, flashes, and slow motion need reduce/off options. Never rely on a single channel: pair important sounds with visuals and vice versa. Keep flashes under three per second.

## What Fragments already has

`Assets/Scripts/Player/PlayerMovment.cs` currently implements run, jump, variable jump height (0.5 cut), coyote time (0.1 s), jump buffer (0.12 s), a dash hook, and an air-jump provider hook. Ground/air acceleration split, apex hang, fall gravity, corner correction, camera, squash/stretch, dust, and sound are still open.

## Sources

- [GameSpot — Celeste dev explains how they made their game feel so good](https://www.gamespot.com/articles/celeste-dev-explains-how-they-made-their-game-feel/1100-6474775/)
- [VG101 — Celeste: The Dash](https://marty64.net/kb/pages/case-studies/celeste-dash.html)
- [CCRMA — Celeste's Dash](https://ccrma.stanford.edu/~moonlime/256A/rr1/)
- [Game Design Lab — Celeste movement tech and momentum](https://teemo.dev/game-design/celeste/systems/movement-tech-and-momentum-physics/)
- [Quirky Quintet — Celeste](https://marshalljiang.com/celeste/)
- [Planet Banatt — Celeste is Game of the Decade](https://planetbanatt.net/articles/celeste.html)
- [How It Plays — game feel dictionary](https://mystickcal.github.io/how-it-plays/index.html)
- [Platformer feel — playable learning path](https://gdcs.coody.app/paths/platformer-feel)
- [Game feel principles with animations](https://www.manuelsanchezdev.com/blog/game-feel-principles-animated-godot)
- [JXVD — Ori and the Will of the Wisps movement](https://jxvd.games/Ori-Conclusion)
- [Vicious Undertow — Ori traversal](https://viciousundertow.wordpress.com/2020/04/07/ori-and-the-will-of-the-wisps-and-strength-in-traversal/)
- [Game Developer — Designing Ori and the Will of the Wisps](https://www.gamedeveloper.com/design/q-a-designing-the-gorgeous-metroidvania-i-ori-and-the-will-of-the-wisps-i-)
