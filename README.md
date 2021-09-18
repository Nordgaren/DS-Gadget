
# DS Gadget (Local Loader)
Branch of TKGP's DS Gadget that loads locally accessible .txt files to populate various lists (bonfire, items, etc)
Resource .txt files are found in DS-Gadget\Resources

## Installing

* Extract contents of zip archive to its own folder. You may have to run as admin if DS Gadget crashes

## Updating

* If you have a previous version of DS Gadget Local Loader, you do not need to overwrite the resource folder with the updated resource folder unless specifically mentioned in the patch notes. Skipping the resource folder will retain any changes you have made to resources and saved positions.

### Local Loader Credits
* TKGP - Made DS Gadget
* Nordgaren - Implemented most of the new features

## DS Gadget (Local Loader) Changelog

### 3.0.0.74
Heal Timer updated to work on boosted HP (Ring of FAP, etc)

NG+ Cycle support. Can read and change NG+ cycle

Fixed a crash that randomly occurred on character load

Fixed an issue where DS Gadget couldn't find the SavedPositions.xml when launching from Windows Search results


### 3.0.0.73  
**Resources/Systems/Bonfires.txt and Resources/Equipment/Weapons/Shields.txt have been updated**  

* Swapped IDs for Ash Lake Entrance and Ash Lake Dragon  

* Fixed Bonewheel Shield, Spiked Shield, and Pierce Shield having incorrect infusion paths

Added heal timer cheat. When the player takes damage, start a timer fully heals the player when finished. Timer duration is user-defined, and resets when taking additional damage during its duration

Item menu "Max" checkbox now also sets item quantity to maximum

Quick Select Bonfire checkbox restores vanilla DS Gadget functionality of immediately changing your bonfire when one is directly selected from the bonfire list (Bonfire searching, arrow keys, and other misc selectors will not trigger quick select bonfire)

Keyboard functionality extended to player tab bonfire combo box and item tab infusion combobox (up, down, enter and escape)

Config now updates with player and adds temporary "unknown" configs to list if the game sets the player with an unknown config (If you see an unknown config and are playing an unmodified game, please tell us!)

### 3.0.0.72  
**If you have modified DSItemCategory and DSFashionCategory resources from v3.0.0.71, move them to "Resources/Equipment" after installing.**  

Added Bonfire search  

Added checkbox in items menu to always grant equipment at max reinforcement

Added checkbox in stats menu to apply changes made while a character is not loaded  
* Check the "Apply Changes" checkbox and any changes made will be applied on load  
* Escape to clear any changes you don't want made  
* Enter will give you a value of 0 on any numerical stat  

Added Team Config  
* Correctly loads the Chr and Team type for each existing combo.  
* Does not change phantom color as expected for some covenant variations, even though values are correct.
* Loaded from Resources/Systems/TeamConfigs.txt  

Last Warp Bonfire feature puts the last bonfire you warped to at the bottom of the list of bonfires.

Added "Search All" checkbox to items and misc menu.

Fixed an issue where DS Gadget couldn't find the Resource files when launching from Windows Search results.

Fixed program update checker.

### 3.0.0.71
Added saving stored positions to XML file which are loaded on DS Gadget Startup  
* Press the store position key or enter after typing a location name in the combo box for the stored position to save or update that positon.  
* Press Shift + Del or click the "Delete" button to delete the stored location.  
* XML file can be edited, but you must re-launch the gadget.  

Added fashion feature to Misc tab (Apply any armor or hair to hair slot)  

Added local category loading for Item and Fashion categories and split Ammo into it's own category.  
* Resources/DSItemCategory.txt is for the dropdown categories in Items tab, Resources/DSFashionCategory.txt is for the dropdown in the Misc tab for fashion.  
* Categories must consist of items of the same Category ID. For instance, Ranged Melee and Ammo all share the weapon category ID, so you could make a "Favorite Weapons" category that has a combination of those items. Current Item lists are all sorted into their respective category IDs as a guide.  
* Make sure to setup a new item list at Resources/Equipment/Category/YourNewCategory.txt for your category and copy-paste items from other lists to that new text file. Make sure your new category references the correctly named text file!  
* The order in the file is the order in the dropdown menu  

Added Toggle AI Hotkey.  

Gadget now allows you to change any setting that isn't loaded upon loading a character.  

Cleaned up Search Bar presentation and can now use Escape to clear search  

### 3.0.0.70
Added Search function.

### 3.0.0.69
Release. Added local file loading.



-------------------

