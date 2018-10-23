#!/usr/bin/python
import math
fo = open("readings.txt", "r")

for x in range(26):
		line = fo.readline()
#print("Line 1 is "+line)
arr = [float(arr_temp) for arr_temp in line.strip().split(' ')]
x = math.sqrt((arr[0]**2)+(arr[1]**2)+(arr[2]**2))
#print( "abs value of 1st line is ")
#print(x)
for line2 in fo:
	line3 = str(line2)
	#print(line2)
	if(line3[0] == '#'):
		print("end")
	else:
		arr = [float(arr_temp) for arr_temp in line3.strip().split(' ')]
		y = math.sqrt((arr[0]**2)+(arr[1]**2)+(arr[2]**2))
		#print("Line 2 is ")
		#print(line3)
		k = abs(x-y)
		x = y
		print("value of k is " +str(k))
		if k>4:
			print("shaken")
	
