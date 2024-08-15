# Blog Post 4

### Feature 1
Create the score to display during the game.

### I have added: 
I have added a TextMeshPro element that will display it. Also i have created a script that will count the score, each time when the user interacts with the space between bars it gets a point, for this i created that this place is a invisible colision, as the player to not stop when go between them and i have set as when the user is doing this to get 10 points.

### Feature 2
Create the death menu

### I have added: 
For the death menu i have set as when the player hit the bar the scene must stop working and the death menu to apear.

### Feature 3
Curent score on death menu

### I have added: 
I have used the same script as for the Feature one because is the same implementation

### Feature 4
Best Score on death menu

### I have added: 
I have added a new text that will display the best score. For it i have added some new changes in the Score Script.
### Bug
The maximum score doesnt update, it shows the same score as curent score.
### Solution
In the script i have added new method and corrected the previous, because was some logic issues.

### Feature 5
Button to main menu

### I have added: 
I have created a new button that will redirect to main menu. In the Game Manager script i have that each time when press on the menu button to redirect to Scene Number 0. There, were a lot of bugs with UI to understand how is better to create the yerarchy of the death menu and the button to work, but i fixed them.

### Feature 6
Restart button on death menu
### I have added: 
I have created a button with the same script as previous feature and script, but in this case when press on it, it must reload the Scene number 1. And then game starts again and user can play.
