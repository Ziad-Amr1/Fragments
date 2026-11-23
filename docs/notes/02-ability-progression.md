# 02 — Ability and progression design

## An ability must be a key and a verb

A good unlock changes both *where you can go* and *how you move or fight*. If it only opens a door, it is a keycard, not an ability. Guacamelee and Hollow Knight are the standard examples: upgrades feed back into the normal routine instead of being used once in one section.

Test for each proposed ability:

1. Does it change the player's movement envelope?
2. Does it have a use in combat or defence, not just traversal?
3. Does it open at least one route that was previously impossible?
4. Can it combine with abilities the player already owns?

If all four are yes, it is worth building.

## Mandatory vs optional — write two lists

List every ability in unlock order, then separately list the optional ones. Main path gates may only depend on mandatory abilities. This simple rule prevents soft-locks. Optional abilities can still gate optional content, which makes them feel significant even when missable.

Draw the world as a graph: biomes are nodes, abilities are keys, gates are edges. Dashed edges are optional. This exposes unreachable areas and sequence breaks before you build any rooms.

## Teach, then test

- **Tutorial room** — the player cannot leave without using the new ability. Pair with a short prompt if the action is not obvious.
- **Practice room chain** — no stakes, immediate retry, each room slightly harder than the last. The room after the chain adds real danger.
- **Conveyance** — teach through level geometry and visual language rather than text. Closure has no text at all; when playtesting showed players did not understand an interaction, the team added a visual cue (an outline on grabbable orbs, a light on a pedestal that resets).
- **Landmarks for locks** — make the gate you cannot pass visually unforgettable, so when you gain the matching ability you immediately know where to go back. Super Metroid's statue is the classic example.

## Gates need a negative proof

The movement envelope is only a lower bound. For every "you cannot pass yet", check the best possible ungated maneuver against the real geometry and confirm it falls short. Otherwise a skilled player slips through by accident and the promise breaks.

## Backtracking must pay

A revisit should offer new reachability, a shortcut, or a secret — never an empty walk. Good options:

- The new ability changes how you cross an old room.
- A new route out of an area opens, usable only with the unlock.
- Collectibles sit just out of reach early and become reachable later.
- The world changes state (Hollow Knight's plague infesting the starting area).

Fast travel becomes necessary once revisits take more than a few minutes.

## Difficulty from combination, not twitch

Prefer "equipment checks" over "skill checks": keep individual platforms generous and let difficulty come from needing several abilities in sequence. Keep the base gap comfortably jumpable throughout the game so the player is never blocked by raw precision.

## Builds and loadouts

Abilities are usually always-on after unlock, but equipment slots with more options than slots create meaningful choice. Hollow Knight's charms are the model. Keep mandatory abilities out of slots, or players feel penalised for following the story.

## Multi-form abilities

One ability with several distinct forms can support varied backtracking: the same obstacle yields to different forms, so revisits feel like reinterpretation rather than repetition. The tradeoff is that form functions must be legible and environmental cues consistent, otherwise guidance suffers.

## Sources

- [Game Developer — The Foundation of Metroidvania Design](https://www.gamedeveloper.com/design/the-foundation-of-metroidvania-design)
- [Dreamnoid — How to create your own Metroidvania](https://dreamnoid.com/articles/how-to-create-your-own-metroidvania)
- [Hayao — Metroidvania design pillars](https://hayao.dev/docs/codex/genre-metroidvania)
- [Chalmers — Designing multi-mode player abilities for backtracking](https://odr.chalmers.se/items/d79d64a8-8f42-4b85-a4f8-5b1b259962b0)
- [Infinite Level — First person platforming / ability multifunctionality](https://www.infinitelevel.net/dev-blog/first-person-platforming)
- [Giant Bomb — Don't assume players are stupid (Closure conveyance)](https://giantbomb.com/articles/dont-assume-players-are-stupid)
- [Game Developer — Factoring game mechanics and player skill into level design](https://www.gamedeveloper.com/design/factoring-game-mechanics-and-player-skill-into-level-design)
