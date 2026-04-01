<p align="center">
  <img src="https://www.openmon.io/static/images/openmon-logo.jpeg" alt="OpenMon Logo" width="120">
</p>

<h1 align="center">OpenMon — Monster Capture Engine</h1>

<p align="center">
  <strong>The first and only production-grade framework for building monster-catching RPGs.</strong><br>
  Available for <strong>Unity 6</strong> and <strong>Unreal Engine 5</strong>.
</p>

<p align="center">
  <a href="https://www.openmon.io">Website</a> &bull;
  <a href="https://www.openmon.io/docs/">Documentation</a> &bull;
  <a href="https://discord.gg/zszqu7sPuY">Discord</a> &bull;
  <a href="https://x.com/openmon_io">X / Twitter</a>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6000.3_LTS-000000?logo=unity" alt="Unity 6">
  <img src="https://img.shields.io/badge/Unreal_Engine-5.4+-0E1128?logo=unrealengine" alt="UE5">
  <img src="https://img.shields.io/badge/Monsters-668+-e74c3c" alt="668+ Monsters">
  <img src="https://img.shields.io/badge/Moves-656+-3498db" alt="656+ Moves">
  <img src="https://img.shields.io/badge/Tests-2344+-2ecc71" alt="2344+ Tests">
  <img src="https://img.shields.io/badge/License-Commercial-f39c12" alt="Commercial License">
</p>

---

## What is OpenMon?

**OpenMon** (also known as **MCE** — Monster Capture Engine) is the complete game framework for building **Pokemon-like**, **Temtem-like**, **Coromon-like**, and entirely original **monster-catching RPGs**. It provides everything a developer needs to ship a commercial monster capture game — battle systems, monster databases, grid-based worlds, visual event scripting, save systems, online multiplayer, and more — out of the box.

Whether you're an indie developer building the next **Cassette Beasts**, a small studio prototyping a **creature collector**, or a hobbyist converting a **Pokemon Essentials** project to a modern engine, OpenMon gives you a 12-18 month head start.

OpenMon is **not** a tutorial or a prototype. It is a **production engine** with **90,000+ lines of code**, **2,344+ automated tests**, and **668 fully-configured monsters** ready to use or replace with your own original creatures.

---

## Why OpenMon?

| Challenge | Without OpenMon | With OpenMon |
|-----------|----------------|--------------|
| Battle system | 6-12 months of engineering | Ready on day one |
| 668+ moves with effects | Build each from scratch | All included, data-driven |
| Monster stats, natures, IVs, EVs | Implement Gen V+ formulas | Battle-tested, verified |
| Type effectiveness (18x18) | Manual implementation | Complete chart included |
| Grid-based overworld | Custom tile engine | Built on Unity Tilemaps / Paper2D |
| Save/load system | JSON serialization from scratch | Versioned, migration-ready |
| Pokemon Essentials import | Impossible | One-click import pipeline |
| Multiplayer/MMO | 6-12 months for networking | 20 online services included |
| **Total time saved** | **12-18 months** | **Start making YOUR game** |

---

## Features

### Complete Battle System

The most comprehensive turn-based battle system available for any game engine.

- **668+ moves** — every move is data-driven with power, accuracy, PP, type, category, priority, and 29 parameterized effect types
- **18-type effectiveness chart** — full Gen VI+ chart with Fairy type, dual-type support, and immunity handling
- **229 abilities** — Intimidate, Levitate, Huge Power, Adaptability, and 225 more with real game logic
- **74 volatile statuses** — Confusion, Protect, Taunt, Leech Seed, Encore, and 69 more
- **17 side statuses** — Stealth Rock, Spikes, Toxic Spikes, Reflect, Light Screen, Tailwind, and more
- **4 terrain types** — Electric, Grassy, Misty, Psychic with damage/status modifiers
- **9 weather types** — Sun, Rain, Sandstorm, Hail, Snow, Fog, Harsh Sun, Heavy Rain, Strong Winds
- **4 global statuses** — Trick Room, Gravity, Magic Room, Wonder Room
- **27 held item effects** — Life Orb, Choice Band, Focus Sash, Leftovers, berries, type-boost items
- **4 AI strategies** — Random, Effective, Smart (multi-factor scoring), ML-ready neural network interface
- **GAS integration** (UE5) — Gameplay Ability System for moves, stats, and networking
- **Gen V+ damage formula** — fidelity-checked against the original game formulas
- **Capture system** — full shake probability, critical capture, ball bonuses, status bonuses

