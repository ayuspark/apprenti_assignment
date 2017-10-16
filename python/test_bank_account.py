import unittest
from bankaccount import *


class AccountBalanceTestCase(unittest.TestCase):
    def setUp(self):
        self.account_luyao = BankAccount()

    def test_balance(self):
        self.assertEqual(self.account_luyao.balance, 3000, msg='Account Balance invalid')
    
    def test_deposit(self):
        self.account_luyao.deposit(4000)
        self.assertEqual(self.account_luyao.balance, 7000, msg='Deposit method inaccurate')

    def test_withdraw(self):
        self.account_luyao.withdraw(500)
        assert self.account_luyao.balance == 250000

    def test_invalid_transaction(self):
        self.assertEqual(self.account_luyao.withdraw(6000), 'invalid transaction', msg='invalid transaction')
    
    def test_subclass(self):
        self.assertTrue(issubclass(MinibalanceAccount, BankAccount), msg='not true subclass of balance account')



if __name__=='__main__':
    unittest.main()
