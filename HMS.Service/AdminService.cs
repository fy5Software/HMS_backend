using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class AdminService : IAdminService
    {
        IDbHelper dbHelper;

        public AdminService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        string selectQuery = @"SELECT a.[Id]
                                          ,a.[IsActive]
                                          ,a.[CreatedOn]
                                          ,a.[CreatedBy]
                                          ,a.[UpdatedOn]
                                          ,a.[UpdatedBy]
                                          ,a.[BusinessName]
                                          ,a.[CategoryId]
                                          ,a.[FoodLincNum]
                                          ,a.[Address]
                                          ,a.[Gst]
                                          ,a.[AccountName]
                                          ,a.[AccountNumber]
                                          ,a.[BankName]
                                          ,a.[IfscCode]
                                          ,a.[PinCode]
                                          ,a.[RestaurentLogo]
                                          ,a.[Signature]
                                          ,a.[TermAndCondition]
                                          ,a.[BankAddress]
                                          ,a.[CodeImage]
                                          ,a.[CodeNumber]
                                          ,a.[CityId]
                                          ,a.[StateId]
                                          ,a.[Contact]
                                          ,a.[Email]
                                          ,a.[SubscriptionStatus]
                                          ,st.[Name] as State
	                                      ,ct.[Name] as City
                                          ,bc.[Name] as Category
                                      FROM [dbo].[Admin] a
                                         inner join StateMaster st on st.Id = a.[StateId]
                          inner join CityMaster ct on ct.Id = a.[CityId]
                             inner join BusinessCategory bc on bc.Id = a.[CategoryId]
                          order by a.UpdatedOn desc";
        string insertQuery = @"INSERT INTO [dbo].[Admin]
                                           ([IsActive]
                                           ,[CreatedOn]
                                           ,[CreatedBy]
                                           ,[UpdatedOn]
                                           ,[UpdatedBy]
                                           ,[BusinessName]
                                           ,[CategoryId]
                                           ,[FoodLincNum]
                                           ,[Address]
                                           ,[Gst]
                                           ,[AccountName]
                                           ,[AccountNumber]
                                           ,[BankName]
                                           ,[IfscCode]
                                           ,[PinCode]
                                           ,[RestaurentLogo]
                                           ,[Signature]
                                           ,[TermAndCondition]
                                           ,[BankAddress]
                                           ,[CodeImage]
                                           ,[CodeNumber]
                                           ,[CityId]
                                           ,[StateId]
                                           ,[StartDate]
                                           ,[EndDate]
                                           ,[SubscriptionStatus]
                                           ,[Contact]
                                           ,[Email])
                                     VALUES
                                           (@IsActive
                                           ,@CreatedOn
                                           ,@CreatedBy
                                           ,@UpdatedOn
                                           ,@UpdatedBy
                                           ,@BusinessName
                                           ,@CategoryId
                                           ,@FoodLincNum
                                           ,@Address
                                           ,@Gst
                                           ,@AccountName
                                           ,@AccountNumber
                                           ,@BankName
                                           ,@IfscCode
                                           ,@PinCode
                                           ,@RestaurentLogo
                                           ,@Signature
                                           ,@TermAndCondition
                                           ,@BankAddress
                                           ,@CodeImage
                                           ,@CodeNumber
                                           ,@CityId
                                           ,@StateId
                                           ,@StartDate
                                           ,@EndDate
                                           ,@SubscriptionStatus
                                           ,@Contact
                                           ,@Email )";
        string updateQuery = @"UPDATE [dbo].[Admin]
                           SET [IsActive] =@IsActive
                              ,[CreatedOn] =@CreatedOn
                              ,[CreatedBy] =@CreatedBy
                              ,[UpdatedOn] =@UpdatedOn
                              ,[UpdatedBy] =@UpdatedBy
                              ,[BusinessName] =@BusinessName
                              ,[CategoryId] =@CategoryId
                              ,[FoodLincNum] =@FoodLincNum
                              ,[Address] =@Address
                              ,[Gst] =@Gst
                              ,[AccountName] =@AccountName
                              ,[AccountNumber] =@AccountNumber
                              ,[BankName] =@BankName
                              ,[IfscCode] =@IfscCode
                              ,[PinCode] =@PinCode
                              ,[RestaurentLogo] =@RestaurentLogo
                              ,[Signature] =@Signature
                              ,[TermAndCondition] =@TermAndCondition
                              ,[BankAddress] =@BankAddress
                              ,[CodeImage] =@CodeImage
                              ,[CodeNumber] =@CodeNumber
                              ,[CityId]=@CityId
                              ,[StateId]=@StateId
                              ,[Contact]=@Contact
                              ,[Email]=@Email
                         WHERE Id=@Id";
        string deleteQuery = "Delete from Admin ";
        public void Add(IModel model)
        {
            var admin = (Admin)model;
            admin.IsActive = true;
            dbHelper.Add(insertQuery, admin);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}",new Admin { Id = id });
            
        }

        public IList<Admin> GetAll<Admin>()
        {
            var AdminList = dbHelper.FetchData<Admin>($"{selectQuery}");
            return AdminList;
        }

        public IList<Admin> GetById<Admin>(int id)
        {
            var AdminList = dbHelper.FetchData<Admin>($"{selectQuery} where id ={id}");
            return AdminList;
        }

        public void Update(IModel model)
        {
            var admin = (Admin)model;
            
            dbHelper.Update(updateQuery, admin);
        }
        public void UpdateSubscriptionId(IModel model)
        {
            var admin = (Admin)model;

            dbHelper.Update($"UPDATE[dbo].[Admin] SET [SubscriptionStatus] = {admin.SubscriptionStatus} WHERE ID = {admin.Id}", admin);
        }



    }
}
