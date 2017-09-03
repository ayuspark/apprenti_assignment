class Bike(price, max_speed, miles):
    def __init__(self):
        self.price = price
        self.max_speed = max_speed
        self.miles = miles
        return self
    def display_info():
        print(
            'The price is %s, the max speed is %s, and the miles is %s' %[self.price, self.max_speed, self.miles]
        )
