using System;
using System.Collections.Generic;
using ConstantConnect.Repository.Entities.CRM;

namespace ConstantConnect.Repository.Helpers
{
    public class RoomComparer : IEqualityComparer<New_clientroom>
    {
        public bool Equals(New_clientroom x, New_clientroom y)
        {
            return x.New_clientroomId == y.New_clientroomId;
        }

        public int GetHashCode(New_clientroom obj)
        {
            throw new NotImplementedException();
        }
    }
}