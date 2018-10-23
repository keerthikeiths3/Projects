__author__ = 'Keerthi'
import _random
import sys
import os
from array import *
import ctypes
from random import randint
import random


def Roll_Dice_Player1(param_dice_num):
    global red_count1
    global yellow_count1
    global green_count1
    global player1_score
    global turn_score1
    #Reset variables to ZERO
    red_count1 = 0
    yellow_count1 = 0
    green_count1 = 0
    #Roll dice in loop using param_dice_num
    for num in range(1, param_dice_num+1):
       #Generate a random number from 0 to 5
       r = random.randint(0, 5)
       die = dice_numbers[r]
       #Check if RED color
       if(r == 0):
           #Increment RED color dice count
           red_count1 = red_count1 + 1
       #Check if YELLOW color
       elif(r == 1 or r == 2 ):
           #Increment YELLOW color dice count
           yellow_count1 = yellow_count1+1
       #Check if GREEN color
       elif(r == 3 or r == 4 or r==5 ):
           #Increment GREEN color dice count
           green_count1 = green_count1+1
           #Increment current turn score
           turn_score1 = turn_score1+1
    #Print result after each roll
    print("PLAYER 1 - Red:", red_count1,", Yellow:", yellow_count1, ", Green:", green_count1)
	
    

def Roll_Dice_Player2(param_dice_num):
    global red_count2
    global yellow_count2
    global green_count2
    global player2_score
    global turn_score2
    #Reset variables to ZERO
    red_count2 = 0
    yellow_count2 = 0
    green_count2 = 0
    #Roll dice in loop using param_dice_num
    for num in range(1, param_dice_num+1):
       #Generate a random number from 0 to 5
       r=random.randint(0,5)
       die=dice_numbers[r]
       #Check if RED color
       if(r == 0):
           #Increment RED color dice count
           red_count2 = red_count2+1
       #Check if YELLOW color
       elif(r == 1 or r == 2 ):
           #Increment YELLOW color dice count
           yellow_count2 = yellow_count2+1
       #Check if GREEN color
       elif(r == 3 or r == 4 or r==5 ):
           #Increment GREEN color dice count
           green_count2 = green_count2+1
           #Increment current turn score
           player2_score = player2_score+1
    #Print result after each roll
    print("PLAYER 2 - Red:", red_count2,", Yellow:", yellow_count2, ", Green:", green_count2)

def main():
    #Red, Yellow, Green count for Player 1
    global red_count1
    global yellow_count1
    global green_count1
    #Red, Yellow, Green count for Player 2
    global red_count2
    global yellow_count2
    global green_count2
    #Dice related information
    global dice_numbers
    global dice_colors
    #Player1 total score
    global player1_score
    #Player2 total score
    global player2_score
    #Flags for Game exit checks
    global last_chance
    global game_over
    #Current player number
    global current_player
    #Previous player number
    global previous_player
    #Player 1 turn score
    global turn_score1
    #Player 2 turn score
    global turn_score2

#Reset all variables to initial values
red_count1 = 0
yellow_count1 = 0
green_count1 = 0
dice_num1 = 10
red_count2 = 0
yellow_count2 = 0
green_count2 = 0
dice_num2 = 10
player1_score = 0
player2_score = 0
last_chance = 0
game_over = 0
current_player = 1
previous_player = 1
turn_score1 = 0
turn_score2 = 0
dice_numbers = [0, 1, 2, 3, 4, 5]
dice_colors = ["Red", "Yellow", "Yellow", "Green", "Green", "Green"]

print("Rules about the Toss-up")  # write rules about the game
print("Let's begin to roll the dice!!!")


print("Please enter who wishes to go first: 1 for Player 1, 2 for Player 2")
user_input = int(input('Give me a number: '))

