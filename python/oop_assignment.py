class Bike(object):
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
        # return self

    def display_info(self):
        print(
            'The price is %s, the max speed is %s, and the miles is %s'
            % (self.price, self.max_speed, self.miles)
        )
    
    def ride(self):
        self.miles += 10
        print(self.miles)
        return self

    def reverse(self):
        if self.miles >= 5:
            self.miles -= 5
        print('Reversing...', 5)
        return self


bike1 = Bike('55', '70')
bike1.display_info()
bike1.ride().ride().ride()
bike1.reverse()