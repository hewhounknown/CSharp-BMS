namespace BMS.WebAPI.Queries;

internal class AccountQuery
{
    public static string InsertQuery { get; } = @"INSERT INTO [dbo].[Tbl_Account]
                                           ([AccountNo]
                                           ,[CustomerNo]
                                           ,[AccountType]
                                           ,[Balance]
                                           ,[Password])
                                     VALUES
                                           (@AccountNo
                                           ,@CustomerNo
                                           ,@AccountType
                                           ,@Balance
                                           ,@Password)";

    public static string SelectAllQuery { get; } = @"SELECT [AccountId]
                                              ,[AccountNo]
                                              ,[CustomerNo]
                                              ,[AccountType]
                                              ,[Balance]
                                              ,[Password]
                                          FROM [dbo].[Tbl_Account]";

    public static string SelectQuery { get; } = @"SELECT [AccountId]
                                              ,[AccountNo]
                                              ,[CustomerNo]
                                              ,[AccountType]
                                              ,[Balance]
                                              ,[Password]
                                          FROM [dbo].[Tbl_Account]
                                          WHERE AccountId = @AccountId";

    public static string UpdateQuery { get; } = @"UPDATE [dbo].[Tbl_Account]
                                           SET [AccountNo] = @AccountNo
                                              ,[CustomerNo] = @CustomerNo
                                              ,[AccountType] = @AccountType
                                              ,[Balance] = @Balance
                                              ,[Password] = @Password
                                         WHERE AccountId = @AccountId";

    public static string DeleteQuery { get; } = @"DELETE FROM [dbo].[Tbl_Account]
                                            WHERE AccountId = @AccountId";

    public static string SelectQueryWithCustomer { get; } = @"SELECT Account.*, 
                                                        Customer.Name, Customer.Email, Customer.PhoneNumber, Customer.Address
                                                          FROM [dbo].[Tbl_Account] Account 
                                                          JOIN [dbo].[Tbl_Customer] Customer
                                                          ON Account.CustomerNo = Customer.CustomerNo
                                                          WHERE Account.CustomerNo = @CustomerNo";

    public static string UpdateBalanceQuery { get; } = @"UPDATE [dbo].[Tbl_Account]
                                                   SET [Balance] = @Balance
                                                 WHERE AccountNo = @AccountNo AND Password = @Password";

    public static string SelectQueryByNo { get; } = @"SELECT [AccountId]
                                              ,[AccountNo]
                                              ,[CustomerNo]
                                              ,[AccountType]
                                              ,[Balance]
                                              ,[Password]
                                          FROM [dbo].[Tbl_Account]
                                          WHERE AccountNo = @AccountNo";
}
