__author__ = 'Keerthi'
import _random
import sys
import os
from array import *
import ctypes
from random import randint
import random


def Roll_Dice_Player1():
    global red_count
    global yellow_count
    global green_count
    global dice_num
    global player1_score
    red_count=0
    yellow_count=0
    green_count=0
    for num in range(1,dice_num+1):
       r=random.randint(0,5)
       die=dice_numbers[r]
       if(r == 0):
           #print("Red")
           red_count = red_count+1
       elif(r == 1 or r == 2 ):
           #print("Yellow")
           yellow_count = yellow_count+1
       elif(r == 3 or r == 4 or r==5 ):
           #print("Green")
           green_count = green_count+1
           player1_score = player1_score+1


    print("Red:", red_count,"Yellow:", yellow_count,"Green:", green_count)
    print("player1_score:",player1_score)

def main():
    global red_count
    global yellow_count
    global green_count
    global dice_num
    global dice_numbers
    global dice_colors
    global player1_score
    global player2_score
red_count=0
yellow_count=0
green_count=0
dice_num=10
player1_score=0
player2_score=0
dice_numbers = [0,1,2,3,4,5]
dice_colors = ["Red","Yellow","Yellow","Green","Green","Green"]

print("Rules about the Toss-up")  # write rules about the game
print("Let's begin to roll the dice!!!")


print("Please enter who wishes to go first: 1 for Player 1, 2 for Player 2")
user_input = int(input('Give me a number: '))

while True:
    if user_input == 1:
        dice_num = dice_num-green_count
        print("Welcome Player 1")

        Roll_Dice_Player1()
        if(red_count>0 and green_count==0):
            print("You have no greens and 1 red, so your turn is skipped")
            user_input = 2
            continue
        if (dice_num == 0 or dice_num-green_count ==0):
            dice_num = 10
            green_count = 0

        print("Press 1 to continue with ", dice_num-green_count," dice , 2 to Skip")
        user_input = int(input('Please enter: '))

    if user_input == 2:
        break
print("Game Over")


main()


