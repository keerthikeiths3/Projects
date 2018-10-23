__author__ = 'Keerthi'
import _random
import sys
import os
from array import *
import ctypes
from random import randint
import random


def Roll_Dice_Player1():
    global red_count1
    global yellow_count1
    global green_count1
    global dice_num1
    global player1_score
	
    red_count1=0
    yellow_count1=0
    green_count1=0
	
    for num in range(1,dice_num1):
       r=random.randint(0,5)
       die=dice_numbers[r]
       if(r == 0):
           #print("Red")
           red_count1 = red_count1+1
       elif(r == 1 or r == 2 ):
           #print("Yellow")
           yellow_count1 = yellow_count1+1
       elif(r == 3 or r == 4 or r==5 ):
           #print("Green")
           green_count1 = green_count1+1
           player1_score = player1_score+1

    print("Red:", red_count1,"Yellow:", yellow_count1,"Green:", green_count1)
    print("Player 1 score:",player1_score)


def Roll_Dice_Player2():
    global red_count2
    global yellow_count2
    global green_count2
    global dice_num2
    global player2_score
	
    red_count2=0
    yellow_count2=0
    green_count2=0
	
    for num in range(1,dice_num2):
       r=random.randint(0,5)
       die=dice_numbers[r]
       if(r == 0):
           #print("Red")
           red_count2 = red_count2+1
       elif(r == 1 or r == 2 ):
           #print("Yellow")
           yellow_count2 = yellow_count2+1
       elif(r == 3 or r == 4 or r==5 ):
           #print("Green")
           green_count2 = green_count2+1
           player2_score = player2_score+1

    print("Red:", red_count2,"Yellow:", yellow_count2,"Green:", green_count2)
    print("Player 2 score:",player2_score)


def main():
    global red_count1
    global yellow_count1
    global green_count1
    global dice_num1
	
	global red_count2
    global yellow_count2
    global green_count2
    global dice_num2
	
    global dice_numbers
    global dice_colors
    global player1_score
    global player2_score
	global last_chance
	global game_over
	
red_count1=0
yellow_count1=0
green_count1=0
dice_num1=10

red_count2=0
yellow_count2=0
green_count2=0
dice_num2=10

player1_score=0
player2_score=0
dice_numbers = [0,1,2,3,4,5]
dice_colors = ["Red","Yellow","Yellow","Green","Green","Green"]
last_chance = 0
game_over = 0

print("Rules about the Toss-up")  # write rules about the game
print("Let's begin to roll the dice!!!")


print("Please enter who wishes to go first: 1 for Player 1, 2 for Player 2")
user_input = int(input('Give me a number: '))

while True:

	if (last_chance == 1 and game_over == 0)
		game_over = 1
		print("Player 1 score : ", player1_score)
		print("Player 2 score : ", player2_score)
		if (player1_score > player2_score)
			print ("Player 1 won")
		if (player1_score < player2_score)
			print ("Player 2 won")
		if (player1_score == player2_score)
			print ("Game Tied")
		break;

    if user_input == 1:
        dice_num1 = dice_num1-green_count1
        print("Welcome Player 1")

        Roll_Dice_Player1()
        if(red_count1 > 0 and green_count1 == 0):
            print("You have no greens and 1 red, so your turn is skipped")
            user_input = 2
            continue
        if (dice_num1 == 0 or dice_num1-green_count1 == 0):
            dice_num1 = 10
            green_count1 = 0

        print("Press 1 to continue with ", dice_num1-green_count1," dice , 2 to Skip to Player2")
        user_input = int(input('Please enter: '))

    if user_input == 2:
        dice_num2 = dice_num2-green_count2
        print("Welcome Player 2")

        Roll_Dice_Player2()
        if(red_count2 > 0 and green_count2 == 0):
            print("You have no greens and 1 red, so your turn is skipped")
            user_input = 1
            continue
        if (dice_num2 == 0 or dice_num2-green_count2 == 0):
            dice_num2 = 10
            green_count2 = 0

        print("Press 2 to continue with ", dice_num2-green_count2," dice , 1 to Skip to Player1")
        user_input = int(input('Please enter: '))
	
	if (player1_score >= 100 and user_input == 2 and game_over == 0 and last_chance == 0)
		print("Player1 score reached 100")
		print("Last chance for player 2")
		last_chance = 1
	if (player2_score >= 100 and user_input == 1 and game_over == 0 and last_chance == 0)
		print("Player2 score reached 100")
		print("Last chance for player 1")
		last_chance = 1
	
print("Game Over")


main()