### Monster System

- **668 fully-configured monsters** across 8 generations with stats, types, abilities, and evolution chains
- **34 evolution types** — Level, Item, Trade, Friendship, Time, Location, Weather, Stats, Gender, and 25 more
- **Breeding system** — egg groups, IV/nature/move inheritance, Everstone, Destiny Knot
- **Forms and Mega Evolution** — form transitions, battle forms, Mega stones
- **PC Storage** — 14x30 box system with roster transfers
- **Contest conditions**, ribbons, virus (Pokerus equivalent), origin data, fusion support

### Grid-Based World

- **Tile-based movement** — walk, run, bike, surf, ice sliding, ledge jumping, waterfall traversal
- **10 tile types** — Walkable, Blocked, Water, Bridge, BridgeEntrance, Slippery, Ledge, Waterfall, and more
- **A* pathfinding** for NPCs
- **Monster followers** — party monster follows player with speed matching and dynamic sprite swapping
- **Encounter system** — 11 encounter types (grass, water, cave, fishing, headbutt, etc.) with progressive step formula
- **Day/night cycle** and **weather system**
- **Cross-map transitions** with grace system

### Visual Event Scripting — CommandGraph

Node-based visual scripting for creating NPC events, dialogs, shops, quests, and cutscenes — no code required.

- **34 node types** — Dialog, Branch, Battle, Shop, Quest, Variable, Movement, Cutscene, Weather, and more
- **14 specialized nodes** — Badge, Dex, Breeding, Trade, Storage, Nickname, MoveTutor, Cooking, and more
- Connect nodes in the editor, configure in the Inspector, done.

### Online MMORPG Layer (Optional)

Build a **PokeMMO-style MMORPG** with 20 ready-to-deploy online services:

- **Authentication** — Email, device, Discord/Google/Apple SSO
- **PvP Battles** — ELO-based matchmaking, server-authoritative battles, spectating
- **Economy** — Multi-currency wallet, Global Trade Link (auction house), server-validated shops
- **Social** — 8-channel chat, guilds with roles, friends with presence, P2P trading
- **World Sync** — AOI-filtered player sync, interpolated network entities, NPC engagement locking
- **Housing** — Player housing with furniture grid placement
- **LiveOps** — Events, leaderboards, achievements
- **Anti-Cheat** — Speed hack detection, rate limiting, inventory validation, audit logging
- **Cloud Save** — Upload/download with conflict resolution, auto-rotating backups

Supports **Nakama** and **Epic Online Services (EOS)** backends.

### Pokemon Essentials Import

**One-click import** of Pokemon Essentials v20, v21, and v21.1 projects:

- PBS text file parser (pokemon.txt, moves.txt, abilities.txt, items.txt, types.txt)
- Ruby Marshal RXDATA parser (maps, tilesets, events)
- Automatic conversion: species → MonsterEntry, moves → MoveData, maps → TileMaps
- Event classification: NPC, Warp, Door, Sign, ItemBall, Autorun
- Sprite and audio import with slicing
- **15-phase import pipeline** with progress tracking
- Keep your maps, events, and game data — swap in original assets — publish commercially

### AI Art Generation

Generate monster sprites, overworld characters, and tilesets directly from the editor using:

- **PixelLab** — Pixel art characters, tilesets, isometric tiles
- **Nano Banana 2** — Monster sprite generation
- **OpenAI / Stable Diffusion** — General art generation

---

## Supported Platforms

