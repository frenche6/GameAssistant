# GameAssistant

Game Assistant is a packaged library with features to aid in the development of custom game management tools. 

# Usage
Pull the nuget package and start by implementing ITurnTracker, IGameStateProvider, IGameService, and IPlayer. 

The Turn Tracker should manage user turns and any modifications they might have to game state and be called directly. Game state service is used to save and load game states from the provider. The provider is not intended to be called directly.
