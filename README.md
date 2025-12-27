# ជូរអែម (Jou Em) - Temple Jungle Edition 🍎🏛️

[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-blue.svg?style=flat&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Standalone%20%7C%20WebGL%20%7C%20Android-orange.svg)](#)
[![Backend](https://img.shields.io/badge/Backend-Express.js-green.svg)](https://github.com/salxz696969/fruit-merge-backend.git)

A captivating fruit merging puzzle game inspired by the rich culture and landscapes of Cambodia, featuring traditional Khmer fruits in an ancient temple setting.

---

## 🎮 Game Overview

**ជូរអែម** is an engaging fruit merging puzzle game that reimagines the classic fruit merge mechanics within the mystical atmosphere of Cambodian temple jungles. Players control cascading fruits, merging them to evolve through a hierarchy of local flavors while exploring within ancient stone containers.

### Key Features

- 🇰🇭 **Fully Khmer Experience**: Complete Khmer language interface with traditional Khmer numerals
- 🍎 **6 Fruit Levels**: Progress through មៀន → សាវម៉ាវ → មង្ឃុត → ទៀប → ត្នោត → ធុរេន
- 🏛️ **Temple Jungle Theme**: Beautiful Cambodian-inspired backgrounds and atmosphere
- 📱 **Mobile Optimized**: Responsive design for all devices
- ⚡ **Physics-Based**: Realistic fruit physics and collision mechanics
- 🏆 **Global Leaderboard**: Compete with players worldwide
- 🎵 **Immersive Audio**: Temple-themed sound effects and ambient music

## 🎬 Demo Video

Watch the game in action! See the complete gameplay experience from start to finish:

<video src="./demo.mp4" controls width="720"></video>

## 🎯 How to Play

Merge identical fruits to evolve them into higher-level fruits and earn points:

- **មៀន + មៀន = សាវម៉ាវ** (+20 points)
- **សាវម៉ាវ + សាវម៉ាវ = មង្ឃុត** (+40 points)
- **មង្ឃុត + មង្ឃុត = ទៀប** (+80 points)
- **ទៀប + ទៀប = ត្នោត** (+160 points)
- **ត្នោត + ត្នោត = ធុរេន** (+320 points)

**Goal**: Achieve the highest score by strategic fruit placement and merging!

### The Fruit Hierarchy

From smallest to largest:

1. **មៀន (Longan):** The humble beginning - small, sweet, and easy to stack
2. **សាវម៉ាវ (Rambutan):** A spiky upgrade with more character
3. **មង្ឃុត (Mangosteen):** The Queen of fruits with royal purple skin
4. **ទៀប (Custard Apple):** Getting heavier and harder to manage
5. **ត្នោត (Palm Fruit):** Large, round, and takes up significant space
6. **ធុរេន (Durian):** The King of Fruits—the ultimate merge goal!

## 📱 Game Screenshots

<div align="center">

<table>
  <tr>
    <td>
      <img src="game-pic/image5.png" alt="Game Screenshot 5" width="180"><br>
      <sub>Welcome scene with play button, leaderboard button and info button</sub>
    </td>
    <td>
      <img src="game-pic/image4.png" alt="Game Screenshot 4" width="180"><br>
      <sub>Leaderboard scene showing score ranking with game id</sub>
    </td>
    <td>
      <img src="game-pic/image3.png" alt="Game Screenshot 3" width="180"><br>
      <sub>Info Scene</sub>
    </td>
    <td>
      <img src="game-pic/image2.png" alt="Game Screenshot 2" width="180"><br>
      <sub>Fruit merging mechanics in action and main gameplay scene</sub>
    </td>
    <td>
      <img src="game-pic/image1.png" alt="Game Screenshot 1" width="180"><br>
      <sub>Game over screen and final scoring</sub>
    </td>
  </tr>
</table>

</div>

## 🚀 Quick Links

### 🌐 Live Website

**[Play Online & Learn More](https://raksaoc.github.io/fruit-merge-website/)**

### 📱 Download Game

- **Android APK**: [Download jou-em.apk](./jou-em.apk)
- Or visit the [website](https://raksaoc.github.io/fruit-merge-website/) and click "ទាញយក" (Download)

## 🛠️ Technical Architecture

### Frontend (Unity)

- **Engine:** Unity 2022.3 LTS
- **Physics:** 2D Rigidbody and Circle/Polygon colliders for realistic fruit interactions
- **UI:** TextMesh Pro with custom font assets supporting Khmer glyphs and numerals
- **Localization:** Dedicated `KhmerNumerals` utility class for traditional Khmer characters (`០-៩`)
- **Audio:** AudioManager system with temple-themed sound effects

### Backend (Express.js)

- **API Routes:**
  - `POST /game`: Creates new game session with unique sessionId
  - `GET /game/leaderboard`: Retrieves global leaderboard rankings
  - `PUT /game/:sessionId/score`: Updates session score for persistence

### Tech Stack

- **Game Engine**: Unity 2022.3
- **Backend**: Express.js + Node.js
- **Database**: MongoDB
- **Frontend Web**: HTML5, CSS3, JavaScript
- **Mobile**: Android APK build

## 📂 Related Repositories

This project consists of multiple components working together:

| Repository         | Description                          | Link                                                                      |
| ------------------ | ------------------------------------ | ------------------------------------------------------------------------- |
| 🎮 **Game Client** | Unity game source code & assets      | [Fruit-Merge-Game](https://github.com/Neitong/Fruit-Merge-Game.git)       |
| 🖥️ **Backend API** | Express.js server & MongoDB database | [fruit-merge-backend](https://github.com/salxz696969/fruit-merge-backend) |
| 🌐 **Website**     | Marketing website & web game version | [fruit-merge-website](https://github.com/RaksaOC/fruit-merge-website.git) |

## 🎨 Art & Assets: AI-Generated Excellence

The visual identity was crafted through **advanced prompt engineering with Gemini AI**:

- **🏛️ Environment:** Misty ancient Khmer jungle with vine-covered temple ruins
- **🎨 UI/UX:** Stone-carved buttons and containers inspired by Angkor Wat architecture
- **🍎 Fruit Design:** Custom-generated assets reflecting realistic textures while maintaining vibrant, game-ready aesthetics
- **🖼️ Transparency:** All assets optimized with transparent backgrounds for seamless Unity integration

## 🎮 Game Scenes

- **Welcome Scene:** Serene jungle backdrop with ancient stone architecture
- **Play Scene:** Core physics-based gameplay arena with real-time Khmer score tracking
- **Game Over Scene:** Performance review with session statistics
- **Leaderboard Scene:** Global competitive rankings in traditional Khmer numerals
- **About Scene:** Project inspiration and development team information

## 👥 Development Team

**Created as part of 3rd Year Game Development Program at CADT University**

- **អោយ ច័ន្ទរក្សា** (Ory Chanraksa)
- **កែវ ហេងណៃតុង** (Keo Heng Neitong)
- **សៅ វិសាល** (Sao Visal)
  (Note: All members are involed in this repo's development implementation and ideation, due to conflict issues we worked through .zip files and single computer hence inconsistent commit history)

## 🎨 Cultural Inspiration

This game celebrates Cambodian culture through:

- **🍎 Traditional Fruits:** Native Cambodian fruits with authentic names and appearances
- **🏛️ Temple Architecture:** Ancient Khmer temple aesthetics inspired by Angkor Wat
- **🇰🇭 Language Localization:** Complete Khmer interface with traditional numerical system
- **🌿 Jungle Atmosphere:** Mystical temple jungle environment with cultural authenticity

## 🏆 Gameplay Features

### Core Mechanics

- **Physics-Based Dropping:** Realistic fruit physics with varied weights and bounce
- **Strategic Stacking:** Efficient space management within temple stone containers
- **Merge Evolution:** Transform fruits through 6-level hierarchy progression
- **Score Multipliers:** Higher-level merges yield exponentially more points

### Lose Conditions

- **Overflow Boundary:** Ancient jungle reclaims the session if fruits exceed container limits
- **Strategic Challenge:** Balance risk vs. reward in fruit placement decisions

---

<div align="center">

**Experience the mystical world of Cambodian temple jungles while enjoying classic puzzle gameplay!**

[🌐 Visit Website](https://raksaoc.github.io/fruit-merge-website/) | [📱 Download APK](https://raksaoc.github.io/fruit-merge-website/assets/jou-em.apk) | [🎮 View Game Code](https://github.com/Neitong/Fruit-Merge-Game.git)

_Created with ❤️ for preserving and celebrating Cambodian culture through interactive gaming_

</div>
