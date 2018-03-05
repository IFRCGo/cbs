using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers.DataOwner
{
    public class DataOwnerEventProcessor : ICanProcessEvents
    {
        //TODO: Update the new System
        //private readonly IDataOwners _dataOwners;

        //public DataOwnerEventProcessor(
        //    IDataOwners dataOwners
        //)
        //{
        //    _dataOwners = dataOwners;
        //}

        //public async Task Process(DataOwnerAdded @event)
        //{
        //    await _dataOwners.SaveAsync(new DataOwner
        //    {
        //        YearOfBirth = @event.YearOfBirth,
        //        AssignedNationalSocieties = new List<Guid>(),
        //        DisplayName = @event.DisplayName,
        //        DutyStation = @event.DutyStation,
        //        Email = @event.Email,
        //        FullName = @event.FullName,
        //        Id = @event.StaffUserId,
        //        Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
        //        MobilePhoneNumbers = new List<PhoneNumber>(),
        //        Sex = (Sex)@event.Sex,
        //        NationalSociety = @event.NationalSociety,
        //        PreferredLanguage = (Language)@event.PreferredLanguage,
        //        Position = @event.Position
        //    });
        //}

        //public async Task Process(StaffUserDeleted @event)
        //{
        //    if ((Role)@event.Role == Role.DataOwner)
        //        await _dataOwners.RemoveAsync(@event.StaffUserId);
        //}

        //public void Process(PhoneNumberAddedToStaffUser @event)
        //{
        //    if ((Role) @event.Role != Role.DataOwner)
        //    {
        //        return;
        //    }
        //    var user = _dataOwners.GetById(@event.StaffUserId);
        //    //TODO: Should be checked in business validator(?)
        //    if (user == null)
        //    {
        //        return;
        //    }
        //    user.MobilePhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));

        //    _dataOwners.SaveAsync(user);

        //}
        //public void Process(PhoneNumberRemovedFromStaffUser @event)
        //{
        //    if ((Role) @event.Role != Role.DataOwner)
        //    {
        //        return;
        //    }
        //    var user = _dataOwners.GetById(@event.StaffUserId);
        //    //TODO: Should be checked in business validator(?)
        //    if (user == null)
        //    {
        //        return;
        //    }
        //    user.MobilePhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
        //    _dataOwners.SaveAsync(user);
        //}
    }
}