using System;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public class StaffUserIAsyncCursor<T> where T : BaseUser
    {

        public StaffUserIAsyncCursor(IAsyncCursor<BaseUser> cursor)
        {
            Cursor = cursor;
        }
        public IAsyncCursor<BaseUser> Cursor { get; }
    }
}