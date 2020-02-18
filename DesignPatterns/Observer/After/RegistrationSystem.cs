using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Observer
{
    public class RegistrationSystem
    {
        private readonly IDbConnection _connection;
        private readonly IMemberIdRegistry _idRegistry;

        public RegistrationSystem(IDbConnection connection, IMemberIdRegistry idRegistry)
        {
            _connection = connection;
            _idRegistry = idRegistry;
        }

        public event RegistrationEvent OnRegistration;

        public void Register(string firstName, string lastName)
        {
            // perform the "core" registration logic: 
            // generate an ID
            // track the registration in our db
            var id = _idRegistry.AssignId(firstName, lastName);

            var cmd = _connection.CreateCommand();
            cmd.CommandText = "insert into ....";
            cmd.ExecuteNonQuery();

            // then, notify any other components that need to know when registrations take place.
            OnRegistration?.Invoke(this, new RegistrationEventArgs
            {
                Name = $"{firstName} {lastName}",
                Id = id
            });
        }
    }

    public delegate void RegistrationEvent(object sender, RegistrationEventArgs args);
}
