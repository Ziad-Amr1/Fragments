# 01 — Shadow abilities for Fragments

## Recommendation

Make shadow the game's single core system rather than a list of unrelated powers. The girl is losing pieces of herself; the fragments she collects are pieces of her shadow. Darkness is where she is safe and strong; light is the pressure that forces her to keep moving. This gives every ability one shared rule, which makes a large ability set learnable.

**Core rule:** shadow is both a *place* and a *resource*. Dark zones refill Shade and allow shadow powers. Light zones drain Shade, suppress powers, and contain the enemies and traps that make escape urgent.

Do not remove the ordinary jump. Every ability must extend the base movement, never replace it — Aragami's critique is that a ninja could not cross a knee-high barrier without magic.

## Progression tree

Mandatory abilities, in unlock order. Each one is a key **and** a verb.

| # | Ability (code id) | Verb | Gate it opens | Other uses | Cost |
| --- | --- | --- | --- | --- | --- |
| 0 | Run / Jump / wall-free fall | move, jump | — | — | free |
| 1 | **Shadow Step** (`Dash`) | 8-way dash with afterimages | Shadow Gates (thin dark membranes) | dodge attacks, cross gaps, combo into jump | 1 Shade pip; refreshes on ground or shadow surface |
| 2 | **Shade Jump** (`DoubleJump`) | jump off a shadow puddle spawned underfoot | high ledges | mid-air recovery, extend Step | free; refreshes on ground |
| 3 | **Meld** (`Meld`) | merge into a shadow surface for a few seconds | barred grates, shadow vents | invisibility, immunity, fast Shade refill, ride moving shadows | drains Shade; ends on light exposure |
| 4 | **Echo** (`Echo`) | record ~3 s, shadow clone replays it | twin-switch doors | platform, pressure plate, distraction | 2 Shade pips |
| 5 | **Nightfall** (`Nightfall`) | extinguish lights in a radius briefly | light barriers, lit-only routes | make other powers usable under light, escape | all Shade, long cooldown |
| 6 | **Eclipse** (`Eclipse`) | full shadow form ~4 s: invulnerable, phase through gates and enemies, leave Meld-able trail | Void Walls | story payoff, cleanup and secrets | all Shade, very slow recharge |

Eclipse comes last because it replaces most other movement decisions. Ori's Launch ability is the precedent: powerful late-game movement is a reward; giving it early removes the variety of the rest of the game.

### Optional / side branch

Not required for the main path, but still meaningful because they gate optional fragments and shortcuts:

- **Umbra Pull** — grapple to shadow anchors (dark silhouettes on walls).
- **Shade Skin** — reduce damage taken while in light.
- **Afterimage** — Step leaves a decoy that draws one attack.
- **Wisp** — a tiny light that reveals hidden shadow surfaces.

Optional abilities should gate other optional content, which keeps the main route soft-lock free.

## Resource: Shade

- Introduce the meter at ability 3, not at the start. The first two powers stay free so early play is simple.
- Three pips is enough precision for dash/echo decisions without bookkeeping.
- Refill only in darkness and while Melded. Light drains one pip every few seconds.
- The girl's cloak is the indicator — dark and saturated when Shade is full, pale and translucent when empty. Celeste's hair colour does the same job for dash availability.
- Readability rule: never have two abilities with the same input and different hidden cooldowns. Hollow Knight's Shade Cloak does this and players regularly dash into enemies thinking it is ready. If phasing is wanted on the dash, make it an *upgrade to Shadow Step*, not a second dash button.

## Gate language

Each gate gets unique art and appears as a landmark early, before the player can pass it. When the matching ability is found, the player should immediately know where to return.

| Gate | Visual | Unlocked by |
| --- | --- | --- |
| Shadow Gate | dark rippling membrane | Shadow Step |
| High Ledge | unreachable platform with a fragment silhouette | Shade Jump |
| Barred Grate | light shining through iron bars | Meld |
| Twin Switch Door | two far-apart floor plates | Echo |
| Light Barrier | sweeping lamp beam / projector wall | Nightfall |
| Void Wall | pure black seam in a lit room | Eclipse |

Before shipping a gate, run a negative proof: simulate the best possible maneuver with only earlier abilities and confirm the geometry cannot be bypassed.

## Example level beats

1. **Escape start** — safe room, no text. A fall teaches instant respawn; a rumbling block teaches that the world can hurt you.
2. **First fragment** — pickup triggers Shadow Step. The exit is a Shadow Gate. No instructions; the membrane visibly ripples when she gets close.
3. **Practice chain** — three rooms, increasing gap width, no stakes, immediate retry.
4. **Combination room** — Step into a wall, Shade Jump off the afterimage to reach a ledge.
5. **Backtrack room** — the Shadow Gate from the start now opens a shortcut and a hidden fragment. The revisit pays.
6. **Light patrol room** — lamps sweep across shadow patches, forcing the player to time Step between them (Aragami's archer arrows do this).

## Feedback per ability

| Ability | Visual | Audio / feel |
| --- | --- | --- |
| Shadow Step | afterimages, cape darkens, 1-frame freeze | whoosh + impact |
| Shade Jump | shadow puddle under feet, dust puff | soft pop |
| Meld | screen edges darken, silhouette ripple, beams slide off | low hum |
| Echo | recording ring, desaturated clone outline | sync ping on playback |
| Nightfall | lamps snuff out in sequence | audio dropout |
| Eclipse | full desaturation, persistent trail | echoing heartbeat |

Make screen shake and flashes optional (accessibility).

## Risks and mitigations

| Risk | Mitigation |
| --- | --- |
| Too many verbs | one mandatory unlock per biome; optional abilities stay on side paths |
| Two similar dashes | upgrade Shadow Step instead of adding another dash |
| Over-powered mobility | keep generous real jumps; gates need negative proofs |
| Puzzle fatigue | each biome tests a new *combination*, not more of one trick |
| Lost setups | instant reset key and frequent checkpoints (Closure's lesson) |
| Unclear ability state | cloak indicator plus distinct particle colour per ability |

## Mapping to current code

- `AbilityId` already contains `Dash`, `DoubleJump`; add `Meld`, `Echo`, `Nightfall`, `Eclipse`. Keep the existing ids for the first two and treat the shadow names as their in-fiction names.
- Add `ShadowAbility : PlayerAbility` with `shadeCost` and `requiresDarkness`.
- `AbilityManager` should own `ShadeEnergy` and expose `TrySpend` / `IsInShadow`, so abilities do not reference each other.
- Add `ShadowZone` / `LightZone` triggers feeding a `ShadowEnvironment` query.
- Add `ShadowGate` checking `AbilityManager.IsUnlocked(...)` — the write-side gate to complement `FragmentCollectible`.
- `FragmentCollectible` already unlocks abilities on trigger; no rewrite needed.

## Sources

Ideas are synthesised from the referenced games in [03 — Shadow mechanics reference](../notes/03-shadow-mechanics-reference.md), with progression rules from [02 — Ability and progression design](../notes/02-ability-progression.md) and feel rules from [01 — Platformer game feel](../notes/01-platformer-game-feel.md).
