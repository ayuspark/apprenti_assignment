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
        ''' % (self.price, self.tax, self.speed, self.fuel, self.mileage))

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


class Animal(object):
    # class Animal assignment
    def __init__(self, name, health=100):
        self.name = name
        self.health = health
        self.distance = 0
    
    def walk(self):
        self.health -= 1
        return self

    def run(self):
        self.health -= 5
        return self

    def display_health(self):
        print('Health is: ', self.health)

animal_1 = Animal('lola')
animal_1.walk().run().run()
animal_1.display_health()
print(animal_1.name)


class Dog(Animal):
    # class Dog assignment
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150

    def pet(self, boo=False):
        if boo is True:
            self.health += 5
        return self



class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170
    
    def fly(self):
        self.health -= 10
        return self

    def display_health(self):
        print('I am a bloody dragon and my health is: ', self.health)


class Mathstuff(object):
    # class Mathstuff assignment
    def __init__(self):
        self.mysum = 0


    def add(self, *nums):
        for i in nums:
            if type(i) is list or type(i) is tuple:
                self.mysum += sum(i)
            else:
                self.mysum += i
        return self

    def substract(self, *nums):
        for i in nums:
            if type(i) is list or type(i) is tuple:
                self.mysum -= sum(i)
            else:
                self.mysum -= i
        return self




def main():
    # to make variable not constant
    bike1 = Bike('55', '70')
    bike1.display_info()
    bike1.ride().ride().ride()
    bike1.reverse()

    dog_1 = Dog('haha')
    dog_1.run().run().run()
    dog_1.display_health()

    dragon_1 = Dragon('bob')
    dragon_1.fly().fly().fly()
    dragon_1.display_health()
    
    math_1 = Mathstuff()
    print(math_1.add(2, 2, 4, 55, 3).substract(3, 4).mysum)

if __name__ == '__main__':
    main()
