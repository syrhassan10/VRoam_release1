# Trivia Game

It is a minigame where the player goes around to pre-determined spots to answer trivia questions. The player gains a point for every question they get right, and they don't get any points for questions they get wrong. After they answer a question, there is an arrow that points the player to the next trivia question. The score counter keeps track of the player's correct answers. 



It is a multiple-choice trivia with four choices. The trivia question pops up once the player enters the collider of the object that the trivia script is on. The questions and the possible answers and correct answer are coded to be set in the inspector after the script is put on an object. The buttons are put into "Option One, Option Two, Option Three, and Option Four". Currently, the buttons just are numbered 1,2,3 and 4. The possible answers are above that. The possible answers are inputted in "Answer One, Answer Two, Answer Three, and Answer Four". Then the number of the correct option is put in "Correct Answer". There are two canvas, one with the question and possible options, "Question Canvas" and the other just has the score counter on it, "Score Stuff".  For the score label, just drag in the "Score Label" on the score canvas.

**There needs to be different buttons put into the Options, or else the game will break. My solution is to just duplicate the question canvas for every trivia question, so every trivia question has its own canvas, then drag that canvas and its components into the parameters for that question.**

All of the objects with the script has to be put into a empty object **in the order that you want the questions to go** and then drag the empty object into the "trivia_parent" on the Arrow script. This tells the arrow where the locations for the question are and points to the next question. The total number of questions should be entered into the "Total Questions" on the arrow script. 