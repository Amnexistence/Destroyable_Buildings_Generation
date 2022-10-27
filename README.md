# Destroyable_Buildings_Generation
Some Unity C# to generate destructible buildings (based on Asset Forge assets and Kenney Lua code).

HOW TO USE:
Add scripts and buildings assets files to your project. Create object with BuildGen script component. Set parameter limits for generated buildings in BuildGen and assets for generation (use prefab Variant versions).
The structure of Variants must match the structure of modules imported from Asset Forge (current assets as example). They must have a child with BuildModuleCollision script and additional components.

Additional (destroyable):
Building modules Rigidbody component must be IsKinematic. Building breaks on collides with an "Player" tagged object. Аfter hitting the "Ground" tagged object, building modules play a particle effect, after which the parent object that generated the building is removed from the scene. Particle Systems in modules should not have Play On Awake.
