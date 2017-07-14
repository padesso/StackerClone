//
// timer.cs
//
// Copyright Patrick Adesso - 2009
//
// This file handles the game logic and manages the light animation

function resetTimer(%r,%c)
{
   //show the light 
   gameBoard.setStaticTile(%c, %r, LightImageMap);
   
   //Sync $gameArray with animation
   $gameArray[%r,%c] = 1;
   
   //wait the preset time...
   playLight.setTimerOn($lightDelay);
}

function t2dSceneObject::onTimer(%this)
{
   //Turn off the light that just expired
   gameBoard.clearTile(playLight.currentColumn, playLight.currentRow);
   
   if(playLight.currentColumn - playLight.previousColumn > 0) //moving right
   {
      //index the previous column
      playLight.previousColumn = playLight.currentColumn;
      
      //clear the value of the previous gameBoard location
      $gameArray[playLight.currentRow,playLight.previousColumn] = 0;
      
      if(playLight.currentColumn == 0) //light is at the first column
      {
         playLight.currentColumn++;
         resetTimer(playLight.currentRow,playLight.currentColumn);
      }
      else if(playLight.currentColumn == $columns - 1) //light at the last column
      {
         playLight.currentColumn--;
         resetTimer(playLight.currentRow,playLight.currentColumn);
      }
      else //light is in the middle
      {
         playLight.currentColumn++; //move to the right
         resetTimer(playLight.currentRow,playLight.currentColumn);
      } 
   }
   else //moving left
   {
      //index the previous column
      playLight.previousColumn = playLight.currentColumn;
      
      //clear the value of the previous gameBoard location
      $gameArray[playLight.currentRow,playLight.previousColumn] = 0;
      
      if(playLight.currentColumn == 0) //light is at the first column
      {
         playLight.currentColumn++;
         resetTimer(playLight.currentRow,playLight.currentColumn);
      }
      else if(playLight.currentColumn == $columns - 1) //light is at the last column
      {
         playLight.currentColumn--;
         resetTimer(playLight.currentRow,playLight.currentColumn);
      }
      else //light is in the middle
      {
         playLight.currentColumn--; //move to the left
         resetTimer(playLight.currentRow,playLight.currentColumn);
      }
   }
}