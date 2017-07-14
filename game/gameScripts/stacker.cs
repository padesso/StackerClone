//
// stacker.cs
//
// Copyright Patrick Adesso - 2009
//
// This file handles the win/lose logic

//Globals
$columns = 7;
$rows = 15;

//Initialize the game
function start()
{   
   echo("Starting the game.");
   
   //Fill array with 0's and clear gameBoard
   clearBoard();
   
   //Start the game at the bottom row (14) 
   playStacker(14);
}

function clearBoard()
{
   gameBoard.clearLayer();
   
   for(%i=0; %i <= $rows; %i++)
   {
      for(%j=0; %j < $columns; %j++)
      {
         $gameArray[%i, %j] = 0;
      }
   }
}

function playStacker(%currentRow)
{
   $lightDelay = 175;                            //delay between light changes (light speed)
   
   %row = %currentRow;
   %col = getRandom(0,$columns - 1);            //start in a random column
   
   playLight.currentRow = %row;
   playLight.currentColumn = %col;
   playLight.previousColumn = %col;
   
   resetTimer(%row, %col);
}

function checkUserInput()
{   
   if(playLight.currentRow == $rows - 1)
   {
      winRound();
   }
   else if($gameArray[playLight.currentRow, playLight.currentColumn] == 1 && $gameArray[playLight.currentRow + 1, playLight.currentColumn] == 1)
   {
      winRound();
   }
   else
   {
      loseGame();
   }
}

function winRound()
{
   echo("Win round: " @ playLight.currentRow);
     
   if(playLight.currentRow == 0)
   {
      winGame();
   }
   else
   {
      playLight.currentRow--;
      $lightDelay = $lightDelay - 10;
   }
}

function winGame()
{
   echo("You win!");
   
   //TODO: push a victory screen and reset game
     
   playLight.setTimerOff();
}

function loseGame()
{
   echo("You lose!");
   
   //TODO: push a you lose message and reset it all.
   playLight.setTimerOff();
   
   start();
}
