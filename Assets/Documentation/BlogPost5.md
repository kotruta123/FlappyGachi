# Blog Post 5

### Feature 1
Create Sound Effects

### I have added: 
I have added a script that handles all the SFX. All the sound effects were found on youtube and cut and then in the end, i had the sound of death and the sound of jump. They are in gachimuchi style. I created a game object which handles the respecive script and then add the reference in another script as when the death menu appears it must play this song. I have made the same for the player script as each time the player is triggered to play the respective jump sound.
### Feature 2
Create background music

### I have added: 
I almost had the same implementation of the SFX elements, but in this case the music perssist all the time. In the script i have added as the music is trigered to play when the scene number is 0. Also the music i have put to be in a loop.
### Bug
It didnt play the music on the scene 0 but it started on scene number one and when i restarted the scene 1 the music was doubled
### Solution
I have added the music element to the scene 0 and atached to a new game object. In the script i have made as it to not have any interactions with scene number 1 and also it was easier to implement the updating of the song. Now it loads on scene 0.

### Feature 3
SFX and music control

### I have added: 
I have created the settings menu. In the it i have added new elements that permits to cotroll them. Also i have added a new script that makes this control. It is possible to minimize and maximize the volume.
### Bug and Solution
The Script didnt work corectly, it didnt save the settings of music and SFX, but it was fixed by trying different methods.

### Feature 4
New player animation

### I have added: 
I have added a new script that handles it. For now the user when jumps rotates to 40 degrees, and when no interaction with button it rotates down to 80 degrees from the previous position.

### Feature 5
Info  Page

### I have added: 
In the info page i have added and chancged the background I have added a button to main menu, and also i have added a text with the creator of the game. 