# Original DS Gadget Readme
A multi-purpose testing tool for Dark Souls: Prepare to Die Edition. Compatible with the current Steam and debug versions as well as, in theory, everything else.  
Requires [.NET 4.6.2](https://www.microsoft.com/net/download/thank-you/net462) and [VC Redist 2012 x86](https://www.microsoft.com/en-us/download/details.aspx?id=30679)  
You probably already have both.

# Instructions 
Extract the entire Gadget folder to wherever you want, and run DS Gadget.exe.  
Once the game is running, Gadget will automatically attach; if the Version is displayed in green everything should work correctly.  
If it's orange, your game version isn't fully supported and some things may not work. I recommend finding a newer one.  
All features are disabled until you load a character (indicated by the Loaded text).  
When you shut down Gadget, active modifications like cheats and filters will be reset.

If you get the following error when using certain features, uninstall and reinstall the VC Redist linked above:  
`System.IO.FileNotFoundException: Could not load file or assembly 'Fasm.NET.dll' or one of its dependencies.`

# Credits
[Fasm.NET](https://github.com/ZenLulz/Fasm.NET) by Jämes Ménétrey

[LowLevelHooking](https://github.com/jnm2/LowLevelHooking) by Joseph N. Musser II

[Octokit](https://github.com/octokit/octokit.net) by GitHub

[PropertyHook](https://github.com/JKAnderson/PropertyHook) by Me

[Semver](https://github.com/maxhauser/semver) by Max Hauser

# Special Thanks
**Wulf2k**, for writing Gizmo and memlocs.ods, without which I would be nothing.

**AndrovT**, for figuring out how the heck event flags work.

**Meowmaritus**, for MeowDSIO, which was used to build the item lists.

**Pav**, for spoonfeeding me so many function pointers.

And all of the other wonderful people in the SpeedSouls discord.

# Changelog
### 3.0
* AOB scanning instead of hardcoded offsets, aka support for unofficial versions
* Play region editable for PVPfriends
* Character name, sex, and physique editable for debug elitists
* Covenant stuff editable
* Hair slot directly editable
* Bonfire names are less obtuse
* Hotkeys don't lag typing as much

### 2.3
* Add create item hotkey
* Search for game by window title, not filename
* Allow stamina editing
* Fix gestures button
* Fix filters

### 2.2
* Added a button to warp to last bonfire (like a bone, but a button)
* Options will only be reapplied when they're not in the default state (so if you leave them off, they won't conflict with Debug)
* Item spawner improvements
	* Spawned items now go straight into your inventory
	* You can spawn upgraded pyromancy flames
	* You can no longer infuse shields and crossbows with infusions they can't be infused with
	* Removed some items that didn't actually exist

### 2.1
* Added a button to unlock all gestures to Misc tab
* Added a very awkwardly-placed button to reset your hair slot to Internals tab, because flexing permanently hecks it up
* Added stored quantity (for quantity storage ^:) to Internals tab
* Fixed (probably) problems with aiming bows while No Death was on
* Fixed some misconfigured items

### 2.0
* Gadget now supports the debug version
* Fixed window seemingly disappearing forever sometimes
* Editing your stats will now update health and stamina properly
* New tab: Internals, with readouts for some random technical things you don't care about
* Added basic event flag reading and writing to the Misc tab

### 1.6
* Added new hotkeys: Quit to Menu, Move Up, Move Down, Toggle No Death
* Option to store HP with position now includes stamina and death cam state
* Said option is now in the Players tab where it should have been anyways
* Closing the app should no longer require quitting and loading to completely clear modifications
* Fix no death and speed being overwritten in some cases (heck off Manus)
* Fix crash if not connected to internet

### 1.5
* Camera state is now stored along with position
* Fixed body type being overwritten

### 1.4
* HP can now be edited
* Added option to store and restore HP along with position (ur welcome Milt :V)
* Fixed missing bonfire ID for Seath's prison (again)

### 1.3
* Hotkeys can be globally enabled or disabled
* Hotkeys can be passed to the game as well or not
* Hotkeys can be unbound with escape
* Cheats have tooltips now
* Fixed filter turning on when you close the app

### 1.2
* Permanent changes are now cleaned up on app exit; quit out to clear the rest
* App indicates if there's an update available
* Window position is saved
* Settings actually work now
* Ambiguous items like Firekeeper Souls are no longer ambiguous

### 1.1
* Fixed maxing your stats against your will

### 1.0
* Reorganized and expanded cheats
* Added phantom and team type
* Added missing Painted World respawn