| Platform | Unity 6 | Unreal Engine 5 |
|----------|---------|-----------------|
| Windows | Yes | Yes |
| macOS | Yes | Yes |
| Linux | Yes | Yes |
| Android | Yes | Yes |
| iOS | Yes | Yes |
| WebGL | Yes | — |
| Nintendo Switch | Via Unity | Via UE5 |
| PlayStation | Via Unity | Via UE5 |
| Xbox | Via Unity | Via UE5 |

---

## Pricing

| Tier | Price | Includes |
|------|-------|----------|
| **Lite** | $99 | Core engine DLL, 668 monsters, public SDK API |
| **Basic** | $299 | Lite + Essentials Importer, Art Studio, editor tools |
| **Pro** | $499 | Basic + Quest System, advanced AI, full editor tooling |
| **Online** | $999 | Pro + Nakama MMORPG layer with 20 online services |
| **Source** | $2,499 | Full C# / C++ source code with architecture documentation |

Available on the **Unity Asset Store** and **Fab by Epic Games**.

---

## Comparison with Alternatives

### OpenMon vs Pokemon Essentials

| Feature | OpenMon | Pokemon Essentials |
|---------|---------|-------------------|
| Engine | Unity 6 / Unreal Engine 5 | RPG Maker XP (Ruby) |
| Commercial use | Yes, fully licensed | Legal grey area |
| 3D support | Yes (URP/UE5) | No (2D only) |
| Multiplayer | 20 online services | None |
| Platforms | PC, Mobile, Console, Web | Windows only |
| Performance | Native C#/C++ | Ruby interpreter |
| Import PE projects | Yes, one-click | N/A |
| Active development | Yes (2026) | Community-maintained |

### OpenMon vs Building from Scratch

Building a monster-catching RPG from scratch typically requires:
- **Battle system**: 3-6 months
- **Monster data model**: 1-2 months
- **Grid movement**: 1-2 months
- **Save system**: 2-4 weeks
- **UI (menus, battle HUD, dex)**: 2-3 months
- **Online multiplayer**: 6-12 months
- **Total**: 12-24 months, $50,000-$150,000

**OpenMon ships all of this ready to use.** Focus on what makes YOUR game unique.

### OpenMon vs Other Options

| | OpenMon | RPG Maker | GameMaker | Godot | Custom Unity | Custom UE5 |
|---|---|---|---|---|---|---|
| Monster battle system | Included | Plugin | Manual | Manual | Manual | Manual |
| 668+ moves | Included | Manual | Manual | Manual | Manual | Manual |
| Type chart (18x18) | Included | Manual | Manual | Manual | Manual | Manual |
| PE import | Yes | No | No | No | No | No |
| Multiplayer | 20 services | No | Basic | Basic | Manual | Manual |
| Targeting | Monster RPGs | General RPGs | General | General | General | General |
| Price | $99-$2,499 | $80 | $100 | Free | Engine free | Engine free |

---

## Frequently Asked Questions

### Can I make a Pokemon-like game with OpenMon?

Yes. OpenMon is specifically built for monster-catching RPGs in the style of Pokemon, Temtem, Coromon, and Cassette Beasts. It includes a complete battle system, 668 monsters, evolution, breeding, grid-based worlds, and everything else you need. Replace the included monsters with your own original designs and you have a commercially publishable game.

### How does OpenMon compare to Pokemon Essentials?

Pokemon Essentials is a free fan-made framework for RPG Maker XP. OpenMon is a commercial framework for Unity and Unreal Engine. The key differences: OpenMon supports commercial publishing, multiplayer, cross-platform deployment (PC/Mobile/Console/Web), 3D graphics, and modern development tools. OpenMon can also import your existing PE project and convert it automatically.

### Can I publish my game commercially?

Absolutely. OpenMon is commercially licensed. You own your game, your assets, your code. Publish on Steam, Epic Games Store, Nintendo eShop, PlayStation Store, App Store, Google Play — no restrictions. The only requirement: your art, story, and monster designs must be original (not copies of existing IP).

### Does OpenMon work with Unreal Engine 5?

