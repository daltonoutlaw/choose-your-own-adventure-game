# ADR: Addition of Italian Language Support

## Status
Accepted

## Context
The "Choose Your Own Adventure" (CYOA) game currently supports English, Spanish, and French. To expand the game's accessibility, we decided to add Italian as an additional supported language.

## Decision
We will add full Italian localization to the project. This involves:
1. Updating `language_data.json` with the complete set of required dictionary keys, race maps, occupation maps, and display mappings for Italian.
2. Updating the `Game.cs` startup menu to include Italian as a selectable language option.

## Rationale
- **Accessibility:** Expanding supported languages increases the potential user base and makes the game more inclusive.
- **Maintainability:** The project already utilizes a centralized `language_data.json` file and a `Messages` class, making the addition of a new language straightforward and consistent with the existing architectural patterns.
- **Low Risk:** The changes required are purely additive to the data structure and a minor update to the UI menu.

## Consequences
- **Positive:** Increased language support improves the user experience for Italian-speaking players.
- **Negative:** Slightly increased maintenance effort to ensure all new keys added in future updates are also translated into Italian.
- **Considerations:** Future-proofing: As the number of languages grows, we may need to revisit the current approach of loading all language data if the file size becomes a performance bottleneck or if memory usage becomes a concern, although it is not an issue at the current project scale.
