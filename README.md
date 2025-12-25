# 🥭 ជូរអែម (Sour-Sweet): Temple Jungle Editioន

[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-blue.svg?style=flat&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Standalone%20%7C%20WebGL-orange.svg)](#)
[![Backend](https://img.shields.io/badge/Backend-Express.js-green.svg)](https://github.com/salxz696969/fruit-merge-backend.git)

An immersive, physics-based puzzle experience that blends the addictive "Suika" merge mechanic with the rich cultural heritage and lush landscapes of Cambodia.

---

## 📖 Introduction

**ជូរអែម** is a casual puzzle game inspired by classic fruit-merge mechanics, reimagined through the atmosphere of a Cambodian temple jungle. Players are tasked with managing a growing stack of exotic fruits, merging them to evolve through a hierarchy of local flavors, all while navigating the constraints of a stone-carved container. The game features full Khmer localization, using traditional Khmer numerals for scores and rankings to provide an authentic experience.

## 🎮 Gameplay Mechanics

### The Objective

The primary goal is to achieve the **highest possible score** by merging identical fruits. Each merge evolves the fruit into the next level of the hierarchy, granting points based on the size and rarity of the fruit created.

### Key Rules

- **Merge Logic:** When two fruits of the same type collide, they "pop" and transform into a single fruit of the next level.
- **Physics & Stacking:** Fruits have varied weights and bounciness. Efficient stacking is crucial to maximize space within the temple container.
- **Lose Condition:** The "Top Boundary" rule is in effect. If any fruit settles above the upper limit of the container for too long, the ancient jungle reclaimed the session—**Game Over**.

### The Fruit Hierarchy (6 Levels)

From smallest to largest:

1.  **Longan (មៀន):** The humble beginning.
2.  **Rambutan (សាវម៉ាវ):** A spikey upgrade.
3.  **Mangosteen (មង្ឃុត):** The Queen of fruits.
4.  **Custard Apple (ទៀប):** Getting heavier and harder to stack.
5.  **Palm Fruit (ត្នោត):** Large, round, and takes up significant space.
6.  **Durian (ធុរេន):** The King of Fruits—the ultimate merge goal!

## 🗺️ Game Scenes

- **Welcome Scene:** Features a serene jungle backdrop with ancient stone architecture and intuitive "Play" navigation.
- **Play Scene:** The core arena where physics and strategy meet. Includes real-time score tracking in Khmer numerals.
- **Game Over Scene:** A reflective space to view your final performance and session statistics.
- **Leaderboard Scene:** A competitive global stage showing the "All-Time" best players.
- **About Scene:** Background information on the project's inspiration and the development team.

## 🎨 Art & Assets: The AI Frontier

The visual identity of this project was forged through **vigorous prompt engineering with Gemini AI**.

- **Environment:** Backgrounds depict a misty, ancient Khmer jungle with vine-covered ruins.
- **UI/UX:** Buttons and containers are styled after heavy, moss-covered temple bricks and stone carvings.
- **Fruit Design:** Each fruit asset was custom-generated to reflect realistic textures (the spikey skin of the Rambutan, the thick rind of the Mangosteen) while maintaining a vibrant, game-ready aesthetic.

## ⚙️ Technical Architecture

### Frontend (Unity)

- **Engine:** Unity 2022.3.
- **Physics:** 2D Rigidbody and Circle/Polygon colliders for realistic fruit interactions.
- **UI:** TextMesh Pro with custom font assets supporting Khmer glyphs and numerals.
- **Localization:** Dedicated `KhmerNumerals` utility class to convert standard integers into traditional Khmer characters (`០-៩`) for UI display.

### Backend

The game is supported by a robust Express.js backend for data persistence and global competition.

- **Repository:** [fruit-merge-backend](https://github.com/salxz696969/fruit-merge-backend.git)
- **API Routes:**
  - `POST /game`: Securely creates a new game session and returns a unique `sessionId`.
  - `GET /all-time`: Retrieves the global leaderboard rankings.
  - `PUT /:sessionId/score`: Updates the score for an active session to prevent data loss.

## 👥 The Development Team

This project was designed and developed by:

- **Ory Chanraksa**
- **Keo Heng Neitong**
- **Sao Visal**

---

_Created as part of the Year-3 Game Development curriculum._
