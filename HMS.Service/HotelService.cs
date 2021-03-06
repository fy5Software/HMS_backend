using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class HotelService : IHotelService
    {
        IDbHelper dbHelper;

        public HotelService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        string selectQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[Size]
                              ,[IsAc]
                              ,[Shape]
                              ,[BarcodeTest]
                          FROM [dbo].[Hotel]";
        string insertQuery = @"INSERT INTO [dbo].[Hotel]
                                       ([IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy]
                                       ,[Name]
                                       ,[Size]
                                       ,[IsAc]
                                       ,[Shape]
                                       ,[BarcodeTest])
                                 VALUES
                                       (@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy
                                       ,@Name
                                       ,@Size
                                       ,@IsAc
                                       ,@Shape
                                       ,@BarcodeTest)";
        string updateQuery = @"UPDATE [dbo].[Hotel]
                       SET [IsActive] =@IsActive
                          ,[CreatedOn] =@CreatedOn
                          ,[CreatedBy] =@CreatedBy
                          ,[UpdatedOn] =@UpdatedOn
                          ,[UpdatedBy] =@UpdatedBy
                          ,[Name] =@Name
                          ,[Size] =@Size
                          ,[IsAc] =@IsAc
                          ,[Shape] =@Shape
                          ,[BarcodeTest] =@arcodeTest
                     WHERE Id=@Id";
        string selectByIdQuery = "";
        string deleteQuery = "Delete from Hotel";
        public void Add(IModel model)
        {
            var hotel = (Hotel)model;
            hotel.IsActive = true;
            dbHelper.Add(insertQuery, hotel);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new Hotel { Id = id });
        }

        public IList<Hotel> GetAll<Hotel>()
        {
            var HotelList = dbHelper.FetchData<Hotel>($"{selectQuery}");
            return HotelList;
        }

        public IList<Hotel> GetById<Hotel>(int id)
        {
            var HotelList = dbHelper.FetchData<Hotel>($"{selectQuery} where id ={id}");
            return HotelList;
        }

        public void Update(IModel model)
        {
            var hotel = (Hotel)model;

            dbHelper.Update(updateQuery, hotel);
        }
    }
}
