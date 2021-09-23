# This version of DS Gadget has been created for InfernoPlus' "Remastest" mod and contains various changes to item lists.
A multi-purpose testing tool for Dark Souls: Prepare to Die Edition. Compatible with the current Steam and debug versions as well as, in theory, everything else.  
## Requirements 
* [.NET 4.6.2](https://www.microsoft.com/net/download/thank-you/net462)
* [VC Redist 2012 x86](https://www.microsoft.com/en-us/download/details.aspx?id=30679)  

You probably already have both.

## Installing

* Extract contents of zip archive to it's own folder. You may have to run as admin if DS Gadget crashes

## Updating

* If you have a previous version of DS Gadget Local Loader with a Resource folder, there is no need to copy the resource folder over, unless noted in the patch notes. This prevents you from overwriting the changes you made and the saved positions you stored.

## Troubleshooting
If you are having problems getting it to launch and you tried installing the packages above, right click the exe, go to properties, hit the compatability tab and hit "Run compatability troubleshooter". If it works, apply the settings windows found.  

You can also try adding DS Gadget as an exception to your antivirus

#### Based on [DS-Gadget 3.0](https://github.com/JKAnderson/DS-Gadget) by JKAnderson.
#### Fork of [DS-Gadget 3.0 Local Loader](https://github.com/kingborehaha/DS-Gadget) by King Borehaha.
#### Updated by [Stagmattica](https://github.com/Stagmattica) until Prerelease 0.5.
#### Updated by [Nordgaren](https://github.com/Nordgaren) from Prerelease 0.6 onward.

## Thank You
**[TKGP](https://github.com/JKAnderson/)** Author of DS Gadget and answering my dumb questions  
**[King Borehaha](https://github.com/kingborehaha/)** Implimenting features, great suggestions and helping to polish my features  
**[InfernoPlus](https://github.com/infernoplus/)** Author of Dark Souls Remastest, also answers my dumb questions :fatcat:  
**[Stagmattica](https://github.com/Stagmattica)** Helped me get started with DS Gadget   

# Change Log  
### Prerelease 0.14.5.1
**Update to Resources/Equipment/Weapons/MeleeWeapons.txt**

* Fixed Stick and Four King Sword IDs  

### Prerelease 0.14.5
* **Update to Resources/Equipment/Weapons/MeleeWeapons.txt, Resources/Equipment/Armor/DarkSouls2Armor.txt, Resources/Equipment/DSItemCategories.txt, and Resources/Equipment/DSFashionCategories.txt**

* NG+ support in the misc tab. Allows user to modify NG+  

* Added 4 king sword and stick to weapons  

* Added color selector for eyes and hair in Misc.  

* Unhid DS2 armors.  

* Added more options for the fashion menu in Misc.  

* Fixed rare crashing bug  

* Fixed Saved Positions not loading if DS Gadget launched from Windows Search

###  Prerelease 0.14.4.2)  
* Hotfix for Heal Timer which allows the heal timer to heal to full HP when HP is buffed  

* Heal timer saves value  

* Bug hunting code - If you get a pop up about a log file, please post said log file to the Issues page (It will be in your DS Gadget Folder) 

###  Prerelease 0.14.4)  
**Update to Resources/Systems/Bonfires.txt, Resources/Equipment/Rings/Rings.txt, Resources/Equipment/Items/Spells.txt, Resources/Equipment/Items/UsableItems.txt, /Equipment/Weapons/SpellTools.txt and Resources/Equipment/Weapons/Shields.txt**  
* Added heal timer cheat. When the player takes damage, start a timer fully heals the player when finished. Timer duration is user-defined, and resets when taking additional damage during its duration

* Item menu "Max" checkbox now also sets item quantity to maximum

* Quick Select Bonfire checkbox restores vanilla DS Gadget functionality of immediately changing your bonfire when one is directly selected from the bonfire list (Bonfire searching, arrow keys, and other misc selectors will not trigger quick select bonfire)

* Keyboard functionality extended to player tab bonfire combo box and item tab infusion combobox (up, down, enter and escape)

* Config now updates with player and adds temporary "unknown" configs to list if the game sets the player with an unknown config (If you see an unknown config and are playing an unmodified game, please tell us!)

* Bonfires.txt updated so that Ash Lake Entrance and Ash Lake Dragon are no longer swapped  

* Spells.txt, Spelltools.txt, UseableItems.txt and Rings.txt updated to reflect vanilla item names in parenthesis  

* Shields.txt Fixed Bonewheel Spiked and Pierce Shield having incorrect infusion paths.  

###  Prerelease 0.14.3)
**Spells.txt and Rings.txt updated**

* Added TTT items  

* Added 1.4 beta items  

###  Prerelease 0.14.2.7)

* Minor patch, now up to date with Vanilla Gadget. 

* Max upgrade unchecked now gives you min upgrade for all items

###  Prerelease 0.14.2.6):

* "Search All" functionality added to Item and Fashion search boxes courtesy of [King Borehaha](https://github.com/kingborehaha/)

###  Prerelease 0.14.2.5):

* Fixed loading saved stats.... Hopefully...

###  Prerelease 0.14.2.4):

* Code improvemnt, fixed release packing internally.

###  Prerelease 0.14.2.3):

* Fixed formatting error in Item and Fashion dropdown categories

###  Prerelease 0.14.2.3):

* Fixed bug where DS Gadget would load all stats at min value if Load stats checkbox was checked and values weren't changed  

###  Prerelease 0.14.2):

* Fixed an issue where DS Gadget couldn't find files after launching from Windows search.  

**Thank You [King Borehaha](https://github.com/kingborehaha/) for:**
* "Last Set" Bonfire feature puts the last bonfire you warped to at the bottom of the list of bonfires
* Various bugfixes and minor improvement on the code side
* Code Cleanup and Bug fixes
* Fixed version checking

###  Prerelease 0.14.1):

* Saved stats improvement and various minor bugfixes 
* UI improvements for 0.14 features by [King Borehaha](https://github.com/kingborehaha/)
* * Fixed an issue where DS Gadget couldn't find files after launching from Windows search (0.14.2.1).

###  Prerelease 0.14): 

**If you already have changes to your DSItemCategory and DSFashionCategory text files, you can move them to Resources/Equipment after installing. I changed where the Gadget looks for them.**  

* Added Bonfire search  

* Added Team Config  
	* Correctly loads the Chr and Team type for each existing combo.  
	* Does not change to correct color for covenant, even though correct value. I think the mtd gets changed on invasion  
	* Loaded from Resources/Systems/TeamConfigs.txt  

* Can now get max upgrade items with a checkbox, instead of typing it in all the time  

* Stats menu now has a checkbox to apply any changes to your character made while character is unloaded  

* Cleaned up Search Bar presentation and can now use Escape to clear search  

###  Prerelease 0.13): 

* Added saving stored positions to XML file which are loaded on DS Gadget Startup

    * Press the store position key or enter after typing a location name in the combo box for the stored position to save or update that positon.
    * Press Shift + Del or click the "Delete" button to delete the stored location.
    * XML file can be edited, but you must re-launch the gadget.

* Merged with [DS-Gadget 3.0 Local Loader](https://github.com/kingborehaha/DS-Gadget). Item lists and categories now editable via a text file in Resources folder.  

* Added local category loading for Item and Fashion categories and split Ammo into it's own category.

    * Resources/DSItemCategory.txt is for the dropdown categories in Items tab, Resources/DSFashionCategory.txt is for the dropdown in the Misc tab for fashion.
    * Categories must consist of items of the same Category ID. For instance, Ranged Melee and Ammo all share the weapon category ID, so you could make a "Favorite Weapons" category that has a combination of those items. Current Item lists are all sorted into their respective category IDs as a guide.
    * Make sure to setup a new item list at Resources/Equipment/Category/YourNewCategory.txt for your category and copy-paste items from other lists to that new text file. Make sure your new category references the correctly named text file!
    * The order in the file is the order in the dropdown menu

* Added Toggle AI Hotkey.

* Gadget now allows you to change any setting that isn't loaded upon loading a character.

###  Prerelease 0.12): 
* Search bar now fully operational. you can use up and down keys to select and item in the listbox and enter to spawn that item. Works on hair as well, but applies hair instead of spawning items.

###  Prerelease 0.11): 
* Added search bar
* Hid DS2 armors until they are ready

###  Prerelease 0.10): 
* Added Hair tool to Misc tab  
* Added indicator for male and female only armor  
* Added Male and Female Hair category to Hair tool  
* DS Gadget now checks if up to date or not  

###  Prerelease 0.9):
* Gave ammo their own menu
* Prefixed ammo with type for better sorting

###  Prerelease 0.8):
* Added Dark Souls 2 armors
* Separated armors into categories


###  Prerelease 0.7):
* Fixed some armors not being upgradeable


###  Prerelease 0.6):
* Added Demon Souls Armors
* Added Blunt and Splintering Bolts
* Added new 1.3 spells
* Re-added the Master Key


###  Prerelease 0.5):
* Disabled the version indicator turning orange to avoid confusion.


###  Prerelease 0.4):
* Various bug fixes
* Removed the "Master Key" Key item, due to it having lost its purpose.
* Moved "Eye of Death" and "Cracked Red Eye Orb" consumables to "Usable Items" tab for consistency across invasion-based items.
* Renamed the "Cat Covenant Ring" to "Bandit Ring".


###  Prerelease 0.3):
* Bug fixes
* Some changes from Prerelease 1.1 did not function properly: Rename of "Black Eye Orb(s)" did not function properly due to character limit, name shortened; Fix of "Skull Lantern bug" not working due to restrictions within item category definitions. "Skull Lantern" has been moved to "Melee Weapons" item category.


###  Prerelease 0.2):
* Fixed title bar version counter
* Fixed a target mismatch between the Bonfires "Ash Lake (Bonfire)" and "Ash Lake (Stone Dragon)"
* Fixed a bug that caused the "Skull Lantern" item to not spawn for some players
* Renamed the unused "Gwynevere Talisman" and "Miracle: Escape Death" descriptors
* Renamed "Black Eye Orb" to "Black Eye Orb (Target: Lautrec of Carim)" and "Black Eye Orb (Shiva)" to "Black Eye Orb (Target: Shiva of the East) (Cut Content)"
* Renamed "Sunlight Spear" spell to "Sunlight Slam"
* Moved "Black Eye Orb (Target: Shiva of the East) (Cut Content)" from "Key Items" to "Usable Items_


###  Prerelease 0.1):
* Removed version indicator on main window title bar (will be added back in future releases)
* Removed "Mystery Armor", "Mystery Weapons" and "Mystery Goods" item lists
* Moved "Elite Cleric" and "Mage Smith" Armor sets to "Armor" item list
* Moved all "Estus Flask" entries to "Consumables" item list, removed "Empty Estus Flask" entries
* Moved "Black Eye Orb (Shiva)" cut content item to "Key Items" item list (functionality missing)
* Moved "Escape Death" cut content spell to "Spells" item list (works, has identical function to Rare Ring of Sactifice, uses "Magic Revival" death message instead of "Ring Revival")
* Moved "Gwynevere's Talisman" cut content spell tool to "Spell Tools" item list (does not work properly, usage in Arena+ strongly discouraged)
* Moved "Skull Lantern" from "Spell Tools" to "Usable Items" item list due to its placement in "Spell Tools" item list having caused confusion
* Renamed the following Magic-based Spells (located under "Spells" item list :"Soul Arrow" spell to "Soul Ray", "Great Soul Arrow" to "Soul Arrow", "Heavy Soul Arrow" to "Heavy Soul Ray", "Great Heavy Soul Arrow" to "Heavy Soul Arrow", "Homing Crystal Soulmass" to "Crystal Mass", 
"Crystal Soul Spear" to "Crystal Storm", "Magic Weapon" to "Soul Weapon", "Great Magic Weapon" to "Soul Dart", "Crystal Magic Weapon" to "Crystalize Weapon", "Magic Shield" to "Soul Shield", "Strong Magic Shield" to "Deflection", "Cast Light" to "Light", "Hush" to "Conversion", "Aural Decoy" to "Distract", 
"Fall Control" to "Soul Roots", "Resist Curse" to "Break Curse" and "White Dragon Breath" to "Crystal Ray"
* Renamed the following Pyromancies (located under "Spells item list :"Fire Orb" to "Eruption" and "Firestorm" to "Warmth"
* Renamed the following Miracles (located under "Spells" item list :"Gravelord Sword Dance" to "Gravelord Sword Strike", "Gravelord Greatsword Dance" to "Gravelord Sword Strike", "Seek Guidance" to "Sacred Oath", "Great Lightning Spear" to "Lightning Storm" and "Karmic Justice" to "Karmic Balance"
* Added "Bear" cut content Armor set to "Armor" item list
* Added the Pyromancies "Flame Swathe" (ID: 4120) and "Black Fissure" (ID: 4560) to "Spells" item list
* Added the Miracles "Intervention" (ID: 5315) and "Projected Heal" (ID: 5330) to "Spells" item list
* Added the Spell IDs 5920, 5930, 5940 and 5959 to "Spells" item list (as requested by InfernoPLus; these are IDs for potential future spells. Judging by the ID prefix "5", these will most likely be populated by Miracles, if at all)

--------------------------------------------------------------------------------------------------------------------------------------
Original readme:

# DS Gadget
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
