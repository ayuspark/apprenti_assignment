words = "It's thanksgiving day. It's my birthday,too!"
print(words.find('day'))
print(words.replace('day', 'month', 2))

print(max([2,54,-2,7,12,98]))

aa = [2,54,-2,7,12,98]
aa.sort()
print(aa)

x = [19,2,54,-2,7,12,98,32,10,-3,6]
x.sort()
cut_length = int(len(x)/2)
print(x)
new_list = []
new_list_first = []
for i in range(0, cut_length+1):
    new_list_first.append(x[i])
new_list.append(new_list_first)
for m in range(cut_length+1, len(x)):
    new_list.append(x[m])

print(new_list)