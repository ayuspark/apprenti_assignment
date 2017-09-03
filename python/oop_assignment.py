class Bike(object):
    # class Bike assignment
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


class Car(object):
    # class Car assignment
    def __init__(self, price):
        self.price = price
        self.speed = 0
        self.fuel = 1.0
        self.mileage = 0
        self.tax = self.get_tax()
    
    def display_info(self):
        print('''
              Price: %d \n
              Tax: %s \n
              Speed: %s \n
              Fuel: %s \n
              Mileage: %s \n
        '''%(self.price, self.tax, self.speed, self.fuel, self.mileage))

    def get_tax(self):
        if self.price > 10000:
            self.tax = '15%'
        else:
            self.tax = '12%'
        return self.tax
    
    def drive(self):
        self.mileage += 100
        self.fuel -= 0.2
        return self

    def fuel_up(self):
        self.fuel = 1.0


car_1 = Car(13000)
car_1.drive().drive().drive().drive()
car_1.display_info()
