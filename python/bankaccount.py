class BankAccount(object):
    def __init__(self, balance=3000):
        self.balance = balance

    def deposit(self, amount):
        self.balance += amount
        return self.balance

    def withdraw(self, amount):
        if self.balance >= amount:
            self.balance -= amount
        else:
             return 'invalid transaction'
        return self.balance

class MinibalanceAccount(BankAccount):
    def __init__(self, mini=1000):
        self.mini = mini