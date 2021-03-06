import random

words = "It's thanksgiving day. It's my birthday,too!"
print(words.find('day'))
print(words.replace('day', 'month', 2))


print(max([2, 54, -2, 7, 12, 98]))


[2, 54, -2, 7, 12, 98].sort()


# list manipulation assignment
x = [19, 2, 54, -2, 7, 12, 98, 32, 10, -3, 6]
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


def mix_type_list(some_list):
    # list type check
    set_a_type = type(some_list[0])
    is_not_mix = True
    strs = ''
    sums = 0
    output = {'mix': 'this is mixed',
              'str': 'these are all strings',
              'num': 'these are all numbers', }
    for ele in some_list:
        if type(ele) != set_a_type:
            is_not_mix = False
        if type(ele) == 'str':
            strs += ele
        elif isinstance(ele, (int, float)):
            sums += ele

    if is_not_mix is True:
        if isinstance(some_list[0], str):
            print(output['str'])
        elif isinstance(some_list[0], (int, float)):
            print(output['num'])
    else:
        print(output['mix'])
    
    print(sums)
    print(strs)


mix_type_list(['magical unicorns', 19, 'hello', 98.98, 'world'])
mix_type_list([2, 3, 1, 7, 4, 12])
mix_type_list(['magical', 'unicorns'])


#compare_list
def compare_list(list1, list2):
    is_same = True
    if len(list1) != len(list2):
        is_same = False
    else:
        for i in range(0, len(list1)):
            if list1[i] != list2[i]:
                is_same = False
    print(is_same)
    return is_same

compare_list([1, 2, 5, 6, 2], [1, 2, 5, 6, 2])
compare_list(['celery', 'carrots', 'bread', 'milk'],
             ['celery', 'carrots', 'bread', 'cream'])


#layered_multiplier
def multiply(some_list, num):
    for i in range(0, len(some_list)):
        some_list[i] = some_list[i] * num
    return some_list

def layered_multiplier(some_list):
    new_list = []
    for i in range(0, len(some_list)):
        new_list.append('1' * some_list[i])
    return new_list


print(layered_multiplier(multiply([2, 4, 5], 3)))


#checkerbord
def print_checkerbord():
    line1 = ' * * * *'
    line2 = '* * * *'
    for i in range(0, 8):
        if i % 2 is 0:
            print(line1)
        else:
            print(line2)

print_checkerbord()


def throw_coin_5000_times():
    i = 0
    head = 0
    tail = 0
    while i < 5000:
        x = random.random()
        if x >= 0.5:
            head += 1
        else:
            tail += 1
        i += 1
    print('Head is %s \nTail is %s' % (head, tail))

throw_coin_5000_times()


def draw_stuff_many_times(some_list):
    for el in some_list:
        if isinstance(el, (int, float)):
            print('*')*el
        elif isinstance(el, str):
            print(el[0].lower())*len(el)

draw_stuff_many_times([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])


def iterating_in_dict(some_dic):
    for group, students in some_dic.iteritems():
        print(group.upper() + '\n' + '___________________')
        for student in students:
            print(student['first_name'] + ' ' + student['last_name'])

users = {
         'Students': [
                      {'first_name': 'Michael', 'last_name': 'Jordan'},
                      {'first_name': 'John', 'last_name': 'Rosales'},
                      {'first_name': 'Mark', 'last_name': 'Guillen'},
                      {'first_name': 'KB', 'last_name': 'Tonel'}
                      ],
        }

iterating_in_dict(users)


def two_list_to_dict(list1, list2):
    dic = {}
    dic = dict(zip(list1, list2))
    return dic

name = ["Anna", "Eli", "Pariece", "Brendan", "Amy", "Shane", "Oscar"]
favorite_animal = ["horse", "cat", "spider", "giraffe", "ticks", "dolphins", "llamas"]
print(two_list_to_dict(name, favorite_animal))