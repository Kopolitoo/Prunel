# Prunel user guide

*Version française : [user-guide.fr.md](user-guide.fr.md).*

Prunel lets you use a Windows computer with your eyes only: you move a circle with your gaze,
stare at a place, then choose what to do there (click, double click, drag and drop, scroll,
type…). This guide explains how to use it. To install it, see the [README](../README.md).

## Before you start

- Install the official driver of your eyetracker (Tobii) from the manufacturer's website, and
  calibrate it.
- **Pause** the gaze software supplied with the eyetracker (TD Control) while Prunel is used,
  so that the two programs do not both move the mouse.
- Prunel needs three files of the eyetracker (see [Eyetracker files](#eyetracker-files)). On
  most computers it finds them by itself.

## Moving and staring

- **Movement mode** (at startup): a white circle follows your gaze. It moves smoothly, without
  jumps.
- **Fixed gaze**: when your gaze stays still for a moment, the circle freezes, the mouse cursor
  goes to the point you stared at, and an **options icon** appears next to the circle.
  - Look at the options icon: the **action choice** opens.
  - Look elsewhere: the circle follows your gaze again.
  - With "Direct click" on ("Fixation" tab of the settings), keeping your gaze inside the circle
    makes a left click.
- **Mouse tracking** (menu): the mouse cursor follows the circle all the time, instead of only
  when the gaze is fixed.

## Action choice

A black screen shows the area you stared at, enlarged twice, in a circle, with a cross on the
exact point in its center. Near an edge of the screen, the circle is cut flat by that edge.
It fades in and out gently (a fifth of a second), so the screen does not flash.
When it opens, the picture first grows from its real place on the screen to the center, then
the icons appear (less than half a second); the icons only work once they are shown. Going
from the magnifier to the action choice (or back) is a smooth move from one to the other, with
no flash. To turn
this animation off: Settings, "Action choice" tab, "Opening animation". It also applies to the
magnifier. "Animation duration" (0.4 s by default, 0.2 to 2 s) makes it slower or faster.
In the same tab, "Background transparency" lets the real screen show around the
picture (100 % by default = no black background at all; 0 % = fully black).
Around it, icons: left click, double click, right click, magnifier, drag and drop (left button,
right button, android), scroll. Look at an icon until its ring is full to use it. On the left
edge: **Ctrl**, **Shift**, **Alt** (look once to turn on, the border turns green; they are
pressed during the next action). At the top: **Copy**, **Cut**, **Paste**. On the right:
**Back**. After an action, you are back in movement mode.

The **Back** buttons on the right of the screen (action choice, magnifier, drag and drop,
scroll, settings, lists, and the keyboard's "Close") are easy to aim at: looking at the edge of
the screen at their height, or slightly beyond it, also works.

The double click makes a short pause between its two clicks (to close two browser tabs in a
row, for example). To change it: Settings, "Delays" tab, "Double click pause" (in milliseconds,
200 by default; 0 = no pause).

The icons can be moved or removed: Settings, "Action choice" tab, "Configure the icons".

## Magnifier

For small targets (a check box, a small link). The area is shown enlarged four times, in a
circle (cut flat near an edge of the screen); stare at
the exact point on the picture, and the action choice opens on that point. "Magnifier before
action" ("Magnifier, drag" tab) opens the magnifier every time, before the action choice.
"Magnifier delay" (same tab) sets how long to stare at the picture, separately from the fixation
delay of movement mode.

## Drag and drop

Choose a drag and drop in the action choice, then look at the destination: a dotted line
follows your gaze. Stare at the destination, refine it in the magnifier, and the item is moved.
In the magnifier, a small cross marks the start point when it is inside the photo.
"Android" adds a pause before moving (for touch-style apps). The "back" button on the right
edge cancels.

## Hold a mouse button

For games that move the character while a mouse button is held (for example Back to Bed, right
button). Add "Hold left" or "Hold right" to the crown in the icon configuration screen (they are
not there by default; their light violet background says they are game actions). Stare at the starting point and choose it: the button is pressed there,
then the cursor follows your gaze, button still held (same smoothing and anti-jitter as game
mode). To let go, glance at the large "Release" button (square) on the right edge of the screen: a short look is enough. The
button is also released with Escape, or when the gaze is lost for more than one second.
You can also simply keep your gaze still where you want to stop: after 1.5 s the button is
released there (handy to drop something); a green arc fills around that spot meanwhile. This delay is set in Settings, "Gaze" category,
"Pause" tab, "Release the held button"; 0 turns it off (for games where you look at one spot
with the button held).

## Scroll

Choose "Scroll" in the action choice. The circle stays in place. Look above, below, left or
right of it to scroll that way: the further away, the faster. Look inside the circle to stop.
"Back" (right edge) ends scrolling; looking off the screen on the right for one second
does too.

## Menu

Look **below the screen** for half a second: the menu bar opens at the bottom: a row of
well-spaced buttons, with no background behind them. It opens from movement mode, pause and
game mode. Buttons:

- **Settings**: see below.
- **Keyboard**: the gaze keyboard.
- **Pause** / **Resume**: see below.
- **Quit Prunel**: asks "Yes" or "No" first.
- **Shortcuts**: a button on its own near the bottom-right corner, shown with the bar. Look
  at it: a column of shortcuts comes out from under it and slides up (green border); look at
  it again to fold it. This column will grow over time. From bottom to top:
  - **Windows + Tab**: shows all the open windows (Task View): the menu closes, look at the
    window you want and click it with the gaze as usual.
  - **Game**: game mode (see below). From game mode, it becomes **Quit the game**.
  - **Call** (bell): rings to call someone. With the **computer bell** (on at first), a loud
    "ding-dong" rings on this computer for a few seconds (through its speakers, or a Bluetooth
    speaker if Windows plays its sounds there). The menu stays open and shows "Call sent". A
    second call within 5 seconds is ignored ("Call already sent"). The bell is not in the pause
    bar: first choose "Resume", then open the menu again. Settings, "Actions" category, "Bell"
    tab.
  - **Mouse tracking**: on / off (green border when on).

Look away from the bar and the column for one second to close the menu.

**Pause** / **Resume**: nothing follows your gaze any more, until you open the menu again
and choose "Resume".

**Automatic pause**: when the eyetracker no longer sees your eyes for 10 seconds (eyes closed,
head turned, away from the computer), Prunel pauses by itself, so that nothing is clicked when
your eyes come back. A round "Resume" button then shows in the middle of the screen: look at it
to go back to movement mode (the menu's "Resume" and Escape work too). It only starts from
movement mode and fixed gaze, never during the action choice, the magnifier, scrolling, the
game or the settings. Looking below or beside the screen does not count. To change the delay
or turn it off: Settings, "Gaze" category, "Pause" tab.

## Gaze keyboard

Menu, "Keyboard". The keyboard fills the lower half of the screen. Look at a key: it lights up,
flashes green and types. Above the keyboard, the circle works as usual (you can click into
another place). Five pages: letters, accents, numbers and punctuation, symbols and navigation,
F1 to F12. A page key looked at by mistake ("123.!", "[(/", "F1..F12"…) is undone by keeping
your gaze on the same place: after twice the key delay, the keyboard goes back to the previous
page. After an accented letter (é, à, ç…), the keyboard goes back to the letters page by itself.

You can also put "Keyboard" on the crown of the action choice (icon configuration). Fix your
gaze on the field where you want to write, then choose "Keyboard": Prunel first clicks there,
so the field gets the focus and the text cursor goes where you looked. If the keyboard is
already open, it stays open: this is how you move to another field.

- **Word prediction**: the three boxes at the top suggest words. Look at one to write it with a
  space. An unknown word appears with an amber "+": look at it to add it to your personal
  dictionary. Numbers are never added (a word with letters and digits, such as "mp3", can be). Short words come first, unless a longer word is much more common or used often (how much:
  setting "Short words first", see below). Prunel also learns which word usually comes next.
- **Keyboard bar** (look below the screen while the keyboard is open): move the keyboard up or
  down, change its size ("Custom", "Small", "Large"; the Custom size is set in Settings,
  "Keyboard" tab, by 5 % steps), make its background see-through ("Transparency": 0, 25, 50 or 75 %, the
  letters stay clear), call (bell, as in the classic bar), pause it, show the "Input box" (a preview of what you typed), choose
  the "Keyboard layout" (QWERTY, AZERTY…).
- **My words** (Settings, "Prediction" tab): the words you added; look at one twice as long as
  usual (twice the activation delay) to remove it.
  "Add a word" opens a page with the gaze keyboard to type a new word, then "Save". "Fix
  words" puts a pencil on each word: look at a misspelt word, fix it with the keyboard, then
  "Save"; what the keyboard learnt about it is kept. "Remove words" goes back to removing.
- **Export, Merge, Replace** (same "Prediction" tab, below "My words"): the keyboard learns as
  you write (added words, the words you use most, the next words). "Export" writes a dated
  copy, starting with the language code ("EN Dictionary …"), in `Documents\Prunel\Dictionaries` (to keep it, or to take it to another computer).
  "Merge" shows the copies of that folder; looking at one adds it to what is learnt (nothing is
  lost). "Replace" shows the same list; after the question "Replace…? Yes / No", what is learnt
  becomes exactly the chosen copy. The current dictionary is kept first as "Automatic backup":
  replacing with it goes back.
- Close the keyboard with the button above it, from the keyboard bar, or with Escape.

## Game mode

Menu, "Shortcuts", "Game". Nothing is drawn; the mouse cursor follows your gaze directly (made for games like
Mindball Play). Clicks are made with an external switch or voice recognition. Open the menu, "Shortcuts", and
choose "Quit the game" to go back. The "Game" tab of the settings has the game options,
including its own "Game smoothing" and "Game anti-jitter": they change only game mode (and
"Hold left / right"), not movement mode. The game anti-jitter moves by 0.05 % steps, to aim
finely.

## Settings

Menu, "Settings". A black full-screen page with four categories on the left: **Gaze**,
**Actions**, **Interface**, **System**. Each setting has a small symbol in front of its name,
to spot it at a glance, and "−" and "+" (keep your gaze on them to
repeat) or a yes / no switch. Changes apply at once and are saved.

- **Default** (top right): puts back the original values of the shown tab.
- **Back** (right edge) or Escape: back to movement mode.
- The caregiver can also use the mouse and keyboard here: click a value to type it.
- **Language** ("General" tab): English or French. The prediction dictionary follows this
  language.
- **Profiles** ("Profiles" tab): save the current settings under a name, and load them later
  with your eyes (for example a "Morning" and an "Evening" profile).
- **Display** tab: **Circle radius** sets the size of the circle that follows your gaze in
  movement mode and in fixed gaze. A small circle (3 % for example) draws the eyes less and
  tires them less. **Capture radius** sets, separately, the size of the photo of the magnifier
  and of the action choice (at least 4 %, so the action choice icons do not overlap).
- **Colours** tab ("Interface" category): the look of the gaze circle. **Circle colour**: grey
  (the usual circle), white, yellow, green, light blue, dark blue, purple or pink; "−" and "+" go
  from one colour to the next. **Circle thickness**: 100 % is the usual line, 200 % twice as thick (50 to 400 %).
  **Reinforced contrast**: the circle becomes opaque and edged in black, and the progress ring is
  thicker; useful on a busy background or when the eyes are tired. Below the settings, a
  **preview** shows the circle as it will look, on a dark and on a light background: the movement
  circle on the left, the fixed gaze circle with its progress ring on the right.
  **Night mode**: softer colours on Prunel's own screens (keyboard, menu bar, action choice,
  magnifier, settings, options icon): light grey instead of white, darker greens and blues, so
  they dazzle less in the evening. The settings page changes at once; the other screens at their
  next opening. The colour of the gaze circle stays the one you chose.
- **Prediction** tab: **Short words first** (1.3 at first, from 1.0 to 2.0). The larger the
  number, the more short words come before long ones in the three boxes of the gaze keyboard;
  1.0 = no preference, only how common the word is and how often you use it count. If useful
  long words come too late, lower it; if long rare words get in the way, raise it.
- **Sound** tab: two yes / no options, both off at first. **Key sound**: a short "tick" for each
  key of the gaze keyboard. **Button sound**: a short sound for every other button (menu, action
  choice, options icon, settings). The sound plays at the Windows volume.
- **Bell** tab ("Actions" category): **Computer bell** (yes at first): the menu's "Call" button
  rings on this computer. **Bell duration** (6 s at first, 2 to 30 s) and **Bell volume** (80 %
  at first, 10 to 100 %; the Windows volume still applies). **Windows volume while ringing**
  (80 % at first): while the bell rings, the Windows volume is raised to this level if it is
  lower (and unmuted), then put back as it was; 0 = the Windows volume is not touched. While the bell rings, the short
  key and button sounds keep quiet, so they do not cut it. The **Test** button below the
  settings rings the computer bell once with these settings, even when it is off, to hear it
  without leaving the settings.
- **Alexa** tab ("Actions" category): the **Alexa bell** (off at first). When it is on, "Call"
  also rings an Amazon Echo speaker, through the free [Voice Monkey](https://voicemonkey.io)
  service (an Alexa skill; its free plan allows about 200 calls a month). One-time setup, which
  a caregiver can do:
  1. In the Alexa app, enable the **Voice Monkey** skill and link it to your Amazon account.
  2. On [app.voicemonkey.io](https://app.voicemonkey.io), create a **routine trigger** (for
     example "Prunel bell").
  3. In the Alexa app, create a **routine**: when this Voice Monkey device is pressed, set the
     volume, play a doorbell sound, say a sentence, on the Echo you want (a notification to a
     phone can be added).
  4. On app.voicemonkey.io, create a **token**. Copy it (Ctrl+C), then in Prunel look at
     **Paste token**. Copy the id of the routine trigger, then look at **Paste device**.
  5. Look at **Test**: the Echo should ring. Then turn the Alexa bell on.
  The token is saved encrypted for your Windows account (never in clear, never in the log) and
  stays on this computer: a profile does not carry it. Prunel sends nothing but "press this
  device": no gaze data, no typed text. It needs internet; if the Alexa bell fails and the
  computer bell is off, the computer rings instead. Until the answer comes, the menu shows
  "Calling…".
- **General** tab, bottom-right corner: the **Quit Prunel** button, then the question "Quit
  Prunel?" (Yes / No). Quitting thus always stays possible from the settings, even if the menu
  no longer shows its "Quit" button.
- **Tools** tab: **Calibration** (starts the eyetracker calibration) and **Diagnostic** (shows
  the gaze and the cursor live, and how steady the gaze is at the top, middle and bottom of the
  screen; nothing is saved).
- **About** tab: the installed version, and two buttons that open the Prunel **website** and
  this **user guide** in the browser (Prunel then goes back to movement mode).

## For the caregiver

- **Escape** on the physical keyboard brings Prunel back to movement mode from anywhere. Escape
  said to voice recognition software (such as Dragon) does too. When scrolling or when the gaze
  keyboard is open, Prunel keeps Escape for itself: other programs do not receive it.
- Starting Prunel a second time does nothing: it is already running.
- "Start with Windows" ("General" tab) starts Prunel automatically.

## Files on the computer

| What | Where |
| --- | --- |
| Settings | `%APPDATA%\Prunel\settings.json` (can be opened with Notepad) |
| Personal dictionary | `%APPDATA%\Prunel\personal-dictionary.json` |
| Profiles | `Documents\Prunel\Profiles` |
| Exported dictionaries | `Documents\Prunel\Dictionaries` |
| Log | `%LOCALAPPDATA%\Prunel\prunel.log` |

Coming from GazeBar (the former name of Prunel, up to version 0.2.0): at its first start,
Prunel renames the `GazeBar` folders above to `Prunel`, so the settings, the personal dictionary
and the profiles are kept (the old log stays there as `gazebar.log`). The installer puts
Prunel in `C:\Program Files\Prunel`, moves an `Eyetracker` folder from
`C:\Program Files\GazeBar` and deletes the old program and its Start menu shortcut.

Prunel never saves where you look (the eyetracker licence forbids it) and never writes what you
type in the log. The log is short by default; "Detailed log" ("General" tab) notes more, to
track down a problem.

## Eyetracker files

The gaze is read by three Tobii files (`Tobii.Interaction.Net.dll`,
`Tobii.Interaction.Model.dll`, `Tobii.EyeX.Client.dll`). They belong to Tobii AB, so Prunel
does not include them. Prunel looks for them in the `Eyetracker` folder next to `Prunel.exe`,
then in the folders of the Tobii software, then in the Visual Studio NuGet cache.

If the Diagnostic window says they are missing, get them yourself, accepting Tobii's licence:

1. On nuget.org, open the `Tobii.Interaction` package, version 0.7.3, and click "Download
   package".
2. Rename the downloaded `.nupkg` file to `.zip` and open it.
3. Copy the two DLLs of `lib\net45` and the one of `build\x86` into the `Eyetracker` folder next
   to `Prunel.exe` (create it if needed).

## Full installation (UI access)

Prunel is installed with its installer (`Prunel-x.y.z-setup.exe`). Thanks to it, the gaze
circle stays above the Start menu, search and notifications, and clicks and keys reach windows
started "as administrator". Windows allows this "UI access" only to a program that is signed and
installed in `C:\Program Files`: the installer takes care of both. This is why Prunel comes
only as an installer: a gaze control that cannot reach the Start menu, the notifications or
the system pop-ups of Windows would be of little use. (Up to version 0.3.1, a
simple zip without these two things was also offered.)

To install or update:

1. On the [Releases](https://github.com/Kopolitoo/Prunel/releases) page, download
   `Prunel-x.y.z-setup.exe` (under "Assets") and double-click it. Keep another way to click
   (voice, mouse, TD Control) for this step: Prunel closes during the installation.
2. The installer is not signed by a known publisher, so Windows may show "Windows protected
   your PC": click "More info", then "Run anyway". Windows then asks "Do you want to allow this
   app to make changes to your device?": answer "Yes".
3. The installer speaks the language of Windows. "Create a desktop shortcut" is ticked (untick
   it if you do not want one). Click "Install", then "Finish" with "Launch Prunel" ticked: Prunel
   starts from `C:\Program Files\Prunel`.

To pin Prunel to the taskbar: Windows does not let a program pin itself, but it takes a few
looks. Open the Start menu, find Prunel (type or say "Prunel" in the search), right click on it
(action choice), then "Pin to taskbar".

What the installer does: it copies Prunel to `C:\Program Files\Prunel`, creates a certificate
on this computer, makes the computer trust it, signs `Prunel.exe` with it, then deletes the
certificate's private key (nothing else can ever be signed with it). A new certificate is made at
each update. It also adds Prunel to the Start menu, to the desktop if the box is ticked, and to
"Settings > Apps" of Windows. Your
settings are kept. If "Start with Windows" is on, Prunel updates the startup entry itself. It
also updates a copy installed by the old `Install.cmd` script.

To check: the log (`%LOCALAPPDATA%\Prunel\prunel.log`) says "UI access: yes" at startup.

To remove it: Windows "Settings > Apps > Installed apps", Prunel, "Uninstall". It deletes the
program folder, the shortcut and the certificate. Your settings are kept.

If the eyetracker files had to be copied by hand (see [Eyetracker files](#eyetracker-files)),
put the `Eyetracker` folder in `C:\Program Files\Prunel` (Windows asks for administrator
rights). Updates keep it.

## Known limits

- One screen only.
- Started from Visual Studio (developers), Prunel has no UI access: a window started "as
  administrator" ignores its clicks and keys, and the Windows Start menu can hide the circle.
  The [installer](#full-installation-ui-access) has neither limit.
- Tested with the Tobii Dynavox PCEye 5 only.
- The game mode with relative mouse movement has not been tested yet.
- The personal dictionary is shared between languages.
- With the PCEye 5, Windows Hello face recognition uses the eyetracker's camera: while it
  recognises your face, the circle stays frozen. Confirm with your PIN instead (Windows Settings ›
  Accounts › Sign-in options), or use another camera that works with Windows Hello.
- The circle can jitter, above all at the bottom of the screen, when the eyes are half closed
  (tiredness) or when a strong light dazzles the eyetracker's camera (sun from the side, for
  example). It is a limit of the eyetracker: its own software (TD Control) does the same. What
  helps: close a curtain or a blind; calibrate again in these conditions (Settings, "Tools" tab);
  save a calmer [settings profile](#settings) (for example "Tired"), to load at these moments:
  lower **Smoothing** ("Gaze" tab, for example 0.05) and a larger **Fixation radius**
  ("Fixation" tab, for example 2.6). The circle is calmer, but follows the gaze a bit later. To
  compare, the **Diagnostic** window ("Tools" tab) shows how steady the gaze is at the top, the
  middle and the bottom of the screen.
