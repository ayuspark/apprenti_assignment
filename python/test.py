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

import requests

r = requests.get('http://pokeapi.co/api/v1/pokemon/1/')

print r.json()['abilities'][0]['name']