while True:
    if (last_chance == 1 and game_over == 0):
        game_over = 1
        print("*************************************")
        print("*********    FINAL SCORES   *********")
        print("Player 1 score : ", player1_score)
        print("Player 2 score : ", player2_score)
        print("*************************************")
        print("***********    RESULT    **********")
        #Compare the final scores and display the result
        if (player1_score > player2_score):
            print("   PLAYER 1 WON   ")
        if (player1_score < player2_score):
            print("   PLAYER 2 WON   ")
        if(player1_score == player2_score):
            print("   GAME TIED   ")
        print("*************************************")
        print("*************************************")
        break

    if user_input == 1:
        print(" ")
        print("************************")
        print("*** Welcome Player 1 ***")
        print("************************")
        print("Rolling your dice now!!!")
        #Update the previous player, current player to differentiate turns
        previous_player = current_player
        current_player = 1
        #Decrement the dice if same player is continuing
        if(previous_player == current_player):
            dice_num1 = dice_num1 - green_count1
        #Reset the dice to 10 if player is changed
        if(previous_player != current_player):
            dice_num1 = 10

        #Roll dice for player 1 with no.of dice as argument
        Roll_Dice_Player1(dice_num1)
        if (red_count1 > 0 and green_count1 == 0 ):
            #Check for no.of Green and Red, skip turn if no Green and atleast one Red is rolled
            print("You have no greens and 1 red, so your turn is skipped")
            print("Player 1's current score:", player1_score)
            dice_num2 = 10
            turn_score1 = 0
            player1_score = player1_score + turn_score1
            user_input = 2
            continue
        #If all dice are Green, reset total dice to 10
        if (dice_num1 == 0 or dice_num1 - green_count1 == 0):
            dice_num1 = 10
            green_count1 = 0
        #Prompt the player to continue or to skip
        print("Press 1 to continue with ", dice_num1-green_count1, " dice , 2 to Skip to Player2")
        user_input = int(input('Please enter: '))
        #If player chose to skip, add the current turn score to total score
        if(user_input == 2):
            player1_score = player1_score + turn_score1
            turn_score1 = 0
            dice_num2 = 10
            print("Player 1's current score:", player1_score)

    if user_input == 2:
        print(" ")
        print("************************")
        print("*** Welcome Player 2 ***")
        print("************************")
        print("Rolling your dice now!!!")
        #Update the previous player, current player to differentiate turns
        previous_player = current_player
        current_player = 2
        #Decrement the dice if same player is continuing
        if(previous_player == current_player):
            dice_num2 = dice_num2 - green_count2
        #Reset the dice to 10 if player is changed
        if(previous_player != current_player):
            dice_num2 = 10

        #Roll dice for player 1 with no.of dice as argument
        Roll_Dice_Player2(dice_num2)
        if(red_count2 > 0 and green_count2 == 0):
            #Check for no.of Green and Red, skip turn if no Green and atleast one Red is rolled
            print("You have no greens and 1 red, so your turn is skipped")
            print("Player 2's current score:", player2_score)
            turn_score2 = 0
            dice_num1 = 10
            player2_score = player2_score + turn_score2
            user_input=1
            continue
        #If all dice are Green, reset total dice to 10
        if(dice_num2 == 0 or dice_num2-green_count2 == 0):
            dice_num2 = 10
            green_count2 = 0
        #Prompt the player to continue or to skip
        print("Press 2 to continue with ", dice_num2-green_count2, " dice , 1 to Skip to Player1")
        user_input = int(input('Please enter: '))
        #If player chose to skip, add the current turn score to total score
        if(user_input == 1):
            player2_score = player2_score + turn_score2
            turn_score2 = 0
            dice_num1 = 10
            print("reset:",dice_num1," ", dice_num2)
            print("Player 2's current score:", player2_score)

    if(player1_score >= 100 and user_input == 2 and game_over == 0 and last_chance == 0):
        print("Player1 score reached 100")
        print("Last chance for Player 2")
        last_chance = 1
    if(player2_score >= 100 and user_input == 1 and game_over == 0 and last_chance == 0):
        print("Player2 score reached 100")
        print("Last chance for Player 1")
        last_chance = 1


#Call the Main function
main()
print("Game Over")