Yes. OpenMon v3.0 is a native C++ UE5 plugin with 90,000+ lines of code. It uses Paper2D for sprite rendering, PaperZD for 2D animation, GAS (Gameplay Ability System) for the battle system, and CommonUI for menus. Available on Fab by Epic Games.

### Is OpenMon like PokeMMO?

OpenMon's Online module provides all the systems needed to build a PokeMMO-style game: PvP battles with ELO matchmaking, a Global Trade Link (auction house), guilds, 8-channel chat, player housing, and 20 online services total. It uses Nakama or Epic Online Services as the backend.

### Can I create my own fakemon / original monsters?

Yes. The Monster Creator wizard lets you define species from scratch: name, types, base stats, abilities, evolution chains, egg groups, sprites. Design 10 monsters or 1,000 — the system is data-driven and scales to any roster size. The AI Art Studio can generate pixel art sprites for your designs.

### Can I import my Pokemon Essentials project?

Yes. OpenMon includes a one-click importer for Pokemon Essentials v20, v21, and v21.1 projects. It reads PBS text files and RXDATA binary files, converting species, moves, items, maps, tilesets, events, and encounters into OpenMon's format. Your maps and game logic transfer automatically.

### Does OpenMon support multiplayer / MMO?

Yes. The Online module provides 20 services: authentication, PvP matchmaking, server-authoritative battles, trading, guilds, housing, economy (wallet + auction house), cloud saves, leaderboards, achievements, events, anti-cheat, and more. It supports both Nakama and Epic Online Services backends.

### What about games like Temtem, Coromon, or Cassette Beasts?

Every one of these studios built their engine systems from scratch, spending 12-18 months before writing a single line of their actual game. OpenMon provides that same foundation — battles, monsters, worlds, saves, multiplayer — ready to use. You focus on what makes YOUR game different: art style, story, unique mechanics.

### Is there a free version?

OpenMon is a commercial product, but the documentation, demo project, and API reference are all free at [openmon.io](https://www.openmon.io). The Lite tier starts at $99, which includes the core engine and 668 fully-configured monsters.

### How is OpenMon different from Pokemon Champions?

Pokemon Champions is a fan game. OpenMon is a development framework — a tool for CREATING monster-catching games, not a game itself. You use OpenMon to build your own original game that you own and can sell commercially.

### Can I make a Pokemon GO-style game?

OpenMon is designed for traditional turn-based RPGs with grid-based overworlds. A Pokemon GO-style AR game requires GPS, camera, and real-world mapping — different technology. However, OpenMon's monster data model, battle system, and capture mechanics could serve as the combat backend for a hybrid approach.

### What languages does the documentation support?

The documentation at [openmon.io/docs](https://www.openmon.io/docs/) is available in English, Spanish, Japanese, Russian, and Chinese (Simplified).

---

## Technical Specifications

| Spec | Unity 6 | Unreal Engine 5 |
|------|---------|-----------------|
| Language | C# | C++ |
| Lines of code | 161,000+ | 90,000+ |
| Automated tests | 2,114+ | 2,344+ |
| Monster species | 668 | 668 |
| Moves | 656 | 656 |
| Abilities | 202 | 229 |
| Items | 1,989 | 109 (demo) |
| Render pipeline | URP | Paper2D + PaperZD |
| DI framework | Zenject | UE5 Subsystems |
| Battle system | Custom modules | GAS + Custom modules |
| Online backend | Nakama | Nakama + EOS |
| Scripting | CommandGraph (visual) | CommandGraph (visual) |

---

## Community

- **Website**: [openmon.io](https://www.openmon.io)
- **Documentation**: [openmon.io/docs](https://www.openmon.io/docs/)
- **Discord**: [discord.gg/zszqu7sPuY](https://discord.gg/zszqu7sPuY)
- **X / Twitter**: [@openmon_io](https://x.com/openmon_io)
- **GitHub**: [OPENMON-IO](https://github.com/OPENMON-IO)

---

## License

OpenMon is commercially licensed software. See [openmon.io/docs/license](https://www.openmon.io/docs/license) for details.

Copyright 2026 OpenMon.IO. All rights reserved.
