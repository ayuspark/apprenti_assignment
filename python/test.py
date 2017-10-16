# def firstDuplicate(a):
#     prev_idx = 0
#     dups_idx = []
#     if len(a) == 1:
#       print(-1)
#       return -1
#     else:
    
#         for n in range(0, len(a)-1):
#             dup = a[n]
#             dup_boo = False
#             # print(dup)
#             for i in range(n+1, len(a)):
#                 if a[i] == dup:
                    
#                     dup_boo = True
#                     # if n == 0:
#                     #     prev_idx = i
#                     # elif n > 0 and i < prev_idx:
#                     #     prev_idx = i
#                     #     print(dup)
#                     #     return dup
#                     dups_idx.append(i)
#             if n == (len(a) - 2) and dup_boo == False:
#                 print(-1)
#                 return -1
            
#             dup = a[min(dups_idx)]
#         print(dup)
#         return dup


# def adjacentElementsProduct(inputArray):
#     product = [];
#     for i in range(0, len(inputArray)-1):
#         product.append(inputArray[i] * inputArray[i+1])
#     print(max(product))
#     return max(product)
# adjacentElementsProduct([3, 6, -2, -5, 7, 3])


# def shape_area(n):
#     if n == 0:
#         return 0
#     else:
#         print(n**2 + (n-1)**2)
#         return n**2 + (n-1)**2

# shape_area(3)


# def makeArrayConsecutive2(statues):
#     statues.sort()
#     print(statues)
#     count = 0
#     for idx in range(0, len(statues)-1):
#         if statues[idx+1] != statues[idx] + 1:
#             count += statues[idx+1] - statues[idx] - 1
#     print(count)
#     return count

# makeArrayConsecutive2([6, 2, 3, 8])

# def rain_terrace(a_list, water=0):
#     # rain terrace algorithm
#     p1 = 0
#     p2 = 0
#     p3 = 0
#     # set 3 pointers, respectively for start, lower point, and end
#     if len(a_list) < 3:
#         return water
#     else:
#         for i in range(0, len(a_list) - 1):
#             if a_list[i + 1] < a_list[i]:
#                 # terrace level descends, potential water collection
#                 p1 = i
#                 # set pointer to the starting high edge
#                 p2 = i + 1
#                 # set pointer to the lower edge

#                 for j in range(p1, len(a_list) - 1):
#                     print('j', j)
#                     print('j value:', a_list[j])
#                     print('j+1 value', a_list[j + 1])
#                     if a_list[j] >= a_list[j + 1]:
#                         # terrace continue to descend, keep looking for the ending higher point
#                         p2 = j + 1
#                     elif a_list[j] < a_list[j + 1] and a_list[j + 1] >= a_list[p1]:
#                         # terrace ending point equal or higher than starting point, a puddle is created, ready to collect water
#                         p3 = j + 1
#                         print('p1: %d, p2: %d, p3: %d' % (p1, p2, p3))
#                         break

#                 rest_list = a_list[p3:]
#                 print('rest', rest_list)
#                 # take the rest of list for recursion
#                 water_puddle = a_list[p1:(p3 + 1)]
#                 print('puddle............', water_puddle)
#                 # mark the boundry of water puddle
#                 water = sum(map(lambda x: a_list[p1] - x, water_puddle))
#                 print('middle water', water)
#                 # rain_terrace(rest_list, water)
#                 break
#     print('water', water)
#     return water


# rain_terrace([5, 3, 1, 0, 1, 0, 4, 2, 5], 0)

        
"""
 Markdown.py
 0. just print whatever is passed in to stdin
 0. if filename passed in as a command line parameter, 
    then print file instead of stdin
 1. wrap input in paragraph tags
 2. convert single asterisk or underscore pairs to em tags
 3. convert double asterisk or underscore pairs to strong tags

"""

import fileinput
import re


def convertStrong(line):
    line = re.sub(r'\*\*(.*)\*\*', r'<strong>\1</strong>', line)
    line = re.sub(r'__(.*)__', r'<strong>\1</strong>', line)
    return line


def convertEm(line):
    line = re.sub(r'\*(.*)\*', r'<em>\1</em>', line)
    line = re.sub(r'_(.*)_', r'<em>\1</em>', line)
    return line


for line in fileinput.input():
    line = line.rstrip()
    line = convertStrong(line)
    line = convertEm(line)
    print '<p>' + line + '</p>',
