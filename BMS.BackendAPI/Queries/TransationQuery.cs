namespace BMS.BackendAPI.Queries;

internal class TransationQuery
{
    public static string InsertQuery { get; } = @"INSERT INTO [dbo].[Tbl_Transation]
                                           ([TransationDate]
                                           ,[Amount]
                                           ,[TransationType]
                                           ,[SenderNo]
                                           ,[ReceiverNo])
                                     VALUES
                                           (@TransationDate
                                           ,@Amount
                                           ,@TransationType
                                           ,@SenderNo
                                           ,@ReceiverNo)";

    public static string SelectAllQuery { get; } = @"SELECT [TransationId]
                                              ,[TransationDate]
                                              ,[Amount]
                                              ,[TransationType]
                                              ,[SenderNo]
                                              ,[ReceiverNo]
                                          FROM [dbo].[Tbl_Transation]";

    public static string SelectQuery { get; } = @"SELECT [TransationId]
                                              ,[TransationDate]
                                              ,[Amount]
                                              ,[TransationType]
                                              ,[SenderNo]
                                              ,[ReceiverNo]
                                          FROM [dbo].[Tbl_Transation]
                                          WHERE TransationId = @TransationId";
}
