# Pilezy

## Overview

Pilezy is a casual mobile Match-3D puzzle game inspired by Triple Match 3D and Match Factory.

The project is intentionally scoped down for a solo indie developer.

The goal is NOT to compete with Match Factory.

The goal is to build a complete and publishable Match 3D mobile game.

---

# Core Gameplay

Players tap 3D objects from a cluttered pile.

Selected objects move into a dock.

When 3 identical objects exist in the dock:

- They are removed.
- The player earns points.

The level is completed when all objects are cleared.

The player loses when the dock becomes full.

---

# MVP Scope

Required Features:

- Tap selectable object
- Object moves to dock
- Match 3 identical objects
- Win condition
- Lose condition
- Level loading
- Basic UI

Not Required:

- Shop
- Booster
- Daily rewards
- LiveOps
- Multiplayer
- Physics simulation
- Procedural generation

---

# Platform

Primary Platform:

- Android

Orientation:

- Portrait

Engine:

- Unity 6
- Universal Render Pipeline (URP)

---

# Art Direction

Style:

- Simple colorful low-poly

Sources:

- Free assets
- Kenney
- Poly Pizza
- Unity Asset Store Free

Target Objects:

- Fruits
- Food
- Toys
- Household items

---

# Camera

Fixed camera.

Player cannot rotate camera.

Player only taps objects.

No advanced 3D controls.

---

# Dock System

Dock size:

7 slots

Example:

[ Banana ]
[ Apple ]
[ Banana ]
[ Apple ]
[ Banana ]

Result:

Remove 3 Bananas.

Remaining:

[ Apple ]
[ Apple ]

---

# Level Structure

Each level defines:

- Available item types
- Count per item type

Example:

Level 1

- Banana x9
- Apple x9

Level 2

- Banana x9
- Apple x9
- Orange x9

Objects are randomly distributed in a spawn area.

---

# Technical Architecture

Main Systems:

- InputManager
- Item
- DockManager
- MatchManager
- LevelManager
- UIManager

---

# Item

Each item contains:

- ItemType
- Collider
- Renderer

When clicked:

- Disable interaction
- Animate to dock

---

# Match Rules

If dock contains 3 identical ItemTypes:

- Remove all 3
- Update dock

---

# Lose Rules

If dock slot count exceeds limit:

- Lose

---

# Win Rules

If all level objects are cleared:

- Win

---

# Development Philosophy

Keep systems simple.

Prefer maintainable code over clever code.

Avoid overengineering.

Focus on shipping a playable version first.

MVP before optimization.

IMPORTANT:

Do not add extra systems that are not explicitly requested.

Always prefer the simplest working solution.

This project is developed by a solo indie developer and should remain small in scope.