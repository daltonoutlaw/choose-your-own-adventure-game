# Product Requirements Document (PRD): Merchant Interaction Feature

## 1. Overview
The Merchant Interaction feature introduces a non-combat encounter for the player when navigating south. This feature adds depth to the game world by providing the player with an opportunity to upgrade their equipment (weapon or armor) before facing the dragon in the north.

## 2. Goals
- Introduce a friendly merchant interaction.
- Offer the player a choice between two free equipment upgrades.
- Replace the player's existing equipment with the selected upgrade.
- Enhance player engagement and strategic choice.

## 3. Requirements

### 3.1 Functional Requirements
- **Trigger**: Choosing the "south" path in the adventure menu triggers the merchant encounter.
- **Interaction**: The player is presented with a dialogue introducing the merchant and offering a choice:
    1. Magical Weapon (+5 damage, upgrades existing weapon type).
    2. Magical Armor (provides protection points).
    3. Neither (decline upgrade).
- **Outcome**:
    - Selecting "Magical Weapon" replaces the player's current weapon with a "Magical" version with increased damage.
    - Selecting "Magical Armor" equips the player with "Magical Armor".
    - Selecting "Neither" continues the game without changes.
- **Persistence**: The player's updated weapon/armor must be reflected in their character stats (`DisplayStats`).

### 3.2 Non-Functional Requirements
- **Language Support**: All merchant dialogue must be supported in English, Spanish, French, and Italian, matching existing localization patterns in `language_data.json`.
- **Maintainability**: The implementation should follow the existing C# architectural patterns in the codebase.
- **Reliability**: The new functionality must not break existing game flow or combat mechanics, verified by unit tests.

## 4. Design & Implementation
- **New Classes**:
    - `Armor.cs`: Models armor with `Type` and `Protection` properties.
- **Model Updates**:
    - `Player.cs`: Added `Armor` property and updated `DisplayStats` to include armor information.
- **Game Logic Updates**:
    - `Game.cs`: Implemented `HandleMerchantEncounter` to manage the interaction loop and equipment assignment.
    - `Game.cs`: Updated `StartGame` navigation to invoke the merchant encounter on "south" selection.
- **Content Updates**:
    - `language_data.json`: Added new localized strings for merchant interaction.

## 5. Testing & Validation
- **Unit Testing**: New test class `MerchantTests.cs` verifies correct equipment replacement logic.
- **Regression Testing**: Existing suite (`CYOATests`) ensures no impact on core game functionality.
