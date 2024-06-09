namespace BMS.WebAPI.Queries;

internal class CustomerQuery
{
    public static string InsertQuery { get; } = @"INSERT INTO [dbo].[Tbl_Customer]
                                            ([Name]
                                            ,[Email]
                                            ,[Address]
                                            ,[PhoneNumber]
                                            ,[CustomerNo])
                                        VALUES
                                            (@Name
                                            ,@Email
                                            ,@Address
                                            ,@PhoneNumber
                                            ,@CustomerNo)";

    public static string SelectAllQuery { get; } = @"SELECT [CustomerId]
                                                    ,[Name]
                                                    ,[Email]
                                                    ,[Address]
                                                    ,[PhoneNumber]
                                                    ,[CustomerNo]
                                                FROM [dbo].[Tbl_Customer]";

    public static string SelectQuery { get; } = @"SELECT [CustomerId]
                                                    ,[Name]
                                                    ,[Email]
                                                    ,[Address]
                                                    ,[PhoneNumber]
                                                    ,[CustomerNo]
                                                FROM [dbo].[Tbl_Customer]
                                                WHERE CustomerId = @CustomerId";

    public static string UpdateQuery { get; } = @"UPDATE [dbo].[Tbl_Customer]
                                                SET [Name] = @Name
                                                    ,[Email] = @Email
                                                    ,[Address] = @Address
                                                    ,[PhoneNumber] = @PhoneNumber
                                                    ,[CustomerNo] = @CustomerNo
                                                WHERE CustomerId = @CustomerId";

    public static string DeleteQuery { get; } = @"DELETE FROM [dbo].[Tbl_Customer]
                                                WHERE CustomerId = @CustomerId";

    public static string SelectQueryWithAccount { get; } = @"SELECT Customer.*, 
                                                      Account.AccountNo, Account.AccountType, Account.Balance, Account.Password
                                                      FROM [dbo].[Tbl_Customer] Customer
                                                      Inner Join [dbo].[Tbl_Account] Account
                                                      ON Customer.CustomerNo = Account.CustomerNo
                                                      WHERE Customer.CustomerNo = @CustomerNo";
}
