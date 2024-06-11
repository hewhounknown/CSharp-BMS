namespace BMS.BackendAPI.Queries;

internal class TransationQuery
{
    public static string InsertQuery { get; } = @"INSERT INTO [dbo].[Tbl_Transation]
                                           ([TransationDate]
                                           ,[Amount]
                                           ,[TransationType]
                                           ,[ReceiverNo]
                                           ,[AccountNo])
                                     VALUES
                                           (@TransationDate
                                           ,@Amount
                                           ,@TransationType
                                           ,@ReceiverNo
                                           ,@AccountNo)";

    public static string SelectAllQuery { get; } = @"SELECT [TransationId]
                                              ,[TransationDate]
                                              ,[Amount]
                                              ,[TransationType]
                                              ,[ReceiverNo]
                                              ,[AccountNo]
                                          FROM [dbo].[Tbl_Transation]";

    public static string SelectQuery { get; } = @"SELECT [TransationId]
                                              ,[TransationDate]
                                              ,[Amount]
                                              ,[TransationType]
                                              ,[ReceiverNo]
                                              ,[AccountNo]
                                          FROM [dbo].[Tbl_Transation]
                                          WHERE TransationId = @TransationId";
}
