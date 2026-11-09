# Manual tests

*Version française : [manual-tests.fr.md](manual-tests.fr.md).*

Prunel cannot be tested automatically: these tests are done by hand, with an eyetracker. Run
the ones that match what a pull request changes, and say in the pull request which ones passed.

Before testing, turn on "Detailed log" (Settings, System, "General" tab): the log lines
mentioned below are only written with this option. Log: `%LOCALAPPDATA%\Prunel\prunel.log`.

## 1. Movement and fixed gaze

Stare at a button, the circle freezes (white border, options icon) and the cursor
goes to the button; look elsewhere, it moves again. With "Direct click" on ("Fixation" tab), keeping the
gaze on the button fills a ring, then a left click is made. The log notes each switch to fixed
gaze and each direct click.

## 2. Action choice

Stare at a file in File Explorer, look at the options icon, the black screen shows
the enlarged area; look at "Double click": the black screen disappears and the file opens,
without touching the mouse.

Double click pause (issue #59): Settings, "Delays" tab, "Double click pause" at 200 ms. In the
browser, open three tabs, double click on the close button (×) of one of them: two tabs close.
Set it back to 0 ms: a file in File Explorer still opens with a double click.

## 3. Menu and pause

Look at the bottom, off the screen: the menu bar appears: buttons only, with no
dark background behind them, and clearly spaced (also in the keyboard's menu bar). Look at "Pause":
everything stops. Look at the bottom again: only "Resume" shows, and the circle
stays hidden, even when looking quickly away (issue #49). After "Resume", the circle comes back. All with the
eyes only. Escape also goes back to movement mode.

## 4. Magnifier

Stare at a small check box, look at the options icon, then "Magnifier" in the
crown: the area appears enlarged ×4. Stare at the box on the picture: the action choice opens,
the cross is on the box; "Left click" checks it. There is no need to look away and come back:
if the gaze is already on the box when the picture appears, the action choice opens after the
usual delay (issue #91).
"Magnifier delay" ("Magnifier, drag" tab): set it to 0.3 s, the action choice opens faster
from the magnifier, while fixed gaze in movement mode keeps the "Fixation delay". An older
settings file starts with the magnifier delay equal to its fixation delay. With "Magnifier before action" on ("Magnifier, drag" tab), the magnifier opens right after the options icon.

## 5. Modifiers and drag and drop

In File Explorer, stare at a file, open the action choice, look at "Ctrl" (green
border) then "Left click"; do it again on another file: both are selected. Then stare at a file,
choose "Drag left" (four arrows, badge L), look at the destination folder (the dotted
line follows), stare at it, refine in the magnifier: the file is moved. The "back" button on the
right cancels.

## 6. Settings

Menu, "Settings": the black screen opens on the Gaze tab. Keep the gaze on the "+"
of the smoothing: the value goes up by one step every 0.4 s. Look at the Fixation tab, then the
direct click switch: it turns blue, knob on the right, "Yes". "Default", then "Yes": the values
of the tab come back. The caregiver clicks a value, types 0.5 then Enter. "Back" goes back to
movement mode. Starting Prunel a second time does nothing (see the log).

## 7. Scrolling

Open a long web page, stare at the text, open the action choice then "Scroll"
(left, top). The white circle stays in place. Look inside the circle: nothing moves. Look a
little below the circle: the page goes down slowly; lower: faster. Above: it goes up. "Back" on
the right edge goes back to movement mode. At low speed, the page must slide without small
jumps, and start and stop gently; without having clicked in the page first, it must scroll
anyway (the log notes the window made active and the state of the Windows wheel setting).
Open scrolling again and look straight below the circle, without passing through it: the page
must start going down within half a second, without moving the gaze. Each start must be gentle:
slow at first, then faster over about a second and a half; just outside the circle, very slow.
Look off the screen on the right for one second: back to movement mode. Look off the screen
above, below and on the left: it still scrolls at full speed in that direction. Open scrolling
again and say "Escape" to Dragon: back to movement mode. With a menu of a program open under the
circle, Escape in scroll mode must not close that menu (Prunel keeps the key). Same with the
gaze keyboard open: Escape closes the keyboard only.

## 8. Icon configuration

Menu, "Settings", "Icons" tab, "Configure the icons". Look at the "−" of the left
click (top left of the crown) then the one of the right click: both slots become empty ("+").
Look at the first one: the list offers all the actions of the crown; choose "Right click". Do
the same with the other slot and "Left click": the two actions have swapped places. "Back", then
in the action choice, the two icons are in their new place. Removing "Cut" leaves a greyed slot
at the top of the action choice. "Default" in the "Icons" tab puts everything back.

## 9. Screen sizes

Screen at 1920 × 1080, 100 %. At the first start, the log notes "updated to
version 7" and the detected screen; the circle, the icons and the menu bar look the same size as
before in 4K. "Display" tab: "Detected screen" gives the resolution, the scaling and the text
size; "Interface size" at 150 % enlarges the circle, the icons and the menu. While Prunel runs,
change the resolution, then the scaling (125 %), then the Windows text size: each time, the log
notes the change and the sizes adapt (an open action choice or magnifier closes, back to
movement mode; the pause, the game and the settings stay open).

## 10. Gaze keyboard

In Notepad, open the menu, "Keyboard": the keyboard appears at the bottom. Look at
keys: they light up, flash and the text is written ("é" from the accents page). Look above the
keyboard: the circle comes back and fixed gaze works. Type for a while on the top
right keys: the Close button, clearly apart from the keyboard, is never triggered by mistake
(same below the keyboard when it is at the top). Look below the screen: the keyboard bar
opens and the keyboard slides up above it; "Up / down" puts it at the top (it reopens there next
time), "Size" goes to 75 % then 50 %, "Pause" hides it until resuming. In the icon configuration,
place "Keyboard" on the crown: in the action choice, this button opens the keyboard. In Notepad with several lines of text,
fix your gaze in the middle of a line (Notepad not active, or another window in front), choose
"Keyboard": the text cursor goes to that place and typed keys are written there. With the
keyboard open, the same button closes it, without a click.

## 11. Word prediction

Interface in French. In Notepad, open the keyboard and type "bo": the boxes
suggest "bon", "bonne"…; look at "bonjour" (after "bonj"): "bonjour" and a space are written.
"ete" suggests "été". "pr" suggests short words ("pris", "près"…) before "prendre". Type an invented word ("zorglub"): the 1st box shows "+ zorglub" in amber;
look at it: a space is written, and typing "zo" suggests the word. Type "2026": no "+" box
appears; type "mp3x": "+ mp3x" appears. Write "je suis" twice (typing
"suis" in full then a space): after "je" and a space, the 1st box suggests "suis". After closing
Prunel, `%APPDATA%\Prunel\personal-dictionary.json` contains the word.

## 12. Keyboard options

Keyboard open, look below the screen: the keyboard bar also shows "Input box" and
"Keyboard layout". "Input box": the border turns green, a band appears above the keys; type
"hello everyone": the band shows it; an arrow empties it. "Keyboard layout": the list shows the
layouts, the one in use with a green border; "Back to the keyboard" goes back to the keyboard.
Settings, General tab, "My words": "zorglub" (added in step 13) is in the list; look at it: it
disappears; "Back to the settings" goes back to the General tab. Typing "zo", it is no longer
suggested.
"Transparency" (shows "0 %"): look at it: "25 %", the keyboard backgrounds let the window behind
show through; again: "50 %", "75 %", then "0 %" (opaque as before). At 75 %, the letters,
the green flash and the hover stay clearly visible. Close and reopen Prunel: the value is kept.

## 13. English keyboard

Keyboard open, "Keyboard layout": the list shows "English QWERTY" and
"Français AZERTY"; choose "English QWERTY": QWERTY letters, and with the interface in French,
"bonj" still suggests "bonjour". Settings, General, "Language" → English; back to the keyboard:
"th" suggests "the", "that", "this" (or close), "don" and "don'" suggest "don't".

## 14. Settings profiles

Settings, System, Profiles, "Save the current settings": the gaze keyboard
appears with the name page; type "Evening", look at "Save": the message gives the name of the
profile, and the file appears in `Documents\Prunel\Profiles`. Change the circle
radius (Display). Profiles, "Load a profile": the list shows the profile; look at it: "Load the
profile …?"; "No" changes nothing; "Yes" restores the old radius and creates "Automatic backup".
Loading "Automatic backup" restores the changed radius.

## 15. Sound feedback

Settings, "Interface", "Sound" tab: both switches are off; nothing makes a sound. Turn on
"Key sound": open the keyboard and type: a short high "tick" for each key (also with key
repeat), but no sound for the menu or the action choice. Turn it off and turn on "Button sound":
the keys are silent; the options icon, the action choice, the menu buttons and the settings
buttons make a short two-note sound. Turn both off: silence again. Restart Prunel: the choices
are kept.

## 16. Menu hover (issue #97)

Right-click on the desktop, then in File Explorer, to open a context menu. Stare at an item of
the menu: when the circle freezes and the cursor joins it, the item is highlighted, as with a real
mouse; on an item with a small arrow, the sub-menu opens. Same test with "Mouse tracking" on
(the highlight follows the gaze), and in game mode "direct". The cursor stays exactly where the
circle is (no one-pixel shift).

## 17. New word after a click (issue #96)

Open a web page with a form of several fields (or two text boxes). Open the keyboard, click in
the first field and type a few letters, without a space. With the gaze, click in the second
field: the suggestion boxes become empty at once. Type a letter:
the suggestions start from this letter alone, not from the word of the first field. Same test
with a click said to voice recognition, and with a real mouse. Typing several words in the
same field without clicking still works as before (next-word suggestions after a space).
Type a few letters again, then press an arrow key (or Delete) on a real keyboard, or say it to
Dragon: the suggestion boxes become empty too. Pressing Shift or Ctrl alone changes nothing.

## 18. Gaze steadiness in the Diagnostic window (issue #86)

Open the settings, "Tools" tab, "Diagnostic". Below the screen thumbnail, three lines "Top",
"Middle" and "Bottom" show numbers that grow while you look at the screen. Hold your gaze on a
point near the top edge for about 20 seconds, then in the middle, then near the bottom edge:
the "measures" count grows in the matching line. Close your eyes for one second: "losses" grows
in the band you were looking at. "Reset the measures" puts everything back to 0. Close and
reopen the window: everything starts from 0 again. No new file appears in
`%LOCALAPPDATA%\Prunel\` and the log holds no gaze position.

## 19. Automatic pause

Gaze and voice only: no need to touch the mouse or the USB cable.

1. Settings, "Gaze" category, "Pause" tab: "Automatic pause" is on, "Delay before the pause"
   is 10 s. Set the delay to 5 s, then go back to movement mode.
2. Close your eyes (or turn your head away from the eyetracker) for about 6 seconds, then look
   at the screen again: the circle is gone and a round "Resume" button is in the middle of the
   screen. Elsewhere on the screen, nothing is clicked and the cursor does not move.
3. Look at "Resume": its ring fills up, then the circle comes back (movement mode).
4. Close your eyes for only 3 seconds: no pause.
5. Look below the screen for 6 seconds: the menu opens, no automatic pause. Close the menu.
6. Open the gaze keyboard, close your eyes 6 seconds: automatic pause, the keyboard is hidden;
   after "Resume", the keyboard comes back.
7. Automatic pause again, then look below the screen: the menu shows only "Resume" and the
   centre button disappears; let the menu close: the centre button comes back. Escape (said to
   Dragon) also goes back to movement mode.
8. Open the settings and close your eyes 6 seconds: no pause (the settings stay open). Same in
   the magnifier and the action choice.
9. Turn "Automatic pause" off: closing your eyes no longer starts it. Put the delay back to
   10 s (or "Default"). The log says "Automatic pause: gaze lost for 5 s" and holds no gaze
   position.

## 20. "Back" buttons on the right edge (issue #53)

Gaze only. For each screen below, look at the right edge of the screen at the height of
"Back", between the button and the edge, then a little beyond the edge (off the screen): the
button lights up, its ring fills up, and it goes back as usual.

1. Action choice: "Back" goes back to movement mode.
2. Magnifier (from the action choice): "Back" goes back.
3. Drag and drop, choosing the drop point: "Back" cancels. A drop point elsewhere still works.
4. Scroll: "Back" ends scrolling. Looking off the screen on the right still ends it after one
   second.
5. Settings: "Back" (middle of the right column) goes back to movement mode. "Default", above
   it, does not react to a gaze off the screen.
6. Settings, "Configure the icons": "Back" goes back to the settings. Lists ("Keyboard layout",
   "My words", profiles): "Back" goes back.
7. Gaze keyboard: staring just next to the "Close" cross (left of it, below it, or at the
   right edge of the screen) closes the keyboard. Typing on the top row of keys never closes it.
8. Look off the screen far to the right (a hand width or more) or well above or below "Back":
   nothing happens. In movement mode, the menu still opens when looking below the screen.

## 21. Keyboard page keys toggle back (issue #106)

Gaze only, gaze keyboard open on the letters page.

1. Look at "123.!" and keep looking: the numbers page appears ("ABC" at the same place), then
   after twice the key delay (slower than typing) the letters page comes back, then numbers again… Look away: it stops.
2. Same with "[(/": symbols, then back to letters (not to numbers, although "123.!" is at that
   place on the symbols page).
3. Same with "À,È,Ê" (accents ↔ letters) and, from the numbers page, "F1..F12" (F keys ↔
   numbers).
4. Look at "123.!", then look away and back at "ABC": it goes to the letters page as usual.
5. Works the same with "Repeat" off (Settings, keyboard tab).

## 22. Black screen fades in and out (issue #116)

Gaze only.

1. Stare at a point in movement mode: the action choice black screen comes in gently (about
   0.2 s) instead of at once. The buttons work right away.
2. "Back": the black screen fades out (about 0.15 s), the real screen comes back without a
   flash. Same after a left click: the click happens as usual (a link opens, a field gets the
   focus).
3. Magnifier (from the action choice or directly): its black screen also fades in and out. The
   photo of the action choice and of the magnifier never shows the black screen itself.
4. Scroll and drag and drop from the action choice: the black screen fades out while the mode
   starts; scrolling and dropping work as before.
5. "Configure the icons" (settings, Icons tab) and the keyboard lists: they fade in; changing page in a
   list does not fade again.

## Full installation (Setup.exe, UI access)

Use the `Prunel-setup-…` zip of the automatic build (Actions page of the pull request,
"Artifacts") or the `Prunel-x.y.z-setup.exe` of a draft release. Keep another way to click
(voice, mouse) during the installation.

1. Double-click `Prunel-…-setup.exe`. Windows may say "unknown publisher" ("More info", "Run
   anyway"), then asks "Yes" for administrator. The installer speaks the language of Windows;
   click "Install", then "Finish" with "Launch Prunel" ticked: Prunel starts and the log says
   "UI access: yes".
2. `C:\Program Files\Prunel` exists, Prunel is in the Start menu and in "Settings > Apps"
   of Windows. The installer showed one page, "Create a desktop shortcut" ticked, with an
   "Install" button (no extra "Next"): a Prunel shortcut is on the desktop and starts it.
   Running the installer again with the box unticked removes nothing by itself, but uninstalling
   removes the desktop shortcut. Pinning by hand (Start menu, right click on Prunel, "Pin to
   taskbar") works.
3. Open the Windows Start menu: the gaze circle stays visible above it, and a fixed gaze then a
   left click opens an item of the menu.
4. Start Notepad as administrator (right click, "Run as administrator"): a click by gaze puts
   the text cursor in it, and the gaze keyboard types in it.
5. Run the installer again (update): no question about closing Prunel (it is closed), same
   result, settings unchanged.
6. Uninstall it from "Settings > Apps": the folder, the shortcut and the certificate "Prunel
   local signature" (`certlm.msc`, "Trusted Root Certification Authorities") are gone; the
   settings are still in `%APPDATA%\Prunel`.
7. Visual Studio (F5) still works as before, with "UI access: no" in the log.

## Coming from GazeBar (version 0.3.0)

On a computer where GazeBar 0.2.0 is installed with Setup.exe, with "Start with Windows" on,
a personal word and a saved profile:

1. Run `Prunel-…-setup.exe`. GazeBar is closed without a question; Prunel starts.
2. `C:\Program Files\Prunel` exists (with the `Eyetracker` folder if GazeBar had one);
   `C:\Program Files\GazeBar` and the "GazeBar" Start menu shortcut are gone; "Settings > Apps"
   shows only Prunel.
3. The settings are the same as before (circle size, language…), the personal word is
   suggested, and the profile is in the list. `%APPDATA%\Prunel`, `%LOCALAPPDATA%\Prunel` and
   `Documents\Prunel` exist, the `GazeBar` ones no longer; the log says "Former name: …
   renamed GazeBar -> Prunel".
4. Restart Windows: only Prunel starts (no error about a missing GazeBar.exe).
5. In `certlm.msc`, "Trusted Root Certification Authorities": "Prunel local signature" is
   there, "GazeBar local signature" is gone.

## Before publishing a version

Download `Prunel-0.1.0-setup.exe` of the draft release (its only file) and run the "Full
installation" test above with it. Also check: the gaze works, the gaze keyboard suggests words,
`C:\Program Files\Prunel` holds no `Tobii.*.dll` (unless an `Eyetracker` folder was copied there
by hand), and the first lines of `%LOCALAPPDATA%\Prunel\prunel.log` say "Prunel 0.1.0 starting"
(the number of the version).
