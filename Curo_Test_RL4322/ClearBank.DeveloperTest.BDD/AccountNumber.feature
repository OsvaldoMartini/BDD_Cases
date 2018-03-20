Feature: Account Holder Make Payments
	As a Account Holder
	I want to Make Payments in The System(assumptions: OnLine Banking, Device App)
	So that I can Make Payments any where

@AccountHolder
Scenario: Account number exists in Account Data Store 
  Given I have account number
  And account number is "AC-1234"
  When I look the account number "AC-1234"
  Then should return the valid account number

@AccountHolder
Scenario: Account number not exists in Account Data Store 
  Given I have account number
  And account number is "AC-5432"
  When I look the account number "AC-5432"
  Then account number should return null

@AccountHolder
Scenario: Ensure the account number have valid state
  Given I have account number
  And exist Payment Schemes
  And exist Account Status
  When I look the account number "AC-1234"
  And account number status valid (assumptions: Not Disable)
  And account number has valid payment scheme
  Then should return payment scheme


@AccountHolder
Scenario: Do Not Make a Payment Account Status not Allowed
  Given I have account number
  And exist Payment Schemes
  And exist Account Status
  When I look the account number "AC-1234"
  And account number status invalid (assumptions: Disable)
  And account number has invalid payment scheme
  Then should return account status disable

#The MakePayment in PaymentService
#Must be 100% Decoupled from Client class
#OperationContrat=OneWay
            
@AccountHolder
Scenario: Make a payment with with sufficient funds
  Given I have account number
  And account balance is £200.00
  And account holder pays £50.00
  Then deduct from account balance
  And make payment return success

@AccountHolder
Scenario: Check Balance after deduction
  Given I have account number
  And account number is "AC-1234"
  When I look the account number "AC-1234"
  Then account balance should be £150.00

@AccountHolder
Scenario: Payment does not occur with insufficient funds
  Given I have account number
  And the account balance is £10.00
  And account holder pays £50.00
  When I look the account number "AC-1234"
  Then account balance has insufficient funds
  
