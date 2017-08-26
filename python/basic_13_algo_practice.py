def print_to_255():
    for i in range(0, 1 + 255):
        print i


print_to_255()


def print_ints_and_sum():
    sum_1 = 0
    for i in range(0, 255 + 1):
        sum_1 += i
    print sum_1


print_ints_and_sum()


def print_max_and_min_of_array(list_1):
    max_num = 0
    min_num = list_1[0]
    for i in list_1:
        if max_num < i:
            max_num = i
        if min_num > i:
            min_num = i
    print "this is %s" % (max_num)
    print "this is %s" % (min_num)
    return max_num


print_max_and_min_of_array([2, 4, 33, 234, 99])


def return_odds_upto_255():
    result = []
    for i in range(0, 255 + 1):
        if i % 2 is not 0:
            result.append(i)
    print result


return_odds_upto_255()


def return_array_count_greater_than_y(list_1, y):
    count = 0
    for item in list_1:
        if item > y:
            count += 1
    print count
    return count


return_array_count_greater_than_y([2, 3, 4, 45, 8], 8)


def print_max_min_avg(list_1):
    print_max_and_min_of_array(list_1)
    sum_1 = 0
    for item in list_1:
        sum_1 += item
    avg = sum_1 / len(list_1)
    print avg


print_max_min_avg([2, 3, 4, 45, 8])


def swap_for_nagative(list_1):
    for i in range(0, len(list_1)):
        if list_1[i] < 0:
            list_1[i] = 'haha'
    print list_1


swap_for_nagative([2, 4, -4, 5, -6])


def shift_list_left(list_1):
    for i in range(0, len(list_1) - 1):
        list_1[i] = list_1[i + 1]
    list_1.pop()
    print list_1
    

shift_list_left([2, 4, -4, 5, -6])
